using FileAPI.Application.Features.Commands.File.Create;
using FileAPI.Application.Features.Commands.File.Delete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FileController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(FileCreateCommandRequest fileCreateCommandRequest)
        {
            FileCreateCommandResponse fileCreateResponse = await _mediator.Send(fileCreateCommandRequest);

            return Ok(fileCreateResponse);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(FileDeleteCommandRequest fileDeleteCommandRequest)
        {
            FileDeleteCommandResponse fileDeleteCommandResponse = await _mediator.Send(fileDeleteCommandRequest);

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
