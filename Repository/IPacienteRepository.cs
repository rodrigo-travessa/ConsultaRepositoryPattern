using System.Collections.Generic;
using Teste.Models;

namespace Teste.Repository
{
    public interface IPacienteRepository
    {
        IEnumerable<Consulta> BuscarConsultas();
        IEnumerable<Consulta> BuscarConsultasPorPaciente(string PacienteName);
        IEnumerable<Consulta> BuscarConsultasPorPacienteID(int PacienteID);
        Consulta AddConsulta(Consulta consulta);
        void DeletarConsulta(int consultaid);

    }
}
