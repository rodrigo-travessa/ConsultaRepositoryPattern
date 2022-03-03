using Teste.Models;

namespace Teste.RepoPattern.Repositories
{
    public class PacienteRepository : Repository<Paciente> , IPacienteRepository
    {
        public PacienteRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
