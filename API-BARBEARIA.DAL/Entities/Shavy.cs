
using System.ComponentModel.DataAnnotations;


namespace API_BARBEARIA.DAL.Entities
{
    public class Shavy
    {
        [Key]
        public long Id { get; set; }

        public string? BarberName { get; set; }
    }
}
