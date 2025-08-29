using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class SecondPostIdData : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new();

    public SecondPostIdData()
    {
        // اجرای async درست بدون deadlock
        _data = LoadPostIds().GetAwaiter().GetResult();
    }

    private static async Task<List<object[]>> LoadPostIds()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        var posts = JsonSerializer.Deserialize<List<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        var list = new List<object[]>();
        if (posts != null)
        {
            foreach (var post in posts)
            {
                list.Add(new object[] { post.Id });
            }
        }

        return list;
    }

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class Post
    {
        public int Id { get; set; }
    }
}
