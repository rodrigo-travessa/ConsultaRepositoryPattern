using Microsoft.AspNetCore.Mvc;
using Teste.Models;

namespace Teste.Services
{
    public interface IAddConsultaService
    {
        Consulta? AddConsulta(Consulta consulta);
        public Consulta NextConsulta(Consulta consulta);
        public Consulta LastConsulta(Consulta consulta);
    }
}
