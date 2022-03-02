using System.Collections.Generic;
using Teste.Models;
using Teste.RepoPattern.Services.Interfaces;


namespace Teste.Services
{
    public interface IConsultaService : IService<Consulta>
    {
        List<Consulta> BuscarConsultasPorMedico(int id);
        List<Consulta> BuscarConsultasPorPaciente(int id);
    }
}
