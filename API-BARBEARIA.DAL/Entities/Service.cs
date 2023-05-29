
using System.ComponentModel.DataAnnotations;

namespace API_BARBEARIA.DAL.Entities
{
    public class Service
    {
        [Key]
        public long Id { get; set; }

        public string? NameServices { get; set; }
    }
}
