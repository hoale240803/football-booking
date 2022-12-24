using FluentValidation;
using FootballBooking.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBooking.Entities.DTOs.Validator
{
    public class AddressValidator : AbstractValidator<AddressDTO>
    {
        public AddressValidator() {
            RuleFor(address => address.Street)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(ErrorMessages.AddressCityNotEmpty)
                .Length(2, 255).WithMessage(ErrorMessages.AddressCityMaxLength);
        }
    }
}
