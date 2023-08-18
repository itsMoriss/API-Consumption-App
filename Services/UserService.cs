using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIConsumptionApp
{
    public class UserService
    {
        private HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        // Get a list of users asynchronously
        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            // Ensure the content is not null before deserialization
            if (content != null)
            {
                var users = JsonConvert.DeserializeObject<List<User>>(content);
                return users!;
            }
        
            // If content is null, return an empty list or handle it as appropriate
            return new List<User>();
        }
    }
}
