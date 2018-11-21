using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayersApi.Swagger {
    public static class MyApiConventions {
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(200)]
        public static void List([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)][ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object request) { }
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public static void Get([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)][ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object request) { }
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(400)]
        public static void Post([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)][ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object request) { }
    }
}
