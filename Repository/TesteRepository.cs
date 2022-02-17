using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;
#nullable enable

namespace Teste.Repository
{
    public class TesteRepository : ITesteRepository
    {

        private readonly AppDbContext _appDbContext;
        public TesteRepository(AppDbContext appDbContext)
        {
            this._appDbContext =  appDbContext;
        }

        public void DeleteConsulta(int consultaid)
        {
            var result = _appDbContext.ConsultaDB
                .FirstOrDefault(e => e.IdConsulta == consultaid);
            if (result != null)
            {
                _appDbContext.ConsultaDB.Remove(result);
                _appDbContext.SaveChanges(); 
            }
        }

        public IEnumerable<Consulta> GetConsultas()
        {
                        
            return _appDbContext.ConsultaDB.Include(x => x.Medico).Include(x => x.Paciente).ToList();
        }

        public IEnumerable<Consulta> GetConsultasByMedico(string MedicoName)
        {
            IQueryable<Consulta> query = _appDbContext.ConsultaDB;
                        
            query =  query.Where(x => x.Medico.MedicoName.Contains(MedicoName));
                      
            return query.Include(x => x.Medico).Include(x => x.Paciente).ToList();
        }

        public IEnumerable<Consulta> GetConsultasByPaciente(string PacienteName)
        {
            IQueryable<Consulta> query = _appDbContext.ConsultaDB;

            if (!string.IsNullOrEmpty(PacienteName))
            {
                query = query.Where(e => e.Paciente.PacienteName.Contains(PacienteName));
            }           

            return query.Include(x => x.Medico).Include(x => x.Paciente).ToList();
        }



        public Consulta AddConsulta(Consulta consulta)
        {
            _appDbContext.ConsultaDB.Add(consulta);
            _appDbContext.SaveChanges();

            // esse return era usado com o código que está comentado no Controller Paciente, ele retornava um OBJ consulta
            // com as informações da consulta marcada pra uso pelo consumidor da API caso fizesse sentido.

            var result = _appDbContext.ConsultaDB
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Where(x => x.IdConsulta == consulta.IdConsulta)
                .FirstOrDefault();

            return result;
        }
        public  Consulta LastConsulta(Consulta consulta)
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
