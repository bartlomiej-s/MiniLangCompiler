using System.Globalization;

namespace CompilerSpace
{
    class DoubleVal : SyntaxTree
    {
        private double val;

        public DoubleVal(double _val, int _line) { val = _val; line = _line; }

        public override string CheckName()
        {
            name = val.ToString(CultureInfo.InvariantCulture);
            return name;
        }

        public override char CheckType()
        {
            type = 'd';
            return type;
        }

        public override int GetStackSize()
        {
            return 1;
        }

        public override bool GenCode()
        {
            Compiler.EmitCode($"ldc.r8 {name}");
            return true;
        }
    }
}
