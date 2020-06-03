using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SEP3PresentationTier.Heartbeat;

namespace SEP3PresentationTier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var heartbeatClient = new HeartbeatClient("127.0.0.1", 2020);
            Thread instanceCaller = new Thread(
                new ThreadStart(heartbeatClient.Run));
            
            instanceCaller.Start();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}