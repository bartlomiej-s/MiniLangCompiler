namespace CompilerSpace
{
    class IntVal : SyntaxTree
    {
        private int val;

        public IntVal(int _val, int _line) { val = _val; line = _line; }

        public override string CheckName()
        {
            name = val.ToString();
            return name;
        }

        public override char CheckType()
        {
            type = 'i';
            return type;
        }

        public override int GetStackSize()
        {
            return 1;
        }

        public override bool GenCode()
        {
            Compiler.EmitCode($"ldc.i4 {name}");
            return true;
        }
    }
}
