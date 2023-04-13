using AppSolid.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AppSolid.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ArticleEntity> Article { get; set; }

    }
}
