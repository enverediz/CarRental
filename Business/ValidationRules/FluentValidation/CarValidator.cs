using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator: AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty().WithMessage(ValidatorMessages.CanNotBlank);
            RuleFor(c=>c.CarName).MinimumLength(2).WithMessage(ValidatorMessages.LengthInvalid);
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage(ValidatorMessages.CanNotBlank);
            RuleFor(c => c.DailyPrice).GreaterThan(0);            
            
        }
    }
}
