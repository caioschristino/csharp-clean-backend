using System.Net.Http;
using Refit;

namespace clean_sharp
{
    class LandingRepositoryImpl : BaseRepository, LandingRepository
    {
        protected string baseUrl { get; set; }

        public LandingRepositoryImpl(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public Landing doFetch()
        {
             var service = RestService.For<PokedexAPI>(baseUrl);

            var httpclient = new HttpClient(){
                BaseAddress = new System.Uri(baseUrl)
            };
            var result = httpclient.GetStringAsync("pokemon")
                .GetAwaiter().GetResult;
                        
            return result;
        }

        public override PokedexAPI getService()
        {
            return new PokedexAPIBuilder(baseUrl)
            .build();
        }
    }
}