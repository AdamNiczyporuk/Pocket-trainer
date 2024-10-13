using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Repositories
{
    internal class API
    {
        private readonly HttpClient _httpClient;

        public API()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetExerciseData(string muscle)
        {
            string apiUrl = $"https://api.api-ninjas.com/v1/exercises?muscle={muscle}";
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            request.Headers.Add("X-Api-Key", "YOUR_API_KEY");

            try
            {
                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    // Jeśli odpowiedź jest poprawna, zwróć treść odpowiedzi
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
