using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SharpApiRateLimit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayersApi {
    [ApiController]
    [RateLimitByHeader("X-Token", "5s", 1)]
    public class PlayersController : ControllerBase {
        private readonly IMediator _mediator;
        private readonly IPlayersRepository _playersRepository;

        public PlayersController(IMediator mediator,
                                 IPlayersRepository playersRepository) {
            _mediator = mediator;
            _playersRepository = playersRepository;
        }

        [HttpGet("/api/players")]
        public async Task<ActionResult<List<PlayerItem>>> List() {
            return await _playersRepository.List();
        }

        [HttpGet("/api/players/{id}")]
        public async Task<ActionResult<PlayerGet>> Get([FromQuery]PlayerGetRequest request) {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Creates a new Player
        /// </summary>
        [HttpPost("/api/players")]
        [ProducesResponseType(typeof(PlayerGet), 201)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        
        public async Task<ActionResult> Post([FromBody]PlayerPostRequest request,
                                             [FromServices] LinkGenerator linkGenerator) {
            var player = await _playersRepository.Add(request);
            var url = linkGenerator.GetPathByAction(HttpContext, 
                                                    nameof(Get), 
                                                    values: new { player.Id });
            return Created(url, player);
        }
    }
}