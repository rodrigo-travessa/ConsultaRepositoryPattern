using Teste.Models;
using Teste.RepoPattern;


namespace Teste.Services
{
    public class PacienteService : Service<Paciente>, IPacienteService
    {
        private readonly IMedicoRepository _repository;

        public PacienteService(IPacienteRepository repository) : base(repository)
        {

        }


    }
}
