using ColaboradoresNovos.Models;
using Microsoft.EntityFrameworkCore;

namespace ColaboradoresNovos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ColaboradoresModel> colaboradores { get; set; }
    }
}

