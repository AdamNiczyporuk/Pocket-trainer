using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Spectre.Console.Rendering;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

namespace KCK_Project__Console_Pocket_trainer_.Repositories
{
    internal class API
    {
        
        private readonly HttpClient _httpClient;
        private string apiKey;
        private string LoadApiKey()
        {
            // Zakładamy, że plik z kluczem znajduje się w katalogu roboczym
            StreamReader sr = new StreamReader("D:\\AAAAAAAANAUKA\\AAStudia\\SEMESTR5\\KCK\\KCK_Project_ Console(Pocket trainer)\\config.txt");
            String line = sr.ReadLine();
            

            return  line;
        }


        public API()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetExerciseData(string muscle)
        {
            string apiUrl = $"https://api.api-ninjas.com/v1/exercises?muscle={muscle}";
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            string APIKey=LoadApiKey();
            request.Headers.Add("X-Api-Key", APIKey);

            try
            {
                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    // Jeśli odpowiedź jest poprawna, zwróć treść odpowiedzi
                    var jsonResponse= await response.Content.ReadAsStringAsync();

                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Jeśli kod odpowiedzi nie jest OK, zwróć szczegóły błędu
                    return $"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}";
                }
            }
            catch (Exception ex)
            {
                // Obsługa wyjątków w przypadku problemów z zapytaniem
                return $"Exception occurred: {ex.Message}";
            }
        }
    }
}
