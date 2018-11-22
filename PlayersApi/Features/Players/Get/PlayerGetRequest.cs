using Microsoft.AspNetCore.Mvc;

namespace PlayersApi {
    public class PlayerGetRequest {
        [FromRoute(Name = "id")]
        public string Id { get; set; }
    }
}