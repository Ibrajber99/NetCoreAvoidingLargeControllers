using AutoMapper;
using MediatR;
using NetCoreAvodingLargeControllers.Application.Contracts.Persistance;
using NetCoreAvodingLargeControllers.Application.Exceptions;
using NetCoreAvoidingLargeControllers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Queries.GetApplicantDetails
{
    public class GetApplicantQueryHandler : IRequestHandler<GetApplicantDetailsQuery, TestApplicantVm>
    {
        private readonly IAsyncRepository<NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant> _testApplicantRepo;
        private readonly IAsyncRepository<TestInfo> _testInfoRepo;
        private readonly IMapper _mapper;

        public GetApplicantQueryHandler
            (IAsyncRepository<NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant> testApplicantRepo,
            IAsyncRepository<TestInfo> testInfoRepo,
            IMapper mapper)
        {
            _testApplicantRepo = testApplicantRepo;
            _testInfoRepo = testInfoRepo;
            _mapper = mapper;
        }


        public async Task<TestApplicantVm> Handle(GetApplicantDetailsQuery request, CancellationToken cancellationToken)
        {
            var testApplicantEntity = await _testApplicantRepo.GetByIdAsync(request.ID);


            if (testApplicantEntity == null)
                throw new ModelNotFoundException
                     (nameof(NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant), request.ID);

            if (request.IncludeTestInfor)
            {
                var testInfo = await _testInfoRepo.GetByIdAsync(testApplicantEntity.TestInfoID);

                testApplicantEntity.TestInfo = testInfo;
            }

            return _mapper.Map<TestApplicantVm>(testApplicantEntity);
        }
    }
}
