using Refit;

namespace clean_sharp
{
    class PokedexAPIBuilder : AbstractBuilder<PokedexAPI>
    {
        public PokedexAPIBuilder(string baseUrl) : base(baseUrl)
        {


        }

        public override PokedexAPI build()
        {
            var service = RestService
                    .For<PokedexAPI>(createHttpClient());
            return service;
        }
    }
}