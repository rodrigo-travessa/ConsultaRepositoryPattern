using Teste.Models;

namespace Teste.RepoPattern.Repositories
{
    public class PacienteRepository : Repository<Paciente>
    {
        public PacienteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
