namespace CustomersSite.Clients
{
    public class HttpClientFactoryService
    {
        private readonly HttpClient _httpClient;
        public HttpClientFactoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44351/api/");

        }

    }
}
