using System.Linq;

namespace Teste.RepoPattern
{
    public interface IRepository<T> where T : class
    {
        void Adicionar(T entity);
        void Delete(int id);
        T GetById(int id);
        IQueryable<T> GetAll();        
    }
}
