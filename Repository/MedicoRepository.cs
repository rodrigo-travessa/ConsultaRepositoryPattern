using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Teste.Models;
#nullable enable

namespace Teste.Repository
{
    public class MedicoRepository : IMedicoRepository
    {

        private readonly AppDbContext _appDbContext;
        public MedicoRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
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

        public IEnumerable<Consulta> BuscarConsultasPorMedico(string MedicoName)
        {
            IQueryable<Consulta> query = _appDbContext.ConsultaDB;

            query = query.Where(x => x.Medico.MedicoName.Contains(MedicoName));

            return query.Include(x => x.Medico).Include(x => x.Paciente).ToList();
        }
        public IEnumerable<Consulta> BuscarConsultasPorMedicoID(int MedicoID)
        {
            IQueryable<Consulta> query = _appDbContext.ConsultaDB;

            query = query.Where(e => e.Medico.MedicoID == MedicoID);

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
