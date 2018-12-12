using MediatR;
using System.Collections.Generic;

namespace PlayersApi {
    public class PlayerListRequest : IRequest<List<PlayerItem>> {

    }
}