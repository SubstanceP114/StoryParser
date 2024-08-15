namespace StoryParser.Extension.Util
{
    public interface IDataProvider
    {
        bool TryGetInt(string key, out int value);
        void SetInt(string key, int value);
        bool TryGetString(string key, out int value);
        void SetString(string key, string value);
    }
}
