using API_BARBEARIA.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DAL.Entities
{
    public class Scheduling
    {
        [Key]
        public long IdSchedulling { get; set; } //Esse é o Id da tabela agendamento
        public long IdUser { get; set; } // Esse é o Id do dono do agendamento
        public string NameUser { get; set; } // Esse é o Id do dono do agendamento
        [Required]
        public DateTime HairCurtDate { get; set; }
        [Required]
        public string DesiredService { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public BarberEnum Barber { get; set; }
        [Required]
        public bool SchedulingCompleted { get; set; }

        [ForeignKey("IdUser")]
        public virtual User user { get; set; }
    }
}
