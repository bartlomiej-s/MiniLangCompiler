using System.Collections.Generic;

namespace CompilerSpace
{
    class BlockInst : SyntaxTree
    {
        private List<SyntaxTree> instList;

        public BlockInst(List<SyntaxTree> _instList, int _line) { instList = _instList; line = _line; }

        public override string CheckName()
        {
            foreach (SyntaxTree st in instList)
            {
                st.CheckName();
            }
            name = "";
            return name;
        }

        public override char CheckType()
        {
            foreach (SyntaxTree st in instList)
            {
                st.CheckType();
            }
            type = ' ';
            return type;
        }

        public override int GetStackSize()
        {
            int stack = 0;
            for (int i = 0; i < instList.Count; ++i)
            {
                int stackAct = instList[i].GetStackSize();
                if (stackAct > stack) stack = stackAct;
            }
            return stack;
        }

        public override bool GenCode()
        {
            for (int i = 0; i < instList.Count; ++i)
            {
                Compiler.EmitCode();
                Compiler.EmitCode($"// line {instList[i].line,3} :  " + Compiler.sourceList[instList[i].line - 1]);
                bool instStack = instList[i].GenCode();
                if (instStack) Compiler.EmitCode("pop");
            }
            return false;
        }
    }
}
