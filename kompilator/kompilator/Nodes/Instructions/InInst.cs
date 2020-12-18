namespace CompilerSpace
{
    class InInst : SyntaxTree
    {
        private Ident id;

        public InInst(Ident _id, int _line) { id = _id; line = _line; }

        public override string CheckName()
        {
            id.CheckName();
            name = "";
            return name;
        }

        public override char CheckType()
        {
            char idType = id.CheckType();
            if (idType != 'b' && idType != 'i' && idType != 'd')
            {
                string expected = Compiler.GetType('i') + " or " + Compiler.GetType('d') + " or " + Compiler.GetType('b');
                string got = Compiler.GetType(idType);
                Compiler.errors++;
                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
            }
            type = ' ';
            return type;
        }

        public override int GetStackSize()
        {
            int stack = 0;
            switch (id.type)
            {
                case 'i':
                    stack = 1;
                    break;
                case 'd':
                    stack = 2;
                    break;
                case 'b':
                    stack = 1;
                    break;
            }
            return stack;
        }

        public override bool GenCode()
        {
            string num = ((int)((object[])Compiler.symbols[id.name])[1]).ToString();
            switch (id.type)
            {
                case 'i':
                    Compiler.EmitCode("call string [mscorlib]System.Console::ReadLine()");
                    Compiler.EmitCode("call int32 [mscorlib]System.Int32::Parse(string)");
                    Compiler.EmitCode($"stloc {num}");
                    break;
                case 'd':
                    Compiler.EmitCode("call string [mscorlib]System.Console::ReadLine()");
                    Compiler.EmitCode("call class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()");
                    Compiler.EmitCode("call float64 [mscorlib]System.Double::Parse(string, class [mscorlib]System.IFormatProvider)");
                    Compiler.EmitCode($"stloc {num}");
                    break;
                case 'b':
                    Compiler.EmitCode("call string [mscorlib]System.Console::ReadLine()");
                    Compiler.EmitCode("call bool [mscorlib]System.Boolean::Parse(string)");
                    Compiler.EmitCode($"stloc {num}");
                    break;
            }
            return false;
        }
    }
}
