using FluentValidation;
using TaskAPI.Contracts.V1.Requests;

namespace TaskAPI.Validators
{
    public class RegistrationValidator : AbstractValidator<UserRegistrationRequest>
    {
        public RegistrationValidator()
        {
            RuleFor(user => user.Email)
                .EmailAddress();
            //RuleFor(user => user.Password)
            //    .Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            
        }
    }
}
