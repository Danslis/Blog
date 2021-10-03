using Blog.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public interface IBlogRepository
    {
        Task<IEnumerable<TestTable>> GetTestTablesAsync();
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostById(long id);
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(Post post);
        Task<Post> DeletePost(long id);

    }
}
