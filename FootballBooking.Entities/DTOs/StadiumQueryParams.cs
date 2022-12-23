namespace FootballBooking.Entities.DTOs
{
    public class StadiumQueryParams : QueryParams
    {
        public string Name { get; set; }

        public AddressDTO Address { get; set; }
    }
}