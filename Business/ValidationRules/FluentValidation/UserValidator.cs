using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Password).MaximumLength(8);
        }
    }
}
