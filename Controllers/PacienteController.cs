using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teste.Models;
using Teste.Repository;

namespace Teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly ITesteRepository testeRepository;
        public PacienteController(ITesteRepository testeRepository)
        {
            this.testeRepository = testeRepository;
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
            try
            {
                var LastConsulta = testeRepository.LastConsulta(consulta);
                var NextConsulta = testeRepository.NextConsulta(consulta);

                if (LastConsulta == null &&  NextConsulta == null)
                {
                    var createdConsulta = testeRepository.AddConsulta(consulta);

                    return CreatedAtAction(nameof(AddConsulta),
                        new { id = createdConsulta}, createdConsulta);
                }
                else
                {
                return NotFound();
                }


            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }


    }
}
