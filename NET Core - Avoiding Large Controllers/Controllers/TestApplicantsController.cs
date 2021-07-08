using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Commands.CreateApplicant;
using NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Commands.DeleteApplicant;
using NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Commands.UpdateApplicant;
using NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Queries.GetApplicantDetails;
using NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Queries.GetApplicantsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core___Avoiding_Large_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApplicantsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestApplicantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll",Name ="GetAllList ")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<TestApplicantListVm>>> GetAllList()
                                            => await _mediator.Send(new GetApplicantListQuery());

        [HttpGet("{id}", Name = "GetDetails")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TestApplicantVm>> GetDetails(int id, bool IncludeTestInfo = false)
            => await _mediator.Send(new GetApplicantDetailsQuery { ID = id, IncludeTestInfor = IncludeTestInfo });


        [HttpPost(Name = "Create")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateApplicantResponse>> Create([FromBody] CreateApplicantCommand command)
            => await _mediator.Send(command);


        [HttpPut(Name = "Update")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateApplicantCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}",Name = "Delete")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteApplicantCommand { TestApplicantID = id});

            return NoContent();
        }
    }
}
