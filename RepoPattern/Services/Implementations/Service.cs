using System.Collections.Generic;
using System.Linq;
using Teste.Models;
using Teste.RepoPattern.Services.Interfaces;

namespace Teste.RepoPattern.Services.Implementations
{
    public class Service<T> : IService<T> where T : class
    {

        private readonly IRepository<T> _repository;

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

        public List<T> GetAllService()
        {
            return _repository.GetAll().ToList();
        }

        public T GetByIdService(int id)
        {
            return _repository.GetById(id);
        }
       
    }
}
