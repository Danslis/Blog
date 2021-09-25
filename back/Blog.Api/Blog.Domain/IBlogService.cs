﻿using Blog.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public interface IBlogService
    {
        Task<IEnumerable<TestTable>> GetTestTablesAsync();
    }
}
