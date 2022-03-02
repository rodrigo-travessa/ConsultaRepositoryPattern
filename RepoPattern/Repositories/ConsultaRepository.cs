using Teste.Models;

namespace Teste.RepoPattern.Repositories
{
    public class ConsultaRepository : Repository<Consulta>
    {
        public ConsultaRepository(AppDbContext context) : base(context)
        {

        }

    }
}
