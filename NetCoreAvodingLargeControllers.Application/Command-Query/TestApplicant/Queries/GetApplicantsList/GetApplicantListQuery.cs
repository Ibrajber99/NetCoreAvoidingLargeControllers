using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Queries.GetApplicantsList
{
    public class GetApplicantListQuery : IRequest<List<TestApplicantListVm>>
    {

    }
}
