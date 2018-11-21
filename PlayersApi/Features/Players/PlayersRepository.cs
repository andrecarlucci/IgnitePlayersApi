using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayersApi {
    public class PlayersRepository : IPlayersRepository {

        private static List<Player> Players = new List<Player> {
                new Player {
                    Name = "Joao",
                    Xp = 100,
                    Age = 22
                },
                new Player {
                    Name = "Maria",
                    Xp = 120,
                    Age = 23
                }
            };

        public Task<Player> Add(PlayerPostRequest post) {
            var player = Player.FromPlayerPost(post);
            Players.Add(player);
            return Task.FromResult(player);
        }

        public Task<List<PlayerItem>> List() {
            var list = Players.Select(p => p.ToPlayerItem()).ToList();
            return Task.FromResult(list);
        }

        public Task<PlayerGet> Get(string id) {
            var get = Players.FirstOrDefault(p => p.Id == id)?
                             .ToPlayerGet();
            return Task.FromResult(get);
        }

        public Task<bool> IsUp() {
            return Task.FromResult(true);
        }
    }
}