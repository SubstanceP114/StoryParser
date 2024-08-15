namespace StoryParser.Extension.Util
{
    public readonly struct Condition
    {
        public Condition(string variable)
        {
            Variable = variable;
        }
        public Condition(string variable, char signal, int value)
        {
            Variable = variable;
            Signal = signal;
            Value = value;
        }
        public readonly string Variable;
        public readonly char? Signal;
        public readonly int? Value;
    }
}
