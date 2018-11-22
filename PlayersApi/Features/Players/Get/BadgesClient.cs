using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlayersApi.Features.Players.Get {
    public class BadgesClient : IBadgesClient {
        private readonly HttpClient _client;

        public BadgesClient(HttpClient client) {
            _client = client;
        }

        public async Task<List<BadgeGet>> Get(string userid) {
            var resp = await _client.GetAsync("/badges/" + userid);
            return await resp.Content.ReadAsAsync<List<BadgeGet>>();
        }
    }
}
