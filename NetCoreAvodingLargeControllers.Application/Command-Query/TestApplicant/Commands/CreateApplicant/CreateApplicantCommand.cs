using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Commands.CreateApplicant
{
    public class CreateApplicantCommand : IRequest<CreateApplicantResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TestInfoID { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
