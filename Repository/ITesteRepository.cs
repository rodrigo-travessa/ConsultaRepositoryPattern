using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.Repository
{
    public interface ITesteRepository
    {
        IEnumerable<Consulta> GetConsultas();
        IEnumerable<Consulta> GetConsultasByMedico(string MedicoName);
        IEnumerable<Consulta> GetConsultasByPaciente(string PacienteName);
        Consulta AddConsulta(Consulta consulta);
        void DeleteConsulta(int consultaid);
        Consulta NextConsulta(Consulta consulta);
        Consulta LastConsulta(Consulta consulta);
    }
}
