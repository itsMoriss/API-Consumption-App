using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIConsumptionApp
{
    public class PostService
    {
        private HttpClient _httpClient;

        public PostService()
        {
            _httpClient = new HttpClient();
        }

        // Get posts by user ID asynchronously
        public async Task<List<Post>> GetUserPostsAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts?userId={userId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            // Ensure the content is not null before deserialization
            if (content != null)
            {
                var posts = JsonConvert.DeserializeObject<List<Post>>(content);
                return posts!;
            }
        
            // If content is null, return an empty list or handle it as appropriate
            return new List<Post>();
        }
    }
}
