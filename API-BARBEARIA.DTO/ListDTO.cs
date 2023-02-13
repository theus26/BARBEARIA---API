using API_BARBEARIA.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DTO
{
    public class ListDTO
    {
        public string NameUser { get; set; }
        public DateTime HairCurtDate { get; set; }
        public string DesiredService { get; set; }
        public string Time { get; set; }
        public string Barbers { get; set; }
    }
}
