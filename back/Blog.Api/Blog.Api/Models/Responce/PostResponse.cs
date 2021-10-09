using System;

namespace Blog.Api.Models.Responce
{
    public class PostResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}
