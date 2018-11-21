using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayersApi {
    public interface IPlayersRepository {
        Task<Player> Add(PlayerPostRequest player);
        Task<PlayerGet> Get(string id);
        Task<List<PlayerItem>> List();
    }
}