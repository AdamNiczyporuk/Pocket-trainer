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
using KCK_Project__Console_Pocket_trainer_.Models;
using System.Collections.Generic;
using KCK_Project__Console_Pocket_trainer_.Data;

namespace APIS
{

    public class API
    {
        public static IConfiguration Configuration { get; private set; }
       

        private readonly HttpClient _httpClient;
        private string apiKey;
        private string LoadApiKey()
        {
            // Zakładamy, że plik z kluczem znajduje się w katalogu roboczym
            StreamReader sr = new StreamReader("D:\\AAAAAAAANAUKA\\AAStudia\\SEMESTR5\\KCK\\KCK_Project_ Console(Pocket trainer)\\config.txt");
            string line = sr.ReadLine();


            return line;
        }


        public API()
        {
            _httpClient = new HttpClient();
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory()) // Ustawienie ścieżki do katalogu wyjściowego
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Wczytanie pliku JSON

            Configuration = builder.Build();

            apiKey = Configuration["ExerciseApi:sApiKey"];
        }

        public async Task GetExerciseData(string muscle)
        {
            string apiUrl = $"https://api.api-ninjas.com/v1/exercises?muscle={muscle}";
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            string APIKey = LoadApiKey();
            request.Headers.Add("X-Api-Key", APIKey);

            try
            {
                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    // Jeśli odpowiedź jest poprawna, zwróć treść odpowiedzi
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine("Response JSON:");
                    //Console.WriteLine(jsonResponse);
                    var exercises = JsonConvert.DeserializeObject<List<Exercise>>(jsonResponse);
                    //return await response.Content.ReadAsStringAsync();
                    using (var context = new ApplicationDbContext())
                    {
                        foreach (var exercise in exercises)
                        {
                            context.Exercises.Add(exercise);
                        }
                        await context.SaveChangesAsync(); // Zapisuje zmiany do bazy danych
                    }

                    // Wyświetlenie pierwszego ćwiczenia jako przykład
                    Console.WriteLine("Exercises have been saved to the database.");
                }
                else
                {
                    // Jeśli kod odpowiedzi nie jest OK, zwróć szczegóły błędu
                    Console.WriteLine($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                // Obsługa wyjątków w przypadku problemów z zapytaniem
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
        }
    }
}
