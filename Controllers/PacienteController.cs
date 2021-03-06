using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Teste.Models;
using Teste.Services;

namespace Teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
		private readonly IService<Paciente> pacienteService;
		private readonly IConsultaService consultaService;

		public PacienteController(IService<Paciente> pacienteService, IConsultaService consultaService)
		{
			this.pacienteService = pacienteService;
			this.consultaService = consultaService;
		}


		///  Esse controlador tem que possuir as seguintes funções
		///  1- Adicionar consulta com validações pra não marcar consultas duplicadas.
		///  2- Buscar Todas as consultas
		///  3- Buscar Consultas por ID do Médico.
		///  (Bônus) - Buscar Consultas por Nome do Médico.


		[HttpGet]
		public List<Consulta> BuscarTodasConsultas()
		{
			return consultaService.GetAllService();
		}

		[HttpGet("{id}")]
		public List<Consulta> BuscarConsultaPorID(int id)
		{
			return consultaService.GetAllService().Where(x => x.PacienteID == id).ToList();
		}

		[HttpPost]
		public void AdicionarConsulta(Consulta consulta)
		{
			consultaService.AdicionarService(consulta);
		}

		[HttpDelete("{id}")]
		public void DeletarConsulta(int id)
		{
			consultaService.DeleteService(id);
		}


	}
}
