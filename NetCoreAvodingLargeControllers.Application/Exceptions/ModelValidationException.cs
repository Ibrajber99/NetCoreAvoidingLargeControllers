using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvodingLargeControllers.Application.Exceptions
{
    public class ModelValidationException : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        //Accepts a ValidationResult provided by FluentValidation Framework
        public ModelValidationException(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }

    }
}
