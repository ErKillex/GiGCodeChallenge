using GiGCodeChallenge.Tests.Models;
using Newtonsoft.Json;
using System.IO;

namespace GiGCodeChallenge.Tests.Helpers
{
    internal class Configuration
    {
        protected readonly string defaultFileName = "Configuration.json";
        internal AppSettings AppSettings { get; private set; }

        internal Configuration()
        {
            var currentPath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            var fullPath = Path.Combine(currentPath, defaultFileName);
            this.AppSettings = LoadSettings(fullPath);
        }
        internal Configuration(string fullFilePath)
        {
            this.AppSettings = LoadSettings(fullFilePath);
        }

        private AppSettings LoadSettings(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            return JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(filePath));
        }
    }
}
