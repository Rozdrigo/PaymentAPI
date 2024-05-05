using System.Text.Json;
using System;
using System.Net.Http.Json;

namespace PaymentAPI.Infrastructure.Services
{
    public class AuthorizationServiceResponseMessage
    {
        public string message { get; set; }
    }
    public class AuthorizationService
    {
        public static async Task<bool> AuthorizePaymentAsync()
        {
            using var httpClient = new HttpClient();

            string url = "https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                AuthorizationServiceResponseMessage content = await response.Content.ReadFromJsonAsync<AuthorizationServiceResponseMessage>();
                string message = content.message;

                if (message == "Autorizado")
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
