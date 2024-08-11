using StoryParser.Setting;
using SaveData = StoryParser.Archive.SaveData;
namespace Data
{
    public struct Rect
    {
        public Rect(string parameter)
        {
            string[] infos = parameter.Split(Seperators.parameter);
            up = float.Parse(infos[0]);
            down = float.Parse(infos[1]);
            left = float.Parse(infos[2]);
            right = float.Parse(infos[3]);
        }
        public Rect(float up, float down, float left, float right)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
        }
        public float up, down, left, right;
    }
    public struct ImageInfo
    {
        public ImageInfo(string parameter)
        {
            string[] infos = parameter.Split(Seperators.parameter);
            bounds = new Rect(float.Parse(infos[0]), float.Parse(infos[1]), float.Parse(infos[2]), float.Parse(infos[3]));
            alpha = infos.Length > 4 ? float.Parse(infos[4]) : 0;
            angle = infos.Length > 5 ? float.Parse(infos[5]) : 0;
        }
        public ImageInfo(float up, float down, float left, float right, float alpha = 0, float angle = 0)
        {
            bounds = new Rect(up, down, left, right);
            this.alpha = alpha;
            this.angle = angle;
        }
        public Rect bounds;
        public float alpha, angle;
    }
    public struct Condition
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
    public struct Conditions
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
