using StoryParser.Setting;
using System.Numerics;
using SaveData = StoryParser.Archive.SaveData;
namespace Data
{
    public record struct Rect
    {
        public Rect(string parameter)
        {
            string[] infos = parameter.Split(Seperators.parameter);
            Up = float.Parse(infos[0]);
            Down = float.Parse(infos[1]);
            Left = float.Parse(infos[2]);
            Right = float.Parse(infos[3]);
        }
        public Rect(float up, float down, float left, float right)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }
        public float Up, Down, Left, Right;
    }
    public record struct ImageInfo
    {
        public ImageInfo(string parameter)
        {
            string[] infos = parameter.Split(Seperators.parameter);
            Bounds = new Rect(float.Parse(infos[0]), float.Parse(infos[1]), float.Parse(infos[2]), float.Parse(infos[3]));
            Alpha = infos.Length > 4 ? float.Parse(infos[4]) : 0;
            Angle = infos.Length > 5 ? float.Parse(infos[5]) : 0;
        }
        public ImageInfo(float up, float down, float left, float right, float alpha = 0, float angle = 0)
        {
            Bounds = new Rect(up, down, left, right);
            Alpha = alpha;
            Angle = angle;
        }
        public Rect Bounds;
        public float Alpha, Angle;
    }
    public record struct Condition
    {
        public Condition(string parameter)
        {
            string[] infos = parameter.Split(Seperators.signals);
            variable = infos[0];
            if (infos.Length == 2)
            {
                signal = parameter.Contains('>') ? '>' : '<';
                value = int.Parse(infos[1]);
            }
        }
        private string variable;
        private char? signal;
        private int? value;

        public static implicit operator bool(Condition condition)
        {
            if (condition.signal is null)
                return SaveData.TryGetVariable(condition.variable, out _);
            else if (SaveData.TryGetVariable(condition.variable, out int value))
                return condition.signal == '>' ? value > condition.value : value < condition.value;
            return false;
        }
    }
    public record struct Conditions
    {
        public Conditions(string parameter)
        {
            list = new();
            foreach (string info in parameter.Split(Seperators.parameter))
                list.Add(new Condition(info));
        }
        private List<Condition> list;
        public static implicit operator bool(Conditions conditions)
        {
            foreach (var condition in conditions.list)
                if (!condition)
                    return false;
            return true;
        }
    }
}
