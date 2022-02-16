using System;
using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{
    public class Consulta
    {
        [Key]
        public int IdConsulta { get; set; }         
        public int MedicoID { get; set; }   
        public Medico Medico { get; set; }     
        public int PacienteID { get; set; } 
        public Paciente Paciente { get; set; }
        public DateTime HorarioStart { get; set; }
        public DateTime HorarioFinish { get; set; }

    }
}
