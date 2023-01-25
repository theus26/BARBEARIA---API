using API_BARBEARIA.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DTO
{
    public class UpdateSchedulingDTO
    {
        [Required] 
        public long IdUser { get; set; }
        [Required]
        public long IdScheduling { get; set; }
        [Required]
        public DateTime HairCurtDate { get; set; }
        [Required]
        public string DesiredService { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public BarberEnum barberEnum { get; set; }
    }
}
