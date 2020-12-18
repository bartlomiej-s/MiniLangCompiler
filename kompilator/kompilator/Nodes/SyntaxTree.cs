namespace CompilerSpace
{
    public abstract class SyntaxTree
    {
        public char type;
        public string name;
        public int line = -1;

        public void CheckSemantics()
        {
            CheckName();
            CheckType();
        }

        public abstract string CheckName();
        public abstract char CheckType();
        public abstract int GetStackSize();
        public abstract bool GenCode();
    }
}
