namespace CompilerSpace
{
    public struct ErrorData
    {
        public string str;
        public ErrorType type;
        public int line;
        public bool disableDash;

        public ErrorData(string _str, ErrorType _type, int _line, bool _disableDash)
        {
            str = _str;
            type = _type;
            line = _line;
            disableDash = _disableDash;
        }
    }
}
