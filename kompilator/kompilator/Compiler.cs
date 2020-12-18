using ParserSpace;
using ScannerSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompilerSpace
{
    class Compiler
    {
        // Syntax tree
        public static List<SyntaxTree> code = new List<SyntaxTree>();

        // Symbol table
        // key - name of the symbol
        // value - array (1st element - type of the symbol, 2nd element - number of the symbol)
        public static Hashtable symbols = new Hashtable();

        public static List<string> sourceList;

        public static int errors = 0;
        public static List<ErrorData> alerts = new List<ErrorData>();

        private static StreamWriter sw;
        private static int nr;
        private static int idjump;

        static int Main(string[] args)
        {
            string file;
            FileStream source;
            Console.WriteLine();
            PrintInfo("CIL Code Generator for \'Mini\' programming language");
            Console.WriteLine();

            if (args.Length >= 1)
                file = args[0];
            else
            {
                PrintError("No input file", ErrorType.Other, -1, true);
                Console.WriteLine();
                return 1;
            }

            try
            {
                var sr = new StreamReader(file);
                string str = sr.ReadToEnd();
                sr.Close();
                sourceList = new List<string>(str.Split(new string[] { "\r\n" }, System.StringSplitOptions.None));
                source = new FileStream(file, FileMode.Open);
            }
            catch (Exception e)
            {
                PrintError("Problem with reading file: " + e.Message, ErrorType.Other, -1, true);
                Console.WriteLine();
                return 1;
            }

            Scanner scanner = new Scanner(source);
            Parser parser = new Parser(scanner);
            if (!parser.Parse())
            {
                PrintError("Parser error", ErrorType.Other, -1, true);
                Console.WriteLine();
                return 1;
            }
            source.Close();

            SemanticAnalysis();
            PrintSavedErrors();
            Console.WriteLine();

            if (errors == 0)
            {
                sw = new StreamWriter(file + ".il");
                GenCode();
                sw.Close();
                PrintInfo("Compilation successful");
            }
            else
            {
                PrintInfo($"Compilation failure, {errors} errors detected");
            }
            Console.WriteLine();
            return errors == 0 ? 0 : 2;
        }

        public static void EmitCode(string instr = null)
        {
            sw.WriteLine(instr);
        }

        public static void EmitCode(string instr, params object[] args)
        {
            sw.WriteLine(instr, args);
        }

        private static int GetMaxStack()
        {
            int stack = 1;
            for (int i = 0; i < code.Count; ++i)
            {
                int stackAct = code[i].GetStackSize();
                if (stackAct > stack) stack = stackAct;
            }
            return stack;
        }

        private static void SemanticAnalysis()
        {
            for (int i = 0; i < code.Count; ++i)
            {
                code[i].CheckSemantics();
            }
        }

        private static void GenCode()
        {
            GenProlog();

            for (int i = 0; i < code.Count; ++i)
            {
                EmitCode($"// line {code[i].line,3} :  " + sourceList[code[i].line - 1]);
                bool stack = code[i].GenCode();
                if (stack) Compiler.EmitCode("pop");
                Compiler.EmitCode();
            }

            GenEpilog();
        }

        private static void GenProlog()
        {
            int maxStack = GetMaxStack();

            EmitCode(".assembly extern mscorlib { }");
            EmitCode(".assembly program { }");
            EmitCode(".method static void main()");
            EmitCode("{");
            EmitCode(".entrypoint");
            EmitCode($".maxstack {maxStack}");
            EmitCode(".try");
            EmitCode("{");
            EmitCode();
        }

        private static void GenEpilog()
        {
            EmitCode("leave EndMain");
            EmitCode("}");
            EmitCode("catch [mscorlib]System.Exception");
            EmitCode("{");
            EmitCode("callvirt instance string [mscorlib]System.Exception::get_Message()");
            EmitCode("call void [mscorlib]System.Console::WriteLine(string)");
            EmitCode("leave EndMain");
            EmitCode("}");
            EmitCode("EndMain: ret");
            EmitCode("}");
        }

        public static void SaveError(string str, ErrorType type, int line = -1, bool disableDash = false)
        {
            ErrorData dataStruct = new ErrorData(str, type, line, disableDash);
            alerts.Add(dataStruct);
        }

        public static void PrintSavedErrors()
        {
            alerts = alerts.OrderBy(x => x.line).ToList();

            for (int i = 0; i < alerts.Count; i++)
            {
                ErrorData data = alerts[i];
                PrintError(data.str, data.type, data.line, data.disableDash);
            }
        }

        public static void PrintInfo(string str)
        {
            Console.WriteLine("[INFO] " + str);
        }

        public static void PrintWarning(string str)
        {
            Console.WriteLine("[WARNING] " + str);
        }

        public static void PrintError(string str, ErrorType type, int line = -1, bool disableDash = false)
        {
            string alert = "[ERROR] ";
            switch (type)
            {
                case ErrorType.Lexical:
                    alert += "Lexical error ";
                    break;
                case ErrorType.Syntax:
                    alert += "Syntax error ";
                    break;
                case ErrorType.Semantic:
                    alert += "Semantic error ";
                    break;
            }
            if (!disableDash) alert += "- ";
            if (line != -1) alert = alert + str + " (line: " + line + ")";
            else alert += str;

            Console.WriteLine(alert);
        }

        public static string GetType(char c)
        {
            switch (c)
            {
                case 'i':
                    return "<int>";
                case 'd':
                    return "<double>";
                case 'b':
                    return "<bool>";
                case 's':
                    return "<string>";
                case 't':
                    return "<type>";
            }
            return "<undefined>";
        }

        public static int GetVarId()
        {
            return nr++;
        }

        public static string GetVarName(string id)
        {
            return string.Format($"_{id}");
        }

        public static string GetJump()
        {
            return string.Format($"jump{++idjump}");
        }
    }
}
