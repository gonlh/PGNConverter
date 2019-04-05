using System.IO;
using Microsoft.Extensions.Configuration;

namespace PgnConverter
{
    public static class Config
    {
        private static  AppSettings appSettings;
        private static IConfiguration configuration;

        

        public static AppSettings AppSettings 
        {
            get
            {
                if(appSettings == null)
                {
                    appSettings = new AppSettings();
                    Configuration.GetSection("appSettings").Bind(appSettings);
                }
                return appSettings;
            }
        }

        public static IConfiguration Configuration
        {
            get 
            {
                if(configuration == null)
                {
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
        
                    configuration = builder.Build();
                }
                return configuration;
            }

        }

    }
}
