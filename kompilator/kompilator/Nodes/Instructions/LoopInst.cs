namespace CompilerSpace
{
    class LoopInst : SyntaxTree
    {
        private SyntaxTree exp;
        private SyntaxTree inst;

        public LoopInst(SyntaxTree _exp, SyntaxTree _inst, int _line) { exp = _exp; inst = _inst; line = _line; }

        public override string CheckName()
        {
            exp.CheckName();
            inst.CheckName();
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
            inst.CheckType();
            type = ' ';
            return type;
        }

        public override int GetStackSize()
        {
            int expStack = exp.GetStackSize();
            int loopStack = inst.GetStackSize();
            return expStack >= loopStack ? expStack : loopStack;
        }

        public override bool GenCode()
        {
            string expplace = Compiler.GetJump();
            string loopplace = Compiler.GetJump();
            Compiler.EmitCode($"br {expplace}");
            Compiler.EmitCode($"{loopplace}: nop");
            bool instStack = inst.GenCode();
            if (instStack) Compiler.EmitCode("pop");
            Compiler.EmitCode($"{expplace}: nop");
            exp.GenCode();
            Compiler.EmitCode($"brtrue {loopplace}");
            return false;
        }
    }
}
