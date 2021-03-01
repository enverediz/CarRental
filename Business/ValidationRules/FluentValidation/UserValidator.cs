using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(ValidatorMessages.CanNotBlank);
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage(ValidatorMessages.LengthInvalid); 

            RuleFor(u => u.LastName).NotEmpty().WithMessage(ValidatorMessages.CanNotBlank);
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage(ValidatorMessages.LengthInvalid);

            RuleFor(u => u.Email).NotEmpty().WithMessage(ValidatorMessages.CanNotBlank);

            RuleFor(u => u.Password).NotEmpty().WithMessage(ValidatorMessages.CanNotBlank);
            RuleFor(u => u.Password).MinimumLength(8).WithMessage(ValidatorMessages.PasswordInvalid);
        }
    }
}
