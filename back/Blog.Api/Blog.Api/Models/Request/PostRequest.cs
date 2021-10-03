using System;

namespace Blog.Api.Models.Request
{
    public class PostRequest
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}
