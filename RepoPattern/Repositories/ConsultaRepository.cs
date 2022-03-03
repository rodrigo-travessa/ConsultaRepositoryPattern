using Microsoft.EntityFrameworkCore;
using System.Linq;
using Teste.Models;

namespace Teste.RepoPattern.Repositories
{
    public class ConsultaRepository : Repository<Consulta> , IConsultaRepository
    {
        public ConsultaRepository(AppDbContext _appDbContext) : base(_appDbContext)
        {
        }

        public override IQueryable<Consulta> GetAll()
        {
            return appDbContext.Set<Consulta>().Include(x => x.Medico).Include(x => x.Paciente);                
        }
    }
}
