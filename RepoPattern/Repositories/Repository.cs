using Microsoft.EntityFrameworkCore;
using System.Linq;
using Teste.Models;

namespace Teste.RepoPattern
{
    public class Repository<T> : IRepository<T> where T : class                                               
    {
        protected AppDbContext appDbContext;
        protected DbSet<T> DbSet;

        public Repository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
            DbSet = appDbContext.Set<T>();
        }
        public void Adicionar(T entity)
        {
            DbSet.Add(entity);
            appDbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            appDbContext.SaveChanges();
        }
        public IQueryable<T> GetAll()
        {
            return DbSet;
        }
        public T GetById(int Id)
        {
            return DbSet.Find(Id);
        }

        
    }
}
