using AutoMapper;
using Blog.DataAccess.Context;
using Blog.Domain;
using Blog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repositories
{
    public class BlogRepository: IBlogRepository
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public BlogRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestTable>> GetTestTablesAsync()
        {
            var testTables = await _context.TestTable.ToListAsync();
            return _mapper.Map<IEnumerable<TestTable>>(testTables);
        }
    }
}
