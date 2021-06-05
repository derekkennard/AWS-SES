// Created by Derek Kennard
// Solution: SES
// Project Name: SES
// File Name: Program.cs
// Created on: 03/14/2021 at 11:43 PM
// Edited on: 06/05/2021 at 1:22 PM
// Developed and Copyrighted by Derek "Doctork" Kennard

#region imports

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

#endregion

namespace SES
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}