using System;
using System.Threading.Tasks;

namespace APIConsumptionApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Initialize the services for user, post, and comment data retrieval
                UserService userService = new UserService();
                PostService postService = new PostService();
                CommentService commentService = new CommentService();

                // Get the list of users
                var users = await userService.GetUsersAsync();

                Console.WriteLine("Users:");
                foreach (var user in users)
                {
                    Console.WriteLine(user.Username);
                }

                Console.Write("Select a user by entering their username: ");
                var selectedUsername = Console.ReadLine();

                // Find the selected user
                var selectedUser = users.Find(user => user.Username == selectedUsername);
                if (selectedUser != null)
                {
                    // Get posts by the selected user
                    var userPosts = await postService.GetUserPostsAsync(selectedUser.Id);

                    Console.WriteLine($"\nPosts by {selectedUser.Username}:");
                    foreach (var post in userPosts)
                    {
                        Console.WriteLine($"Post ID: {post.Id}, Title: {post.Title}");
                    }

                    Console.Write("\nSelect a post by entering its ID: ");
                    var selectedPostId = Convert.ToInt32(Console.ReadLine());

                    // Find the selected post
                    var selectedPost = userPosts.Find(post => post.Id == selectedPostId);
                    if (selectedPost != null)
                    {
                        // Get comments for the selected post
                        var postComments = await commentService.GetPostCommentsAsync(selectedPost.Id);

                        Console.WriteLine($"\nComments for Post: {selectedPost.Title}");
                        foreach (var comment in postComments)
                        {
                            Console.WriteLine($"Comment ID: {comment.Id}, Name: {comment.Name}, Email: {comment.Email}");
                            Console.WriteLine($"Comment: {comment.Body}\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid post ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

