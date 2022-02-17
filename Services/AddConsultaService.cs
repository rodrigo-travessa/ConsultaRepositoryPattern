using Microsoft.AspNetCore.Mvc;
using Teste.Repository;
using Teste.Models;


namespace Teste.Services
{
    public class AddConsultaService : IAddConsultaService
    {
        private readonly ITesteRepository testeRepository;

        public AddConsultaService(ITesteRepository testeRepository)
        {
            this.testeRepository = testeRepository;
        }

        public bool AddConsulta(Consulta consulta)
        {

            
            var LastConsulta = testeRepository.LastConsulta(consulta);
            var NextConsulta = testeRepository.NextConsulta(consulta);

            if (LastConsulta == null && NextConsulta == null)
            {
                testeRepository.AddConsulta(consulta);              
                
                return true;
            }

            return false;




        }
    }
}
