using System.Linq;

namespace Teste.RepoPattern
{
    public interface IRepository<T> where T : class
    {
        void Adicionar(T entity);
        void Delete(T entity);
        T GetById(int id);
        IQueryable<T> GetAll();        
    }
}
