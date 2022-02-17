using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;
using Teste.Repository;
using Teste.Services;

namespace Teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly ITesteRepository testeRepository;
        private readonly IAddConsultaService AddConsultaService;
        public MedicoController(ITesteRepository testeRepository, IAddConsultaService AddConsultaService)
        {
            this.testeRepository = testeRepository;
            this.AddConsultaService = AddConsultaService;
        }

        [HttpGet]
        public  ActionResult GetConsultas()
        {
            return Ok(testeRepository.GetConsultas());
        }

        [HttpGet("{name}")]
        public ActionResult GetConsultasByMedico(string name)
        {
            if (name == null || name == "")
            {
                return BadRequest(new {message = "Nome não pode ser vazio ou nulo" });
            }

            return Ok(testeRepository.GetConsultasByMedico(name));
        }

        [HttpPost]
        public ActionResult<Consulta> AddConsulta(Consulta consulta)
        {  

            var result = AddConsultaService.AddConsulta(consulta);

            if (result != null)
            {      
                return CreatedAtAction(nameof(AddConsulta),
                        new { id = result}, result);
            }
            else
            {
                return BadRequest(new { message = "Esse médico já tem consulta nesse horário" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConsulta(int id)
        {
            testeRepository.DeleteConsulta(id);
            return Ok( new { message = $"Consulta  de ID {id}, deletada com sucesso" });
        }


    }
}
