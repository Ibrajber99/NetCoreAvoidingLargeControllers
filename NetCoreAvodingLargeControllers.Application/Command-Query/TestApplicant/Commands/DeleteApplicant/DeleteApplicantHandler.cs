using MediatR;
using NetCoreAvodingLargeControllers.Application.Contracts.Persistance;
using NetCoreAvodingLargeControllers.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Commands.DeleteApplicant
{
    public class DeleteApplicantHandler : IRequestHandler<DeleteApplicantCommand, Unit>
    {

        private readonly IAsyncRepository<NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant> _testApplicantRepo;

        public DeleteApplicantHandler
            (IAsyncRepository<NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant> testApplicantRepo)
        {
            _testApplicantRepo = testApplicantRepo;
        }

        public async Task<Unit> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var testApplicantEntity = await _testApplicantRepo.GetByIdAsync(request.TestApplicantID);

            if (testApplicantEntity == null)
                throw new ModelNotFoundException
                    (nameof(NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant),request.TestApplicantID);


            await _testApplicantRepo.DeleteAsync(testApplicantEntity);

            return Unit.Value;
        }
    }
}
