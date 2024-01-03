using System;
using System.IO;

namespace MASMauiApp.Shared
{
    public static class SevicesBase
    {
        public const string ConfigFile = "apiconfigs.json";

        public static string ConfigFilePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, ConfigFile);
            }
        }

        public static Models.Users LOGGEDUSER;
    }
}
