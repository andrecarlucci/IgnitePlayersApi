using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayersApi {
    [ApiController]
    public class PlayersController : ControllerBase {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("/api/players")]
        public async Task<ActionResult<List<PlayerItem>>> List() {
            return await _mediator.Send(new PlayerListRequest());
        }

        [HttpGet("/api/players/{id}")]
        public async Task<ActionResult<PlayerGet>> Get([FromQuery]PlayerGetRequest request) {
            return await _mediator.Send(request);
        }

        [HttpPost("/api/players")]
        [ProducesResponseType(typeof(PlayerGet), 201)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        
        public async Task<ActionResult> Post([FromBody]PlayerPostRequest request,
                                             [FromServices] LinkGenerator linkGenerator) {
            var player = await _mediator.Send(request);
            var url = linkGenerator.GetPathByAction(HttpContext, 
                                                    nameof(Get), 
                                                    values: new { player.Id });
            return Created(url, player);
        }
    }
}