
using System.ComponentModel.DataAnnotations;

namespace API_BARBEARIA.DAL.Entities
{
    public class Horary
    {
        [Key] 
        public long Id { get; set; }
        public string? horary { get; set; }
        public bool? AvailableTime { get; set; }
        public DateTime AvailableDate { get; set; }
    }
}
