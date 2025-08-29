using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace XUnitTestProject.TestClasses
{
    public class PostIdsData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data;

        public PostIdsData()
        {
            _data = LoadPostIds().GetAwaiter().GetResult();
        }

        private static async Task<List<object[]>> LoadPostIds()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://dummyjson.com/posts");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // case-insensitive deserialization (نمیاد API اگر نباشه دیتا از)
            var wrapper = JsonSerializer.Deserialize<PostResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var list = new List<object[]>();
            if (wrapper?.Posts != null)
            {
                foreach (var post in wrapper.Posts)
                {
                    list.Add(new object[] { post.Id });
                }
            }
            return list;
        }

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class PostResponse
        {
            public List<Post> Posts { get; set; }
        }

        public class Post
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
        }
    }
}
