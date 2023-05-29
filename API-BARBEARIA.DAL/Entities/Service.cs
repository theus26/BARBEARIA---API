using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DAL.Entities
{
    public class Service
    {
        [Key]
        public long Id { get; set; }

        public string? NameServices { get; set; }
    }
}
