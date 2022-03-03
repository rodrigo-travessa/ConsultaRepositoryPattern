using System.Collections.Generic;
using Teste.Models;


namespace Teste.Services
{
    public interface IConsultaService : IService<Consulta>
    {
        List<Consulta> BuscarConsultasPorMedico(int id);
        List<Consulta> BuscarConsultasPorPaciente(int id);
    }
}
