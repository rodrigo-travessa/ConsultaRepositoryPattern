using System.Collections.Generic;
using System.Linq;

namespace Teste.RepoPattern.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        void AdicionarService(T entity);
        void DeleteService(T entity);
        T GetByIdService(int id);
        List<T> GetAllService();

    }
}
