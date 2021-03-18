using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace clean_sharp
{
    public class Program
    {

        public static void Main(string[] args)
        {
            LandingGatewayInjector.Instancia.fetch = new LandingUseCase(new LandingRepositoryImpl("https://pokeapi.co/api/v2/"));
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
