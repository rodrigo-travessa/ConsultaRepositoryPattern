using System.Collections.Generic;
using Teste.Models;

namespace Teste.Repository
{
    public interface IMedicoRepository
    {
        IEnumerable<Consulta> BuscarConsultas();
        IEnumerable<Consulta> BuscarConsultasPorMedico(string MedicoName);
        IEnumerable<Consulta> BuscarConsultasPorMedicoID(int MedicoID);  
        Consulta AddConsulta(Consulta consulta);
        void DeletarConsulta(int consultaid);
    }
}
