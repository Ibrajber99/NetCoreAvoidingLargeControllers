using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Commands.UpdateApplicant
{
    public class UpdateApplicantValidator : AbstractValidator<UpdateApplicantCommand>
    {
        public UpdateApplicantValidator()
        {
            RuleFor(a => a.FirstName).NotNull().NotEmpty().WithMessage("First name needs to have a value");

            RuleFor(a => a.LastName).NotNull().NotEmpty().WithMessage("First name needs to have a value");

            RuleFor(a => a.TestInfoID).NotNull().NotEmpty().WithMessage("First name needs to have a value");

            RuleFor(a => a.DateOfBirth).Must(IsDateOfBirthValid).WithMessage("Minimum age to register is 19");
        }

        private bool IsDateOfBirthValid(DateTime dob)
        {
            return DateTime.Now.Year - dob.Year > 18;
        }
    }
}
