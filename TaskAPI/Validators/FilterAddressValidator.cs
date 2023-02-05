using FluentValidation;
using TaskAPI.Contracts.V1.Requests.Queries;

namespace TaskAPI.Validators
{
    public class FilterAddressValidator : AbstractValidator<GetAllAddressQuery>
    {
        public FilterAddressValidator()
        {
            RuleFor(filter => filter.Filter)
               .Matches("^[a-zA-Z0-9]*$")
               .MaximumLength(10);
               
               
        }
    }
}
