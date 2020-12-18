namespace CompilerSpace
{
    class OutInst : SyntaxTree
    {
        private SyntaxTree exp;
        private StringVal str;

        public OutInst(SyntaxTree _exp, StringVal _str, int _line) { exp = _exp; str = _str; line = _line; }

        public override string CheckName()
        {
            if (exp != null) exp.CheckName();
            else str.CheckName();
            name = "";
            return name;
        }

        public override char CheckType()
        {
            if (exp != null)
            {
                char expType = exp.CheckType();
                if (expType != 'b' && expType != 'i' && expType != 'd')
                {
                    string expected = Compiler.GetType('i') + " or " + Compiler.GetType('d') + " or " + Compiler.GetType('b');
                    string got = Compiler.GetType(expType);
                    Compiler.errors++;
                    Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                }
            }
            else
            {
                char strType = str.CheckType();
                if (strType != 's')
                {
                    string expected = Compiler.GetType('s');
                    string got = Compiler.GetType(strType);
                    Compiler.errors++;
                    Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                }
            }
            type = ' ';
            return type;
        }

        public override int GetStackSize()
        {
            int stack = 0;
            if (exp != null)
            {
                switch (exp.type)
                {
                    case 'i':
                        stack = exp.GetStackSize();
                        break;
                    case 'd':
                        stack = exp.GetStackSize() + 2;
                        break;
                    case 'b':
                        stack = exp.GetStackSize();
                        break;
                }
            }
            else
            {
                stack = str.GetStackSize();
            }
            return stack;
        }

        public override bool GenCode()
        {
            if (exp != null)
            {
                switch (exp.type)
                {
                    case 'i':
                        exp.GenCode();
                        Compiler.EmitCode("call void [mscorlib]System.Console::Write(int32)");
                        break;
                    case 'd':
                        Compiler.EmitCode("call class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()");
                        Compiler.EmitCode("ldstr \"{0:0.000000}\"");
                        exp.GenCode();
                        Compiler.EmitCode("box [mscorlib]System.Double");
                        Compiler.EmitCode("call string [mscorlib]System.String::Format(class [mscorlib]System.IFormatProvider, string, object)");
                        Compiler.EmitCode("call void [mscorlib]System.Console::Write(string)");
                        break;
                    case 'b':
                        exp.GenCode();
                        Compiler.EmitCode("call void [mscorlib]System.Console::Write(bool)");
                        break;
                }
            }
            else
            {
                str.GenCode();
                Compiler.EmitCode("call void [mscorlib]System.Console::Write(string)");
            }
            return false;
        }
    }
}
