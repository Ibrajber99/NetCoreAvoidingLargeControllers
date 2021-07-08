using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Queries.GetApplicantDetails
{
    public class GetApplicantDetailsQuery : IRequest<TestApplicantVm>
    {
        public int ID { get; set; }

        public bool IncludeTestInfor { get; set; }
    }
}
