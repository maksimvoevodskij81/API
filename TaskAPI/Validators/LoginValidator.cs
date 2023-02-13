using FluentValidation;
using TaskAPI.Contracts.V1.Requests;

namespace TaskAPI.Validators
{
    public class LoginValidator : AbstractValidator<UserLoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(user => user.Email)
                .EmailAddress();
        }
    }
}
