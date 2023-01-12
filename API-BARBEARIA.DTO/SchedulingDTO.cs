using API_BARBEARIA.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DTO
{
    public class SchedulingDTO
    {
        public int IdUser { get; set; }
        public DateTime HairCurtDate { get; set; }
        public string DesiredService { get; set; }
        public string Time { get; set; }
        public BarberEnum barberEnum { get; set; }
    }
}
