using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Teste.Models;
using Teste.RepoPattern;

namespace Teste.Services
{
    public class ConsultaService : Service<Consulta>, IConsultaService
    {

        public ConsultaService(IConsultaRepository _repository) : base(_repository)
        {
        }

        public override void AdicionarService(Consulta entity)
        {
            /// Consulta que está tentando ser marcada = NovaConsulta
            /// 
            /// Pra validar se já há outra consulta um dos métodos é :
            /// 1- Buscar todas as consultas com horário de INICIO anterior ao Horario de inicio da NovaConsulta.
            ///     1.1- Dentro desses consultas, conferir se alguma delas tem horário POSTERIOR ao início da NovaConsulta.
            ///     
            /// 2-Buscar todas as consultas com horário de início Posterior ao Horario de Início da NovaConsulta.
            ///     2.1 Dentro dessas consultas, conferir se alguma delas tem horário de início ANTERIOR ao FIM da NovaConsulta.
            /// 
            /// Where1 nos traz uma lista de Consultas que Começam ANNTES da NovaConsulta, e Terminam Durante ou Depois da mesma, sendo incompatíveis.
            /// Where1 x => x.Start <= NovaConsulta.Start && x.Finish >= NovaConsulta.Start
            ///
            /// Where 2 Busca Consultas que possam estar DENTRO do Horário de Atendimento dessa NovaConsulta.
            /// Where2 x=> x.Start >= NovaConsulta.Start && x.Finish <= NovaConsulta.Finish
            /// .
            /// Assim sendo, se Where1 != Null || Where2 != Null  => NovaConsulta é inválida.

            var query = _repository.GetAll();

            var CasoConflito1 = query.Where(x => x.MedicoID == entity.MedicoID || x.PacienteID == entity.PacienteID)
                                     .Where(x => x.HorarioStart <= entity.HorarioStart && x.HorarioFinish >= entity.HorarioStart);

            var CasoConflito2 = query.Where(x => x.MedicoID == entity.MedicoID || x.PacienteID == entity.PacienteID)
                                     .Where(x => x.HorarioStart >= entity.HorarioStart && x.HorarioFinish <= entity.HorarioFinish);


            if (CasoConflito1.FirstOrDefault() != null || CasoConflito2.FirstOrDefault() != null)
            {
                throw new System.NotImplementedException();
                // Arrumar pra caso bata aqui retorne um erro dizendo que a consulta não pôde ser Marcada
            }
            else
            {
                _repository.Adicionar(entity);                
            }



        }

        public override List<Consulta> GetAllService()
        {
            return _repository.GetAll().ToList();
        }

        public List<Consulta> BuscarConsultasPorMedico(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Consulta> BuscarConsultasPorPaciente(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
