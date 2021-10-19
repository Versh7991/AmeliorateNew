using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

                try
                {

                    //  Specify a directory name that does not exist for this demo.
                    string dir = @"c:\78fe9lk";

                    // If this directory does not exist, a DirectoryNotFoundException is thrown
                    // when attempting to set the current directory.
                    Directory.SetCurrentDirectory(dir);
                }
                catch (DirectoryNotFoundException dirEx)
                {
                    // Let the user know that the directory did not exist.
                    Console.WriteLine("Directory not found: " + dirEx.Message);
                }
            }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
