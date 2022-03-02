using Teste.Models;
using Teste.RepoPattern;
using Teste.RepoPattern.Services.Implementations;

namespace Teste.Services
{
    public class MedicoService : Service<Medico>, IMedicoService
    {
        private readonly IMedicoRepository _repository;

        public MedicoService(IMedicoRepository repository) : base(repository)
        {

        }


    }
}
