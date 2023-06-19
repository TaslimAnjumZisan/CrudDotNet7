using CrudDotNet7.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudDotNet7.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   

        }
        public DbSet<Category> Categorie { get; set; }
    }
}
