using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DTO
{
    public class RespostaErrorDTO
    {
        public string Error { get; set; }
        public int Status { get; set; }
        public string Details { get; set; }
    }
}
