using Microsoft.AspNetCore.Mvc;
using Teste.Repository;
using Teste.Models;
using System.Linq;

namespace Teste.Services
{
    public class AddConsultaService : IAddConsultaService
    {
        private readonly ITesteRepository testeRepository;
        private readonly AppDbContext _appDbContext;

        public AddConsultaService(ITesteRepository testeRepository, AppDbContext appDbContext)
        {
            this.testeRepository = testeRepository;
            _appDbContext = appDbContext;
        }

        public Consulta AddConsulta(Consulta consulta)
        {
            if (consulta.HorarioStart < System.DateTime.Now)
            {
                return null;
            }

            if (LastConsulta(consulta) == null && NextConsulta(consulta) == null)
            {   
                return testeRepository.AddConsulta(consulta);
            }

            return null;

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
    }
}
