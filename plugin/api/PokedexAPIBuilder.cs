using System.Net.Http;

class PokedexAPIBuilder : AbstractBuilder<PokedexAPI>
{
    public PokedexAPIBuilder(string baseUrl, DelegatingHandler interceptor): base(baseUrl, interceptor) {


    }
}