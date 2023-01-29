using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DAL.Entities
{
    public class Sessions
    {
        [Key]
        public long IdSession { get; set; }
        [Required]
        public long IdUser { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime LoginDate { get; set; }
        [Required]
        public DateTime LogoutDate { get; set;}
        [Required]
        public bool SessionFinalized { get; set; }

        [ForeignKey("IdUser")]
        public virtual User user { get; set; }
    }
}
