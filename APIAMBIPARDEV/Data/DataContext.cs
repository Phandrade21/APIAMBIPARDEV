using APIAMBIPARDEV.Modelo;
using Microsoft.EntityFrameworkCore;

namespace APIAMBIPARDEV.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
        }

    }

}
