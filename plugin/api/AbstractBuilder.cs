using System.Net.Http;
using System.Threading.Tasks;

abstract class AbstractBuilder<R> where R : class{
    protected string baseUrl { get; set; }
    protected DelegatingHandler interceptor { get; set; }

    public AbstractBuilder(string baseUrl, DelegatingHandler interceptor){
        this.baseUrl = baseUrl;
        this.interceptor = interceptor;
    }

    public HttpClient createHttpClient() { 
        return new HttpClientHandler(baseUrl, interceptor).httpClient;
    }
}

class HttpClientHandler : IHttpHandler
{
    public HttpClient httpClient;
    
    public HttpClientHandler(string baseUrl, DelegatingHandler interceptor){
        this.httpClient = new HttpClient(interceptor){
            BaseAddress = new System.Uri(baseUrl)
        };
    }

    public HttpResponseMessage Get(string url)
    {
        return GetAsync(url).Result;
    }

    public HttpResponseMessage Post(string url, HttpContent content)
    {
        return PostAsync(url, content).Result;
    }

    private async Task<HttpResponseMessage> GetAsync(string url)
    {
        return await httpClient.GetAsync(url);
    }

    private async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
    {
        return await httpClient.PostAsync(url, content);
    }

    public HttpRequestException execute()
    {
        throw new System.NotImplementedException();
    }
}

public interface IHttpHandler
{
    HttpRequestException execute();
}

