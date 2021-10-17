using Blog.Domain;
using Blog.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class TestService : ITestService
    {
        private ITestRepository _repository;

        public TestService(ITestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TestTable>> GetTestTablesAsync()
        {
            var testTables = await _repository.GetTestTablesAsync();
            return testTables;
        }
    }
}
