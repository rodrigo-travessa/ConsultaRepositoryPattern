using Microsoft.AspNetCore.Mvc;
using Teste.Services;
using Teste.Models;
using System.Linq;
using System.Collections.Generic;

namespace Teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly IService<Medico> medicoService;
        private readonly IConsultaService consultaService;

        public MedicoController(IService<Medico> medicoService, IConsultaService consultaService)
        {
            this.medicoService = medicoService;
            this.consultaService = consultaService;
        }

        [HttpGet]
        public List<Consulta> BuscarTodasConsultas()
        {

            return consultaService.GetAllService();
        }

        [HttpGet("{id}")]
        public List<Consulta> BuscarConsultaPorID(int id)
        {            
            return consultaService.GetAllService().Where(x => x.MedicoID == id).ToList();
        }
        //{
        //    if (name == null || name == "")
        //    {
        //        return BadRequest(new { message = "Nome não pode ser vazio ou nulo" });
        //    }

        //    return Ok(_medicoRepository.BuscarConsultasPorMedico(name));
        //}

        //[HttpGet("{ID}")]
        //public ActionResult BuscarConsultasPorMedico(int ID)
        //{
        //    if (ID == null)
        //    {
        //        return BadRequest(new { message = "ID não pode ser Nulo" });
        //    }

        //    return Ok(_medicoRepository.BuscarConsultasPorMedicoID(ID));
        //}






        //[HttpPost]
        //public ActionResult<Consulta> AdicionarConsulta(Consulta consulta)
        //{
        //    string ConsultaValida = _medicoCriarConsultaService.ValidarConsulta(consulta);
        //    if (ConsultaValida == "Ok")
        //    {
        //        var result = _medicoCriarConsultaService.AddConsulta(consulta);

        //        return CreatedAtAction(nameof(AdicionarConsulta),
        //                     new { id = result }, result);
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = ConsultaValida});
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeletarConsulta(int id)
        //{
        //    _medicoRepository.DeletarConsulta(id);
        //    return Ok(new { message = $"Consulta  de ID {id}, deletada com sucesso" });
        //}


    }
}
