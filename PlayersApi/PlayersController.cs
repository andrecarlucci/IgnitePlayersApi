using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayersApi {
    [ApiController]
    public class PlayersController : Controller {
        private readonly IPlayersRepository _playersRepository;
        private readonly LinkGenerator _linkGenerator;

        public PlayersController(IPlayersRepository playersRepository, 
                                 LinkGenerator linkGenerator) {
            _playersRepository = playersRepository;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("/api/players")]
        public async Task<ActionResult<List<PlayerItem>>> List() {
            return await _playersRepository.List();
        }

        [HttpGet("/api/players/{id}")]
        public async Task<ActionResult<PlayerGet>> Get(PlayerGetRequest request) {
            return await _playersRepository.Get(request.Id);
        }

        [HttpPost("/api/players")]
        public async Task<ActionResult> Post([FromBody]PlayerPostRequest post) {
            var player = await _playersRepository.Add(post);
            var url = _linkGenerator.GetPathByAction(HttpContext, 
                                                     nameof(Get), 
                                                     values: new { player.Id });
            return Created(url, player);
        }
    }
}