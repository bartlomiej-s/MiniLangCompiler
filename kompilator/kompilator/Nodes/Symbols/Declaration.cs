using System;

namespace CompilerSpace
{
    class Declaration : SyntaxTree
    {
        private Ident id;
        private TypeVal typestmt;

        public Declaration(TypeVal _typestmt, Ident _id, int _line) { typestmt = _typestmt; id = _id; line = _line; }

        public override string CheckName()
        {
            string identID = id.SetName();
            string typeName = typestmt.CheckName();
            if (!Compiler.symbols.Contains(identID))
            {
                Compiler.symbols.Add(identID, new object[2] { typeName, -1 });
            }
            else
            {
                Compiler.errors++;
                Compiler.SaveError($"Variable already declared", ErrorType.Semantic, line);
            }
            name = "";
            return name;
        }

        public override char CheckType()
        {
            char typeName = Convert.ToChar(typestmt.name);
            if (typeName != 'b' && typeName != 'i' && typeName != 'd')
            {
                string expected = Compiler.GetType('i') + " or " + Compiler.GetType('d') + " or " + Compiler.GetType('b');
                string got = Compiler.GetType(typeName);
                Compiler.errors++;
                Compiler.SaveError($"Wrong type, expected: {expected}, got: {got}", ErrorType.Semantic, line);
            }
            id.type = typeName;
            typestmt.CheckType();
            type = ' ';
            return type;
        }

        public override int GetStackSize()
        {
            return 0;
        }

        public override bool GenCode()
        {
            string varName = id.name;
            string var = Compiler.GetVarName(varName);

            string typeName = null;
            switch (Convert.ToChar(typestmt.name))
            {
                case 'i':
                    typeName = "int32";
                    break;
                case 'd':
                    typeName = "float64";
                    break;
                case 'b':
                    typeName = "bool";
                    break;
            }

            Compiler.EmitCode($".locals init ( {typeName} {var} )");

            ((object[])Compiler.symbols[varName])[1] = Compiler.GetVarId();

            return false;
        }
    }
}
