using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIConsumptionApp
{
    public class CommentService
    {
        private HttpClient _httpClient;

        public CommentService()
        {
            _httpClient = new HttpClient();
        }

        // Get comments for a post ID asynchronously
        public async Task<List<Comment>> GetPostCommentsAsync(int postId)
        {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            // Ensure the content is not null before deserialization
            if (content != null)
            {
                var comments = JsonConvert.DeserializeObject<List<Comment>>(content);
                return comments!;
            }
        
            // If content is null, return an empty list or handle it as appropriate
            return new List<Comment>();
        }
    }
}
