using FootballBooking.Entities.Enum;

namespace FootballBooking.Entities.Model
{
    public class Stadium : BaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public Guid StadiumOwnerId { get; set; }
        public StadiumStatusEnum StadiumStatus { get; set; }

        public virtual Address? Address { get; set; }
    }
}