using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teste.Models;
using Teste.Repository;
using Teste.Services;

namespace Teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly ITesteRepository testeRepository;
        private readonly IAddConsultaService AddConsultaService;
        public PacienteController(ITesteRepository testeRepository, IAddConsultaService AddConsultaService)
        {
            this.testeRepository = testeRepository;
            this.AddConsultaService = AddConsultaService;
        }

        [HttpGet]
        public ActionResult GetConsultas()
        {
            return Ok(testeRepository.GetConsultas());
        }

        [HttpGet("{name}")]
        public ActionResult GetConsultasByPaciente(string name)
        {
            return Ok(testeRepository.GetConsultasByPaciente(name));
        }

        [HttpPost]
        public ActionResult<Consulta> AddConsulta(Consulta consulta)
        {
            string ConsultaValid = AddConsultaService.ValidarConsulta(consulta);
            if (ConsultaValid == "Ok")
            {
                var result = AddConsultaService.AddConsulta(consulta);

                return CreatedAtAction(nameof(AddConsulta),
                             new { id = result }, result);
            }
            else
            {
                return BadRequest(new { message = ConsultaValid });
            }

        }

    }
}
