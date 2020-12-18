using ParserSpace;

namespace CompilerSpace
{
    class ExpInst : SyntaxTree
    {
        private SyntaxTree left;
        private Tokens kind;
        private SyntaxTree right;

        public ExpInst(SyntaxTree _left, Tokens _kind, SyntaxTree _right, int _line) { left = _left; right = _right; kind = _kind; line = _line; }

        public override string CheckName()
        {
            if (left != null) left.CheckName();
            right.CheckName();
            name = "";
            return name;
        }

        public override char CheckType()
        {
            bool badl = false, badr = false;
            if (left == null)
            {
                char tr = right.CheckType();
                switch (kind)
                {
                    case Tokens.minus:
                        if (tr != 'i' && tr != 'd')
                        {
                            string expected = Compiler.GetType('i') + " or " + Compiler.GetType('d');
                            string got = Compiler.GetType(tr);
                            Compiler.errors++;
                            Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                            badr = true;
                            type = ' ';
                        }
                        else
                        {
                            type = tr;
                        }
                        break;
                    case Tokens.bneg:
                        if (tr != 'i')
                        {
                            string expected = Compiler.GetType('i');
                            string got = Compiler.GetType(tr);
                            Compiler.errors++;
                            Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                            badr = true;
                            type = ' ';
                        }
                        else
                        {
                            type = tr;
                        }
                        break;
                    case Tokens.lneg:
                        if (tr != 'b')
                        {
                            string expected = Compiler.GetType('b');
                            string got = Compiler.GetType(tr);
                            Compiler.errors++;
                            Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                            badr = true;
                            type = ' ';
                        }
                        else
                        {
                            type = tr;
                        }
                        break;
                    case Tokens.inttype:
                        type = 'i';
                        break;
                    case Tokens.doubletype:
                        type = 'd';
                        break;
                }
                if (!badr && tr != 'i' && tr != 'd' && tr != 'b')
                {
                    string expected = Compiler.GetType('i') + " or " + Compiler.GetType('d') + " or " + Compiler.GetType('b');
                    string got = Compiler.GetType(tr);
                    Compiler.errors++;
                    Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                    type = ' ';
                }
            }
            else
            {
                char tl = left.CheckType();
                char tr = right.CheckType();
                switch (kind)
                {
                    case Tokens.bor:
                    case Tokens.band:
                        if (tl != 'i' || tr != 'i')
                        {
                            string expected = Compiler.GetType('i');
                            if (tl != 'i' && tr != 'i')
                            {
                                string got1 = Compiler.GetType(tl);
                                string got2 = Compiler.GetType(tr);
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got1}", ErrorType.Semantic, line);
                                badl = true;
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got2}", ErrorType.Semantic, line);
                                badr = true;
                            }
                            else
                            {
                                string got = Compiler.GetType(tl != 'i' ? tl : tr);
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                                if (tl != 'i') badl = true;
                                else badr = true;
                            }
                            type = ' ';
                        }
                        else
                        {
                            type = 'i';
                        }
                        break;
                    case Tokens.mul:
                    case Tokens.div:
                    case Tokens.plus:
                    case Tokens.minus:
                        if ((tl != 'i' && tl != 'd') || (tr != 'i' && tr != 'd'))
                        {
                            string expected = Compiler.GetType('i') + " or " + Compiler.GetType('d');
                            if ((tl != 'i' && tl != 'd') && (tr != 'i' && tr != 'd'))
                            {
                                string got1 = Compiler.GetType(tl);
                                string got2 = Compiler.GetType(tr);
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got1}", ErrorType.Semantic, line);
                                badl = true;
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got2}", ErrorType.Semantic, line);
                                badr = true;
                            }
                            else
                            {
                                string got = Compiler.GetType((tl != 'i' && tl != 'd') ? tl : tr);
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                                if (tl != 'i' && tl != 'd') badl = true;
                                else badr = true;
                            }
                            type = ' ';
                        }
                        else
                        {
                            if (tl == 'i' && tr == 'i') type = 'i';
                            else type = 'd';
                        }
                        break;
                    case Tokens.equal:
                    case Tokens.diff:
                        if ((tl == 'b' && tr != 'b') || (tl != 'b' && tr == 'b'))
                        {
                            string typel = Compiler.GetType(tl);
                            string typer = Compiler.GetType(tr);
                            string op = kind == Tokens.equal ? "==" : "!=";
                            Compiler.errors++;
                            Compiler.SaveError($"Operator \"{op}\" does not support arguments of types: {typel}, {typer}", ErrorType.Semantic, line);
                            badl = true;
                            badr = true;
                            type = ' ';
                        }
                        else
                        {
                            type = 'b';
                        }
                        break;
                    case Tokens.larger:
                    case Tokens.largere:
                    case Tokens.smaller:
                    case Tokens.smallere:
                        if ((tl != 'i' && tl != 'd') || (tr != 'i' && tr != 'd'))
                        {
                            string expected = Compiler.GetType('i') + " or " + Compiler.GetType('d');
                            if ((tl != 'i' && tl != 'd') && (tr != 'i' && tr != 'd'))
                            {
                                string got1 = Compiler.GetType(tl);
                                string got2 = Compiler.GetType(tr);
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got1}", ErrorType.Semantic, line);
                                badl = true;
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got2}", ErrorType.Semantic, line);
                                badr = true;
                            }
                            else
                            {
                                string got = Compiler.GetType((tl != 'i' && tl != 'd') ? tl : tr);
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                                if (tl != 'i' && tl != 'd') badl = true;
                                else badr = true;
                            }
                            type = ' ';
                        }
                        else
                        {
                            type = 'b';
                        }
                        break;
                    case Tokens.lor:
                    case Tokens.land:
                        if (tl != 'b' || tr != 'b')
                        {
                            string expected = Compiler.GetType('b');
                            if (tl != 'b' && tr != 'b')
                            {
                                string got1 = Compiler.GetType(tl);
                                string got2 = Compiler.GetType(tr);
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got1}", ErrorType.Semantic, line);
                                badl = true;
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got2}", ErrorType.Semantic, line);
                                badr = true;
                            }
                            else
                            {
                                string got = Compiler.GetType(tl != 'b' ? tl : tr);
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                                if (tl != 'b') badl = true;
                                else badr = true;
                            }
                            type = ' ';
                        }
                        else
                        {
                            type = 'b';
                        }
                        break;
                    case Tokens.assign:
                        if (tl == 'd')
                        {
                            if (tr != 'i' && tr != 'd')
                            {
                                string expected = Compiler.GetType('d');
                                string got = Compiler.GetType(tr);
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                                badr = true;
                                type = ' ';
                            }
                            else
                            {
                                type = tl;
                            }
                        }
                        else
                        {
                            if (tr != tl)
                            {
                                string expected = Compiler.GetType(tl);
                                string got = Compiler.GetType(tr);
                                Compiler.errors++;
                                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                                badr = true;
                                type = ' ';
                            }
                            else
                            {
                                type = tl;
                            }
                        }
                        break;
                }
                if (!badl && tl != 'i' && tl != 'd' && tl != 'b')
                {
                    string expected = Compiler.GetType('i') + " or " + Compiler.GetType('d') + " or " + Compiler.GetType('b');
                    string got = Compiler.GetType(tl);
                    Compiler.errors++;
                    Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                    type = ' ';
                }
                if (!badr && tr != 'i' && tr != 'd' && tr != 'b')
                {
                    string expected = Compiler.GetType('i') + " or " + Compiler.GetType('d') + " or " + Compiler.GetType('b');
                    string got = Compiler.GetType(tr);
                    Compiler.errors++;
                    Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
                    type = ' ';
                }
            }
            return type;
        }

        public override int GetStackSize()
        {
            int stack;
            if (left == null)
            {
                stack = right.GetStackSize();
                if (kind == Tokens.lneg)
                {
                    if (stack < 2) stack = 2;
                }
            }
            else
            {
                if (kind == Tokens.lor || kind == Tokens.land)
                {
                    int stackL = left.GetStackSize();
                    int stackR = right.GetStackSize();
                    stack = stackL >= stackR ? stackL : stackR;
                }
                else if (kind == Tokens.assign)
                {
                    stack = right.GetStackSize();
                }
                else
                {
                    int stackL = left.GetStackSize();
                    int stackR = right.GetStackSize() + 1;
                    stack = stackL >= stackR ? stackL : stackR;
                }
            }
            return stack;
        }

        public override bool GenCode()
        {
            if (left == null)
            {
                switch (kind)
                {
                    case Tokens.minus:
                        right.GenCode();
                        Compiler.EmitCode("neg");
                        break;
                    case Tokens.bneg:
                        right.GenCode();
                        Compiler.EmitCode("not");
                        break;
                    case Tokens.lneg:
                        right.GenCode();
                        Compiler.EmitCode("ldc.i4.0");
                        Compiler.EmitCode("ceq");
                        break;
                    case Tokens.inttype:
                        right.GenCode();
                        Compiler.EmitCode("conv.i4");
                        break;
                    case Tokens.doubletype:
                        right.GenCode();
                        Compiler.EmitCode("conv.r8");
                        break;
                }
            }
            else
            {
                switch (kind)
                {
                    case Tokens.bor:
                        left.GenCode();
                        right.GenCode();
                        Compiler.EmitCode("or");
                        break;
                    case Tokens.band:
                        left.GenCode();
                        right.GenCode();
                        Compiler.EmitCode("and");
                        break;
                    case Tokens.mul:
                        left.GenCode();
                        if (left.type == 'i' && right.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        right.GenCode();
                        if (left.type == 'd' && right.type == 'i')
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode("mul");
                        break;
                    case Tokens.div:
                        left.GenCode();
                        if (left.type == 'i' && right.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        right.GenCode();
                        if (left.type == 'd' && right.type == 'i')
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode("div");
                        break;
                    case Tokens.plus:
                        left.GenCode();
                        if (left.type == 'i' && right.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        right.GenCode();
                        if (left.type == 'd' && right.type == 'i')
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode("add");
                        break;
                    case Tokens.minus:
                        left.GenCode();
                        if (left.type == 'i' && right.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        right.GenCode();
                        if (left.type == 'd' && right.type == 'i')
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode("sub");
                        break;
                    case Tokens.equal:
                        left.GenCode();
                        if ((left.type == 'i' || left.type == 'b') && right.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        right.GenCode();
                        if (left.type == 'd' && (right.type == 'i' || right.type == 'b'))
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode("ceq");
                        break;
                    case Tokens.diff:
                        left.GenCode();
                        if ((left.type == 'i' || left.type == 'b') && right.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        right.GenCode();
                        if (left.type == 'd' && (right.type == 'i' || right.type == 'b'))
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode("ceq");
                        Compiler.EmitCode("ldc.i4.0");
                        Compiler.EmitCode("ceq");
                        break;
                    case Tokens.larger:
                        left.GenCode();
                        if (left.type == 'i' && right.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        right.GenCode();
                        if (left.type == 'd' && right.type == 'i')
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode("cgt");
                        break;
                    case Tokens.largere:
                        left.GenCode();
                        if (left.type == 'i' && right.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        right.GenCode();
                        if (left.type == 'd' && right.type == 'i')
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode("clt");
                        Compiler.EmitCode("ldc.i4.0");
                        Compiler.EmitCode("ceq");
                        break;
                    case Tokens.smaller:
                        left.GenCode();
                        if (left.type == 'i' && right.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        right.GenCode();
                        if (left.type == 'd' && right.type == 'i')
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode("clt");
                        break;
                    case Tokens.smallere:
                        left.GenCode();
                        if (left.type == 'i' && right.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        right.GenCode();
                        if (left.type == 'd' && right.type == 'i')
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode("cgt");
                        Compiler.EmitCode("ldc.i4.0");
                        Compiler.EmitCode("ceq");
                        break;
                    case Tokens.lor:
                        string shortenplace1 = Compiler.GetJump();
                        string endplace1 = Compiler.GetJump();
                        left.GenCode();
                        Compiler.EmitCode($"brtrue {shortenplace1}");
                        right.GenCode();
                        Compiler.EmitCode($"brtrue {shortenplace1}");
                        Compiler.EmitCode($"ldc.i4.0");
                        Compiler.EmitCode($"br {endplace1}");
                        Compiler.EmitCode($"{shortenplace1}: ldc.i4.1");
                        Compiler.EmitCode($"{endplace1}: nop");
                        break;
                    case Tokens.land:
                        string shortenplace2 = Compiler.GetJump();
                        string endplace2 = Compiler.GetJump();
                        left.GenCode();
                        Compiler.EmitCode($"brfalse {shortenplace2}");
                        right.GenCode();
                        Compiler.EmitCode($"brfalse {shortenplace2}");
                        Compiler.EmitCode($"ldc.i4.1");
                        Compiler.EmitCode($"br {endplace2}");
                        Compiler.EmitCode($"{shortenplace2}: ldc.i4.0");
                        Compiler.EmitCode($"{endplace2}: nop");
                        break;
                    case Tokens.assign:
                        string varName = left.name;
                        int num = (int)((object[])Compiler.symbols[varName])[1];
                        right.GenCode();
                        if (right.type == 'i' && left.type == 'd')
                            Compiler.EmitCode("conv.r8");
                        Compiler.EmitCode($"stloc {num}");
                        Compiler.EmitCode($"ldloc {num}");
                        break;
                }
            }
            return true;
        }
    }
}
