using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DTO
{
    public class SucessLoginDTO
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public long IdUser { get; set; }
        public bool IsBarber { get; set; }
    }
}
