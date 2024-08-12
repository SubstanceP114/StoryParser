namespace StoryParser.Setting
{
    public static class Global
    {
        /// <summary>
        /// 文字显示时间间隔
        /// </summary>
        public static float TextInterval { get; set; } = .02f;
        /// <summary>
        /// 淡入淡出特效时间
        /// </summary>
        public static float FadeTime { get; set; } = 1f;
        /// <summary>
        /// 存档路径，指向存档文件
        /// </summary>
        public static string ArchivePath { get; set; } = @"\SaveData.json";
        public static readonly string DefaultFolderName = "Default";
    }
}
