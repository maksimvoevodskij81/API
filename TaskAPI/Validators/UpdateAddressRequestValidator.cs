using FluentValidation;
using TaskAPI.Contracts.V1.Requests;

namespace TaskAPI.Validators
{
    public class UpdateAddressRequestValidator : AbstractValidator<AddressUpdateRequest>
    {
        public UpdateAddressRequestValidator()
        {
            RuleFor(address => address.Country)
               .NotEmpty()
               .Matches("^[a-zA-Z0-9]*$")
               .MinimumLength(2);
            RuleFor(address => address.City)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9]*$")
                .MinimumLength(3);
            RuleFor(address => address.Street)
               .NotEmpty()
               .Matches("^[a-zA-Z0-9]*$")
               .MinimumLength(3);
            RuleFor(address => address.ZipCode)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9]*$")
                .MinimumLength(6)
                .MaximumLength(6);
            RuleFor(address => address.HouseNumber)
                .NotEmpty()
                .Matches("^[0-9]*$")
                .MaximumLength(6);
        }
    }
}
