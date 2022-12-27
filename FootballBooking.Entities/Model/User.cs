using FootballBooking.Entities.Enum;

namespace FootballBooking.Entities.Model
{
    public class User : BaseEntity<Guid>
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string PhoneNumber { get; set; }
        public string HashedPassword { get; set; }
        public UserType UserType { get; set; } = UserType.Customer;

        public virtual Address? Address { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}