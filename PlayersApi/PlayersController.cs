using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PlayersApi {
    public class PlayersController : Controller {
        
        [HttpGet("/api/players")]
        public ActionResult<List<PlayerItem>> List() {
            return new List<PlayerItem> {
                new PlayerItem {
                    Nome = "Joao",
                    Xp = 100
                },
                new PlayerItem {
                    Nome = "Maria",
                    Xp = 120
                }
            };
        }
    }
}
