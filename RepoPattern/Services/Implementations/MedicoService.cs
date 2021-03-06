using Teste.Models;
using Teste.RepoPattern;

namespace Teste.Services
{
    public class MedicoService : Service<Medico>, IMedicoService
    {
        private readonly new IMedicoRepository _repository;

        public MedicoService(IMedicoRepository repository) : base(repository)
        {
        }




    }
}
