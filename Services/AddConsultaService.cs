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

            // validar consulta por médico/paciente nesses horários.
            var LastConsulta = testeRepository.LastConsulta(consulta);
            var NextConsulta = testeRepository.NextConsulta(consulta);

            if (LastConsulta == null && NextConsulta == null)
            {
                var createdConsulta = testeRepository.AddConsulta(consulta);

                // alternativa seria retornar um 201 created successfully.

                return true;
            }

            return false;




        }
    }
}
