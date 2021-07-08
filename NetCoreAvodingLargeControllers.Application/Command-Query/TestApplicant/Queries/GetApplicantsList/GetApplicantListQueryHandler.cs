using AutoMapper;
using MediatR;
using NetCoreAvodingLargeControllers.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Queries.GetApplicantsList
{
    public class GetApplicantListQueryHandler : IRequestHandler<GetApplicantListQuery, List<TestApplicantListVm>>
    {
        private readonly IAsyncRepository<NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant> _testApplicantRepo;
        private readonly IMapper _mapper;

        public GetApplicantListQueryHandler
            (IAsyncRepository<NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant> testApplicantRepo,
            IMapper mapper)
        {
            _testApplicantRepo = testApplicantRepo;
            _mapper = mapper;
        }


        public async Task<List<TestApplicantListVm>> Handle
            (GetApplicantListQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<TestApplicantListVm>>(await _testApplicantRepo.ListAllAsync());
        }
    }
}
