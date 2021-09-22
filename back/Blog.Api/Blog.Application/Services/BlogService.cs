using Blog.Domain;
using Blog.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class BlogService: IBlogService
    {
        private IBlogRepository _repository;

        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TestTableDto>> GetTestTablesAsync()
        {
            var testTables = await _repository.GetTestTablesAsync();
            return testTables;
        }
    }
}
