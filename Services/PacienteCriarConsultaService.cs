using Teste.Repository;
using Teste.Models;
using System.Linq;

namespace Teste.Services
{
    public class PacienteCriarConsultaService : IPacienteCriarConsultaService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly AppDbContext _appDbContext;

        public PacienteCriarConsultaService(IPacienteRepository pacienteRepository, AppDbContext appDbContext)
        {
            _pacienteRepository = pacienteRepository;
            _appDbContext = appDbContext;
        }

        public Consulta AddConsulta(Consulta consulta)
        {
            return _pacienteRepository.AddConsulta(consulta);
        }

        public Consulta LastConsulta(Consulta consulta)
        {
            IQueryable<Consulta> query = _appDbContext.ConsultaDB;

            query = query.Where(x => x.HorarioStart <= consulta.HorarioStart)
                         .Where(x => x.HorarioFinish > consulta.HorarioStart)
                         .Where(x => x.MedicoID == consulta.MedicoID);

            return query.FirstOrDefault();
        }

        public Consulta NextConsulta(Consulta consulta)
        {
            IQueryable<Consulta> query = _appDbContext.ConsultaDB;

            query = query.Where(x => x.HorarioStart >= consulta.HorarioStart)
                         .Where(x => x.HorarioStart < consulta.HorarioFinish)
                         .Where(x => x.MedicoID == consulta.MedicoID);

            return query.FirstOrDefault();
        }

        public string ValidarConsulta(Consulta consulta)
        {
            if (consulta.HorarioStart < System.DateTime.Now)
            {
                return "Horario de Início não pode ser anterior ao momento da marcação";
            }
            if (LastConsulta(consulta) != null || NextConsulta(consulta) != null)
            {
                return "Conflito de Horário, já existe consulta com esse médico nesse horário";
            }

            IQueryable<Medico> queryMedico = _appDbContext.MedicosDB
                    .Where(x => x.MedicoID == consulta.MedicoID);

            if (queryMedico.FirstOrDefault() == null)
            {
                return "Não Existe um Médico com esse ID";
            }

            IQueryable<Paciente> queryPaciente = _appDbContext.PacientesDB
                    .Where(x => x.PacienteID == consulta.PacienteID);

            if (queryPaciente.FirstOrDefault() == null)
            {
                return "Não Existe um Paciente com esse Id";
            }


            return "Ok";
        }
    }
}
