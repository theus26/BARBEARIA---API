using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DAL.Entities
{
    public class Barber
    {
        [Key]
        public long IdBarber { get; set; }
        public long IdSchedulling { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("IdSchedulling")]
        public virtual Scheduling scheduling { get; set; }
    }
}
