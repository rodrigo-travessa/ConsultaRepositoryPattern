using Microsoft.AspNetCore.Mvc;
using Teste.Services;
using Teste.RepoPattern.Repositories;
using Teste.RepoPattern.Services;
using Teste.RepoPattern.Services.Interfaces;
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
        private readonly IService<Consulta> consultaService;

        public MedicoController(IService<Medico> medicoService, IService<Consulta> consultaService)
        {
            this.medicoService = medicoService;
            this.consultaService = consultaService;
        }

        [HttpGet]
        public List<Consulta> BuscarTodasConsultas()
        {
            return consultaService.GetAllService();
        }


        //private readonly IMedicoRepository _medicoRepository;
        //private readonly IMedicoService _medicoCriarConsultaService;
        //private readonly IRepository<Medico> _medicoRepoPattern;
        //public MedicoController(IMedicoRepository medicoRepository, 
        //    IMedicoService medicoCriarConsultaService,
        //    IRepository<Medico> medicoRepoPattern)

        //{
        //    _medicoRepository = medicoRepository;
        //    _medicoCriarConsultaService = medicoCriarConsultaService;
        //    _medicoRepoPattern = medicoRepoPattern;
        //}

        //[HttpGet]
        //public ActionResult BuscarConsultas()
        //{
        //    return Ok(_medicoRepository.BuscarConsultas());
        //}

        //[HttpGet("{name}")]
        //public ActionResult BuscarConsultasPorMedico(string name)
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
