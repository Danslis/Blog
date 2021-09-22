using Blog.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public interface ITestService
    {
        Task<IEnumerable<TestTable>> GetTestTablesAsync();
    }
}
