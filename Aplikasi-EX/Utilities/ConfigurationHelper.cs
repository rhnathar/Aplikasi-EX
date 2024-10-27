using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

public static class ConfigurationHelper
{
    public static IConfigurationRoot GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("db/appsettings.json", optional: false, reloadOnChange: true);
        return builder.Build();
    }

    public static string GetConnectionString(string name)
    {
        var configuration = GetConfiguration();
        return configuration.GetConnectionString(name);
    }
}
