using System.ComponentModel.DataAnnotations;

namespace FootballBooking.Entities.Model
{
    public class StadiumOwner : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Stadium> Stadiums { get; set; }
    }
}