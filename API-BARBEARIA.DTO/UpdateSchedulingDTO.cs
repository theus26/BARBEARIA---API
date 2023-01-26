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
     
        public DateTime HairCurtDate { get; set; }
      
        public string DesiredService { get; set; }
      
        public string Time { get; set; }
      public BarberEnum barberEnum { get; set; }
    }
}
