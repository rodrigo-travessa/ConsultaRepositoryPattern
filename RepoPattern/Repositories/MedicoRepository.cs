using Teste.Models;

namespace Teste.RepoPattern.Repositories
{
    public class MedicoRepository : Repository<Medico>
    {
        public MedicoRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
