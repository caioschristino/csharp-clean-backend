using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace clean_sharp
{
    public class Program
    {

        public static void Main(string[] args)
        {
            LandingGatewayInjector.Instancia.fetch = new LandingUseCase(new LandingRepositoryImpl());
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
