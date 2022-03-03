using System.Collections.Generic;
using System.Linq;
using Teste.RepoPattern;

namespace Teste.Services
{
    public class Service<T> : IService<T> where T : class
    {

        protected readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void AdicionarService(T entity)
        {
            _repository.Adicionar(entity);            
        }

        public void DeleteService(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual List<T> GetAllService()
        {
            return _repository.GetAll().ToList();
        }

        public T GetByIdService(int id)
        {
            return _repository.GetById(id);
        }
       
    }
}
