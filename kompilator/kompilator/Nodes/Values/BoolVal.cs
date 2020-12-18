namespace CompilerSpace
{
    class BoolVal : SyntaxTree
    {
        private bool val;

        public BoolVal(bool _val, int _line) { val = _val; line = _line; }

        public override string CheckName()
        {
            if (val) name = "1";
            else name = "0";
            return name;
        }

        public override char CheckType()
        {
            type = 'b';
            return type;
        }

        public override int GetStackSize()
        {
            return 1;
        }

        public override bool GenCode()
        {
            Compiler.EmitCode($"ldc.i4.{name}");
            return true;
        }
    }
}
