using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Teste.Models;
#nullable enable

namespace Teste.Repository
{
    public class PacienteRepository : IPacienteRepository
    {

        private readonly AppDbContext _appDbContext;
        public PacienteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void DeletarConsulta(int consultaid)
        {
            var result = _appDbContext.ConsultaDB
                .FirstOrDefault(e => e.IdConsulta == consultaid);
            if (result != null)
            {
                _appDbContext.ConsultaDB.Remove(result);
                _appDbContext.SaveChanges();
            }
        }

        public IEnumerable<Consulta> BuscarConsultas()
        {
            return _appDbContext.ConsultaDB.Include(x => x.Medico).Include(x => x.Paciente).ToList();
        }

        public IEnumerable<Consulta> BuscarConsultasPorPaciente(string Paciente)
        {
            IQueryable<Consulta> query = _appDbContext.ConsultaDB;

            query = query.Where(x => x.Paciente.PacienteName.Contains(Paciente));

            return query.Include(x => x.Medico).Include(x => x.Paciente).ToList();
        }
        public IEnumerable<Consulta> BuscarConsultasPorPacienteID(int PacienteID)
        {
            IQueryable<Consulta> query = _appDbContext.ConsultaDB;

            query = query.Where(e => e.Paciente.PacienteID == PacienteID);

            return query.Include(x => x.Medico).Include(x => x.Paciente).ToList();
        }

        public Consulta AddConsulta(Consulta consulta)
        {
            _appDbContext.ConsultaDB.Add(consulta);
            _appDbContext.SaveChanges();

            var result = _appDbContext.ConsultaDB
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Where(x => x.IdConsulta == consulta.IdConsulta)
                .FirstOrDefault();

            return result;
        }

    }
}
