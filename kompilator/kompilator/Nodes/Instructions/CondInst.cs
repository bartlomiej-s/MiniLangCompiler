namespace CompilerSpace
{
    class CondInst : SyntaxTree
    {
        private SyntaxTree exp;
        private SyntaxTree ifinst;
        private SyntaxTree elseinst;

        public CondInst(SyntaxTree _exp, SyntaxTree _ifinst, SyntaxTree _elseinst, int _line) { exp = _exp; ifinst = _ifinst; elseinst = _elseinst; line = _line; }

        public override string CheckName()
        {
            exp.CheckName();
            ifinst.CheckName();
            if (elseinst != null) elseinst.CheckName();
            name = "";
            return name;
        }

        public override char CheckType()
        {
            char expType = exp.CheckType();
            if (expType != 'b')
            {
                string expected = Compiler.GetType('b');
                string got = Compiler.GetType(expType);
                Compiler.errors++;
                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
            }
            ifinst.CheckType();
            if (elseinst != null) elseinst.CheckType();
            type = ' ';
            return type;
        }

        public override int GetStackSize()
        {
            int expStack = exp.GetStackSize();
            int ifStack = ifinst.GetStackSize();
            int stack = expStack >= ifStack ? expStack : ifStack;
            if (elseinst != null)
            {
                int elseStack = elseinst.GetStackSize();
                if (elseStack > stack) stack = elseStack;
            }
            return stack;
        }

        public override bool GenCode()
        {
            string elseplace = Compiler.GetJump();
            string endplace = Compiler.GetJump();
            exp.GenCode();
            Compiler.EmitCode($"brfalse {elseplace}");
            bool ifStack = ifinst.GenCode();
            if (ifStack) Compiler.EmitCode("pop");
            Compiler.EmitCode($"br {endplace}");
            Compiler.EmitCode($"{elseplace}: nop");
            if (elseinst != null)
            {
                bool elseStack = elseinst.GenCode();
                if (elseStack) Compiler.EmitCode("pop");
            }
            Compiler.EmitCode($"{endplace}: nop");
            return false;
        }
    }
}
