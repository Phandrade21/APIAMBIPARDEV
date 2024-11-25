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
            modelBuilder.Entity<Ocorrencia>()
              .HasOne(o => o.ResponsavelAbertura)
              .WithMany(c => c.OcorrenciasAbertas)
              .HasForeignKey(o => o.ResponsavelAberturaId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ocorrencia>()
                .HasOne(o => o.ResponsavelOcorrencia)
                .WithMany(c => c.OcorrenciasResponsaveis)
                .HasForeignKey(o => o.ResponsavelOcorrenciaId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

          
        }

    }

}
