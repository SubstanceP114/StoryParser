namespace StoryParser.Setting
{
    public static class Global
    {
        /// <summary>
        /// 存档路径，指向存档文件
        /// </summary>
        public static string ArchivePath { get; set; } = @"\SaveData.json";
        public static readonly string DefaultFolderName = "Default";
    }
}
