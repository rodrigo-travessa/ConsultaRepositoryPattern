using Teste.Models;

namespace Teste.RepoPattern.Repositories
{
    public class MedicoRepository : Repository<Medico> , IMedicoRepository
    {
        public MedicoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }
    }
}
