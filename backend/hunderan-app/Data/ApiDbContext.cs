using System;
using hunderan_app.Model;
using Microsoft.EntityFrameworkCore;

namespace hunderan_app.Data
{
    public class ApiDbContext :DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
        {

        }

        public DbSet<Dict> Dicts { get; set; }


    }
}




