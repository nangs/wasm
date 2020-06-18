using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Sample.Server
{
    public class Program
    {
        public static void Main(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(x => x.UseStartup<Startup>());
    }
}
