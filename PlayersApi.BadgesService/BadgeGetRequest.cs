using Microsoft.AspNetCore.Mvc;

namespace PlayersApi.BadgesService {
    public class BadgeGetRequest {
        [FromRoute]
        public string UserId { get; set; }
    }
}