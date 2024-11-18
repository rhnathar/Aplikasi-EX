using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Aplikasi_EX
{
    public static class ConfigurationHelper
    {
        private static IConfiguration _configuration;

        public static IConfiguration GetConfiguration()
        {
            if (_configuration == null)
            {
                // Read embedded appsettings.json
                string json = LoadEmbeddedAppSettings();

                // Create a temporary JSON file in memory
                using (var stream = new MemoryStream())
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(json);
                    writer.Flush();
                    stream.Position = 0;

                    var builder = new ConfigurationBuilder()
                        .AddJsonStream(stream);

                    _configuration = builder.Build();
                }
            }

            return _configuration;
        }

        public static string GetConnectionString(string name = "DefaultConnection")
        {
            return GetConfiguration().GetConnectionString(name);
        }

        private static string LoadEmbeddedAppSettings()
        {
            // Replace this with your actual namespace and file structure
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("Aplikasi_EX.db.appsettings.json"))
            {
                if (stream == null)
                    throw new FileNotFoundException("Embedded appsettings.json not found.");

                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();

                    // TODO: Add decryption logic here if needed
                    return json;
                }
            }
        }
    }
}
