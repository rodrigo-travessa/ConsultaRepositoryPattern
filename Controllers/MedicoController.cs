using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;
using Teste.Repository;

namespace Teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly ITesteRepository testeRepository;
        public MedicoController(ITesteRepository testeRepository)
        {
            this.testeRepository = testeRepository;
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
            try
            {
                // validar consulta por médico/paciente nesses horários.
                var LastConsulta = testeRepository.LastConsulta(consulta);
                var NextConsulta = testeRepository.NextConsulta(consulta);

                if (LastConsulta == null && NextConsulta == null)
                {
                    var createdConsulta = testeRepository.AddConsulta(consulta);

                    return CreatedAtAction(nameof(AddConsulta),
                        new { id = createdConsulta}, createdConsulta);
                }

                return StatusCode(202, new {message = "Conflito de horario na criação da consulta"});  
                

            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public void DeleteConsulta(int id)
        {
            testeRepository.DeleteConsulta(id);
        }


    }
}
