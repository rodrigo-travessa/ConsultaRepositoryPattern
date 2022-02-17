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

            if (consulta.HorarioStart < System.DateTime.Now)
            {
                return BadRequest(new { message = "Não pode marcar consulta anterior ao momento presente" });
            }

            var result = AddConsultaService.AddConsulta(consulta);
            if (result == true)
            {
                return Ok(new { message = "Consulta criada com sucesso" });
            }
            else
            {
                return BadRequest(new { message = "Esse médico já tem consulta nesse horário" });
            }

            //try
            //{
            //    var LastConsulta = testeRepository.LastConsulta(consulta);
            //    var NextConsulta = testeRepository.NextConsulta(consulta);

            //    if (LastConsulta == null &&  NextConsulta == null)
            //    {
            //        var createdConsulta = testeRepository.AddConsulta(consulta);

            //        return CreatedAtAction(nameof(AddConsulta),
            //            new { id = createdConsulta}, createdConsulta);
            //    }
            //    else
            //    {
            //    return NotFound();
            //    }


            //}
            //catch (System.Exception)
            //{
            //    return BadRequest();
            //}

        }


    }
}
