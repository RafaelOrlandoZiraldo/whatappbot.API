using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using whatappbot.aplication.Interface;

namespace whatappbot.aplication.Services
{
    public class WhatAppService: IWhatAppService
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessToken = "EAAKJ1URgB7cBPuzBSZA58YjtnG7z9ZBjWZCLPl3Y1mcUD56vN6vcpNeFnssKm8OUGehYa5DQ7Y9XGsBZAh7EiDGf4GbVd4nZAbSdHtHMk6S9qegAclHAsmIiSMPXIxqkoaBvs6aY8hnF3OZC759ASqC6OsX9fcKcqbZCl98ZCjiz8P0Tqn66VmUTIoFZCvVnW9sdb9t6jSo17SNNa66njQzHs1QmuWBhedhtPbxot1XL3awZDZD";
        private readonly string _phoneNumberId = "764777896724417";

        public WhatAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendMessageAsync(string to, string message)
        {
            var url = $"https://graph.facebook.com/v23.0/{_phoneNumberId}/messages";
            var body = new
            {
                messaging_product = "whatsapp",
                to = to,
                type= "text",
                text = new { body = message }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Headers = { { "Authorization", $"Bearer {_accessToken}" } },
                Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Status: {response.StatusCode}");
            Console.WriteLine($"Response: {result}");
        }
        public async Task SendMessageViaTwilioAsync(string to, string message)
        {
            // Tus credenciales Twilio
            var accountSid = "ACe2ecf4b5238fa26d65562081257d51e9";
            var authToken = "4cea72dbf16aff605e5304717577060c";

            // Número de Twilio (sandbox o número propio)
            var from = "whatsapp:+14155238886"; // Número sandbox Twilio
            var toWhatsapp = to; // "+54XXXXXXXXXX"

            var url = $"https://api.twilio.com/2010-04-01/Accounts/{accountSid}/Messages.json";

            // Twilio usa form-url-encoded en vez de JSON
            var postData = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("From", from),
                new KeyValuePair<string, string>("To", toWhatsapp),
                new KeyValuePair<string, string>("Body", message)
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(postData)
            };

            // Autenticación básica con Account SID y Auth Token
            var byteArray = Encoding.ASCII.GetBytes($"{accountSid}:{authToken}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(byteArray)
            );

            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status: {response.StatusCode}");
            Console.WriteLine($"Response: {result}");
        }
    }
}
