using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PlayersApi {
    public class PlayerGetRequest : IRequest<PlayerGet> {
        [FromRoute(Name = "id")]
        public string Id { get; set; }
    }
}