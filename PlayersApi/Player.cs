using System;

namespace PlayersApi {
    public class Player {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Age { get; set; }
        public int Xp { get; set; }
        public string Name { get; set; }

        public PlayerItem ToPlayerItem() {
            return new PlayerItem {
                Id = Id,
                Name = Name,
                Xp = Xp
            };
        }

        public PlayerGet ToPlayerGet() {
            return new PlayerGet {
                Id = Id,
                Name = Name,
                Xp = Xp,
                Age = Age
            };
        }

        public static Player FromPlayerPost(PlayerPostRequest post) {
            return new Player {
                Name = post.Name,
                Age = post.Age
            };
        }
    }
}