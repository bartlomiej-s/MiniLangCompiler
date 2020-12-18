namespace CompilerSpace
{
    class StringVal : SyntaxTree
    {
        private string val;

        public StringVal(string _val, int _line) { val = _val; line = _line; }

        public override string CheckName()
        {
            name = val;
            return name;
        }

        public override char CheckType()
        {
            type = 's';
            return type;
        }

        public override int GetStackSize()
        {
            return 1;
        }

        public override bool GenCode()
        {
            Compiler.EmitCode($"ldstr {name}");
            return true;
        }
    }
}
