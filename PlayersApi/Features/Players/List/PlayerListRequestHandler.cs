using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlayersApi {
    public class PlayerListRequestHandler : IRequestHandler<PlayerListRequest, List<PlayerItem>> {
        private readonly IPlayersRepository _repository;

        public PlayerListRequestHandler(IPlayersRepository repository) {
            _repository = repository;
        }

        public async Task<List<PlayerItem>> Handle(PlayerListRequest request, CancellationToken cancellationToken) {
            return await _repository.List();
        }
    }
}