namespace CompilerSpace
{
    class RetInst : SyntaxTree
    {
        public RetInst(int _line) { line = _line; }

        public override string CheckName()
        {
            name = "";
            return name;
        }

        public override char CheckType()
        {
            type = ' ';
            return type;
        }

        public override int GetStackSize()
        {
            return 0;
        }

        public override bool GenCode()
        {
            Compiler.EmitCode("leave EndMain");
            return false;
        }
    }
}
