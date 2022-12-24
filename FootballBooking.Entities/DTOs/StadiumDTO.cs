using FootballBooking.Entities.DTOs.Base;
using FootballBooking.Entities.DTOs.Validator;

namespace FootballBooking.Entities.DTOs
{
    public class StadiumDTO : StadiumBase
    {
        public AddressDTO Address { get; set; }


        public void ValidateStadium()
        {
            AddressValidator addValidator = new AddressValidator();
            addValidator.Validate(Address);
        }
    }
}