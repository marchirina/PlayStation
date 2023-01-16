﻿using Microsoft.Extensions.Configuration;

namespace PlayStation.Configurations
{
    public class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }

        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Configurations/testsettings.json")
                    .Build();
        }
    }
}