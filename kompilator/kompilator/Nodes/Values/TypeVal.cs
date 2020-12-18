namespace CompilerSpace
{
    class TypeVal : SyntaxTree
    {
        private char val;

        public TypeVal(char _val, int _line) { val = _val; line = _line; }

        public override string CheckName()
        {
            name = char.ToString(val);
            return name;
        }

        public override char CheckType()
        {
            type = 't';
            return type;
        }

        public override int GetStackSize()
        {
            return 0;
        }

        public override bool GenCode()
        {
            // Not supported in Mini language
            return false;
        }
    }
}
