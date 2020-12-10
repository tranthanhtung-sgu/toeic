using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.User;
using Newtonsoft.Json;

namespace ToeicOnlineAdminApp.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient(clientHandler);
            // var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("/api/user/authenticate", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }
    }
}
