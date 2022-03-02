using System.Collections.Generic;
using Teste.Models;
using Teste.RepoPattern;
using Teste.RepoPattern.Services.Implementations;

namespace Teste.Services
{
    public class ConsultaService : Service<Consulta>, IConsultaService
    {
        private readonly IConsultaRepository _repository;

        public ConsultaService(IConsultaRepository repository) : base(repository)
        {

        }

        public List<Consulta> BuscarConsultasPorMedico(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Consulta> BuscarConsultasPorPaciente(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
