using Microsoft.AspNetCore.Mvc;
using Teste.Models;

namespace Teste.Services
{
    public interface IAddConsultaService
    {
        bool AddConsulta(Consulta consulta);
    }
}
