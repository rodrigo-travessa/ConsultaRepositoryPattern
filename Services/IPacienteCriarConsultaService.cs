using Teste.Models;
#nullable enable

namespace Teste.Services
{
    public interface IPacienteCriarConsultaService
    {
        Consulta? AddConsulta(Consulta consulta);
        public Consulta NextConsulta(Consulta consulta);
        public Consulta LastConsulta(Consulta consulta);
        public string ValidarConsulta(Consulta consulta);
    }
}
