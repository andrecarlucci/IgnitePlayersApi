using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using Serilog.Context;
using System;
using System.Threading.Tasks;

namespace PlayersApi.Pipeline {
    public class LogRequestMiddleware {
        private readonly RequestDelegate _next;

        public LogRequestMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            var request = context.Request;
            var requestId = request.Headers["X-RequestId"].ToString();
            using (LogContext.PushProperty("RequestId", requestId)) {
                Exception exception = null;
                try {
                    await _next(context);
                }
                catch (Exception ex) {
                    exception = ex;
                    throw;
                }
                finally {
                    Log.Logger.Information(exception, "Request: {Url}", request.GetEncodedUrl());
                }
            }
        }
    }
}
