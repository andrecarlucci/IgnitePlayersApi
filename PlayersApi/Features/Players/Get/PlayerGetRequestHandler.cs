using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlayersApi.Pipeline;

namespace PlayersApi.Features.Players.Get {
    public class PlayerGetRequestHandler : IRequestHandler<PlayerGetRequest, PlayerGet> {
        private IPlayersRepository _repository;
        private IBadgesClient _badgesClient;

        public PlayerGetRequestHandler(IPlayersRepository repository,
                                       IBadgesClient badgesClient) {
            _repository = repository;
            _badgesClient = badgesClient;
        }

        public async Task<PlayerGet> Handle(PlayerGetRequest request, CancellationToken cancellationToken) {
            var player = await _repository.Get(request.Id);
            if (player == null) {
                throw ApiException.NotFound(request.Id);
            }
            player.Badges = await _badgesClient.Get(request.Id);
            return player;
        }
    }
}