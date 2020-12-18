using System;

namespace CompilerSpace
{
    class Ident : SyntaxTree
    {
        private string id;

        public Ident(string _id, int _line) { id = _id; line = _line; }

        public string SetName()
        {
            name = id;
            return name;
        }

        public override string CheckName()
        {
            if (Compiler.symbols.Contains(id))
            {
                name = id;
            }
            else
            {
                Compiler.errors++;
                Compiler.SaveError($"Undeclared variable", ErrorType.Semantic, line);
                name = null;
            }
            return name;
        }

        public override char CheckType()
        {
            if (name != null)
            {
                type = Convert.ToChar((string)((object[])Compiler.symbols[name])[0]);
            }
            else
            {
                type = ' ';
            }
            return type;
        }

        public override int GetStackSize()
        {
            return 1;
        }

        public override bool GenCode()
        {
            string num = ((int)((object[])Compiler.symbols[name])[1]).ToString();
            Compiler.EmitCode($"ldloc {num}");
            return true;
        }
    }
}
