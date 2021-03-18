using System.Net.Http;

public abstract class AbstractBuilder<R> 
    where R : class 
{
    protected string baseUrl { get; set; }

    public AbstractBuilder(string baseUrl){
        this.baseUrl = baseUrl;
    }

    public HttpClient createHttpClient(){
        return new HttpClient(){
            BaseAddress = new System.Uri(baseUrl)
        };
    }

    public abstract R build();
}