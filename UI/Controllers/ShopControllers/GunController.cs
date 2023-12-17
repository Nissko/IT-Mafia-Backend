using BackendMafia.Applications.Gun.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UI.Applications.Gun.Commands.DeleteGuns;
using UI.Applications.Gun.Commands.StoreGuns;
using UI.Applications.Gun.Commands.UpdateGuns;

namespace BackendMafia.Controllers.ShopControllers
{
    [ApiController]
    [Route("[controller]")]
    public class GunController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GunController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetGuns([FromQuery] GetGunsQuery request)
        {
            var response = await _mediator.Send(request);
            return new JsonResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> StoreGuns([FromBody] StoreGunsCommand request)
        {
            var response = await _mediator.Send(request);
            return new JsonResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGuns([FromBody] UpdateGunsCommand request)
        {
            var response = await _mediator.Send(request);
            return new JsonResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGuns([FromBody] DeleteGunsCommand request)
        {
            var response = await _mediator.Send(request);
            return new JsonResult(response);
        }
    }
}
