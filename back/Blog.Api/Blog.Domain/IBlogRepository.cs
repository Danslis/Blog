using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain.Dto;

namespace Blog.Domain
{
    public interface IBlogRepository
    {
        Task<IEnumerable<TestTableDto>> GetTestTablesAsync();

    }
}
