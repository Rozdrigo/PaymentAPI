using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Infrastructure.Services
{
    public class NotificationServiceResponseMessage
    {
        public bool message { get; set; }
    }
    public class NotificationService
    {
        public static async Task<bool> SendNotificationAsync(string email)
        {
            using var httpClient = new HttpClient();
            string url = "https://run.mocky.io/v3/54dc2cf1-3add-45b5-b5a9-6bf7e7f1f4a6";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                NotificationServiceResponseMessage content = await response.Content.ReadFromJsonAsync<NotificationServiceResponseMessage>();
                bool message = content.message;

                if (message)
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
