using Blog.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public interface IBlogService
    {
        Task<IEnumerable<TestTableDto>> GetTestTablesAsync();
    }
}
