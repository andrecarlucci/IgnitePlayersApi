using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace PlayersApi {
    public class PlayerPostRequestHandler : IRequestHandler<PlayerPostRequest, Player> {
        private readonly IPlayersRepository _playersRepository;

        public PlayerPostRequestHandler(IPlayersRepository playersRepository) {
            _playersRepository = playersRepository;
        }

        public async Task<Player> Handle(PlayerPostRequest request, CancellationToken cancellationToken) {
            return await _playersRepository.Add(request);
        }
    }
}