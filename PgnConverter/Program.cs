using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;
using Procesamiento;

namespace PgnConverter
{
    class Program
    {
        static void Main(string[] args)
        {
           AppSettings appSettings = Config.AppSettings;
           Proceso proceso = new Proceso(appSettings.PathArchivos) ;
           proceso.Procesar();


        }
    }
}
