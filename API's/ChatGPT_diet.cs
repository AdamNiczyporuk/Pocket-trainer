using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CHATAPI
{
    
    public class ChatGPT_diet
    {
        private static string apiKey;
        private static string apiURL;
        public static void SetUpSetting()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();
            
            apiKey = configuration["ChatApi:ApiKey"];
            apiURL = configuration["ChatApi:ApiUrl"];

        }
        public static async Task<string> SendRequestToChatGPT(string prompt)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestData = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                    new { role = "system", content = "Provide a 7-day diet plan based on the user's weight, height, and training sessions per week. Include only the diet plan; no introductory or concluding sentences." },
                    new { role = "user", content = prompt }
                },
                    max_tokens = 650,
                    temperature = 0.8
                };

                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiURL, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);
                    return jsonResponse.choices[0].message.content.ToString();
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
        }

    }
}
