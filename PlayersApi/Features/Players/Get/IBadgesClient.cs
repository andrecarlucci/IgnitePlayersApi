using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayersApi.Features.Players.Get {
    public interface IBadgesClient {
        Task<List<BadgeGet>> Get(string username);
    }
}
