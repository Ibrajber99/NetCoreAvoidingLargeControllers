using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Commands.UpdateApplicant
{
    public class UpdateApplicantCommand : IRequest
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int TestInfoID { get; set; }
    }
}
