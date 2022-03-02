using Microsoft.EntityFrameworkCore;

namespace Teste.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        //o DBset usa o modelo do objeto e cria a DB com nome X
        // DBset<consultas> ConsultaDB cria uma table com campos de acordo com o model consultas
        // e dá a ela nome ConsultaDB
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        // Seeding Some Data
        // tudo abaixo daqui só serve pra popular uma DB inicial

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medico>().HasData(
                new Medico { Id = 1, Nome = "Rogerio" });
            modelBuilder.Entity<Medico>().HasData(
                new Medico { Id = 2, Nome = "Carlos" });
            modelBuilder.Entity<Medico>().HasData(
                new Medico { Id = 3, Nome = "Alberto" });

            modelBuilder.Entity<Paciente>().HasData(
                new Paciente { Id = 1, Nome = "Carla" });
            modelBuilder.Entity<Paciente>().HasData(
                new Paciente { Id = 2, Nome = "Rosana" });
            modelBuilder.Entity<Paciente>().HasData(
                new Paciente { Id = 3, Nome = "Maria" });
             
        }
    }
}
