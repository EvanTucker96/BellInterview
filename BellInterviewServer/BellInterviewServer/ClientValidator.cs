using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BellInterviewClient
{
    class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.firstName).NotEmpty().WithMessage("First Name Can't Be Empty!");
            RuleFor(x => x.lastName).NotEmpty().WithMessage("Last Name Can't Be Empty!");
            RuleFor(x => x.DOB).Must(BeAValidDate).WithMessage("Can't Be Born Today!");
            RuleFor(x => x.address).NotEmpty().WithMessage("Address Can't Be Empty!");
            RuleFor(x => x.email).Must(BeAValidEmail).WithMessage("Email Must Be Proper Format!");
            RuleFor(x => x.phone).Must(BeAValidPhoneNumber).WithMessage("Phone Must Be Proper Format!");
        }

        //will return true if date is not today, false if it is set to today.
       private bool BeAValidDate(DateTime DOB)
        {
            return !DOB.Equals(default(DateTime));
        }

        //will return true or false if email is valid or not within the Regular Expression
        private bool BeAValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        }

        //will return true or false if phone number is valid or not withing the Regular Expression
        private bool BeAValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^\s *\+?\s * ([0 - 9][\s -] *){ 9,}$", RegexOptions.IgnoreCase);
        }
    }
}
