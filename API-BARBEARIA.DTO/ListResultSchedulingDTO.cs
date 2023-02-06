using API_BARBEARIA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DTO
{
    public class ListResultSchedulingDTO
    {
        public List<Scheduling> schedulings { get; set; }
        public int Count { get; set; }
    }
}
