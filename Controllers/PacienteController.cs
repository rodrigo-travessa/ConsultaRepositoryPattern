using Microsoft.AspNetCore.Mvc;


namespace Teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        //private readonly IPacienteRepository _pacienteRepository;
        //private readonly IPacienteService _pacienteCriarConsultaService;
        //public PacienteController(IPacienteRepository PacienteRepository, IPacienteService pacienteCriarConsultaService)
        //{
        //    _pacienteRepository = PacienteRepository;
        //    _pacienteCriarConsultaService = pacienteCriarConsultaService;
        //}

        //[HttpGet]
        //public ActionResult BuscarConsultas()
        //{
        //    return Ok(_pacienteRepository.BuscarConsultas());
        //}

        //[HttpGet("{name}")]
        //public ActionResult BuscarConsultasPorPaciente(string name)
        //{
        //    return Ok(_pacienteRepository.BuscarConsultasPorPaciente(name));
        //}

        //[HttpGet("{ID}")]
        //public ActionResult BuscarConsultasPorPacienteID(int ID)
        //{
        //    return Ok(_pacienteRepository.BuscarConsultasPorPacienteID(ID));
        //}


        //[HttpPost]
        //public ActionResult<Consulta> AddConsulta(Consulta consulta)
        //{
        //    string ConsultaValid = _pacienteCriarConsultaService.ValidarConsulta(consulta);
        //    if (ConsultaValid == "Ok")
        //    {
        //        var result = _pacienteCriarConsultaService.AddConsulta(consulta);

        //        return CreatedAtAction(nameof(AddConsulta),
        //                     new { id = result }, result);
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = ConsultaValid });
        //    }

        //}

    }
}
