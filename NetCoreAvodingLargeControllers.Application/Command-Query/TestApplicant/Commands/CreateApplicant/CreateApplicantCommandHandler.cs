using AutoMapper;
using MediatR;
using NetCoreAvodingLargeControllers.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetCoreAvoidingLargeControllers.Domain.Entities;
using NetCoreAvodingLargeControllers.Application.Exceptions;

namespace NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Commands.CreateApplicant
{
    public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, CreateApplicantResponse>
    {
        private readonly IAsyncRepository<NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant> _testApplicantRepo;
        private readonly IMapper _mapper;


        public CreateApplicantCommandHandler
            (IAsyncRepository<NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant> testApplicantRepo,
            IMapper mapper)
        {
            _testApplicantRepo = testApplicantRepo;
            _mapper = mapper;
        }


        public async Task<CreateApplicantResponse> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            var createApplicantResponse = new CreateApplicantResponse();
            var createApplicantValidator = new CreateApplicantValidator();

            var validationResult = await createApplicantValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ModelValidationException(validationResult);

            var testApplicant = _mapper.Map<NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant>(request);

            createApplicantResponse.TestApplicant = _mapper.Map<CreateApplicantDto>(await _testApplicantRepo.AddAsync(testApplicant));


            return createApplicantResponse;
        }
    }
}
