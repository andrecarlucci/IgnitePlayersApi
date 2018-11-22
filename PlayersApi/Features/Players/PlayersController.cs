using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PlayersApi.Features.Players.Get;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayersApi {
    [ApiController]
    public class PlayersController : ControllerBase {
        private readonly IPlayersRepository _playersRepository;
        private readonly IBadgesClient _badgesClient;
        private readonly LinkGenerator _linkGenerator;

        public PlayersController(IPlayersRepository playersRepository,
                                 IBadgesClient badgesClient,
                                 LinkGenerator linkGenerator) {
            _playersRepository = playersRepository;
            _badgesClient = badgesClient;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("/api/players")]
        public async Task<ActionResult<List<PlayerItem>>> List() {
            return await _playersRepository.List();
        }

        [HttpGet("/api/players/{id}")]
        public async Task<ActionResult<PlayerGet>> Get([FromQuery]PlayerGetRequest request) {
            var player = await _playersRepository.Get(request.Id);
            if(player == null) {
                return NotFound();
            }
            player.Badges = await _badgesClient.Get(player.Id);
            return Ok(player);
        }

        /// <summary>
        /// Creates a new Player
        /// </summary>
        [HttpPost("/api/players")]
        [ProducesResponseType(typeof(PlayerGet), 201)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        
        public async Task<ActionResult> Post([FromBody]PlayerPostRequest request) {
            var player = await _playersRepository.Add(request);
            var url = _linkGenerator.GetPathByAction(HttpContext, 
                                                     nameof(Get), 
                                                     values: new { player.Id });
            return Created(url, player);
        }
    }
}