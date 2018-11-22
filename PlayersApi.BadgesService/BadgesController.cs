using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PlayersApi.BadgesService {
    public class BadgesController : ControllerBase {

        [HttpGet("/badges/{userid}")]
        public ActionResult<List<BadgeItem>> List([FromQuery]BadgeGetRequest request) {
            return new List<BadgeItem> {
                new BadgeItem {
                    ImageUrl = "http://localhost/badge1.jpg",
                    Name = "Super Badge I"
                },
                new BadgeItem {
                    ImageUrl = "http://localhost/badge2.jpg",
                    Name = "Super Badge II"
                }
            };
        }
    }
}
