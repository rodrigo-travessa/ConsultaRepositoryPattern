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
        public DbSet<Consulta> ConsultaDB { get; set; }
        public DbSet<Medico> MedicosDB { get; set; }
        public DbSet<Paciente> PacientesDB { get; set; }

        // Seeding Some Data
        // tudo abaixo daqui só serve pra popular uma DB inicial

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medico>().HasData(
                new Medico { MedicoID = 1, MedicoName = "Rogerio" });
            modelBuilder.Entity<Medico>().HasData(
                new Medico { MedicoID = 2, MedicoName = "Carlos" });
            modelBuilder.Entity<Medico>().HasData(
                new Medico { MedicoID = 3, MedicoName = "Alberto" });

            modelBuilder.Entity<Paciente>().HasData(
                new Paciente { PacienteID = 1, PacienteName = "Carla" });
            modelBuilder.Entity<Paciente>().HasData(
                new Paciente { PacienteID = 2, PacienteName = "Rosana" });
            modelBuilder.Entity<Paciente>().HasData(
                new Paciente { PacienteID = 3, PacienteName = "Maria" });
             
        }
    }
}
