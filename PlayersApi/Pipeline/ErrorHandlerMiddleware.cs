using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace PlayersApi.Pipeline {
    public class ErrorHandlerMiddleware {
        private readonly IHostingEnvironment _env;

        public ErrorHandlerMiddleware(IHostingEnvironment env) {
            _env = env;
        }

        public async Task Invoke(HttpContext context) {
            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null) {
                return;
            }
            var model = new ProblemDetails {
                Detail = ex.Message
            };
            if (ex is ApiException apiException) {
                context.Response.StatusCode = apiException.HttpStatusCode;
                model.Title = apiException.Title;
            }
            else {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                model.Title = "Server error";
                if (_env.IsDevelopment()) {
                    model.Detail += ": " + ex.StackTrace;
                }
            }
            context.Response.ContentType = "application/json";
            using (var writer = new StreamWriter(context.Response.Body)) {
                new JsonSerializer().Serialize(writer, model);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}