using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Teste.Models;
using Teste.RepoPattern;

namespace Teste.Services
{
    public class ConsultaService : Service<Consulta>, IConsultaService
    {
        
        public ConsultaService(IConsultaRepository _repository) : base(_repository)
        {
        }

        public override List<Consulta> GetAllService()
        {
            return _repository.GetAll().ToList();
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
