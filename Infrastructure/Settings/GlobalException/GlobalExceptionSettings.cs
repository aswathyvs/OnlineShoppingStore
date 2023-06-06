using Microsoft.Extensions.Options;
using OnlineShoppingStore.CrossCuttingConcerns.Shared.General.Constants;
using System.Net;

namespace OnlineShoppingStore.Infrastructure.Settings.GlobalException
{
    public class GlobalExceptionSettings
    {
        private IOptions<LogConfiguration> LogConfigurationDetail { get; }

        private readonly RequestDelegate _next;

        public GlobalExceptionSettings(RequestDelegate next, IOptions<LogConfiguration> logConfigurationDetail)
        {
            LogConfigurationDetail = logConfigurationDetail;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await LogAsync(ex);

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(new
            {
                context.Response.StatusCode,
                exception.Message 
            }.ToString());
        }

        public async Task LogAsync(Exception exception)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LogConfigurationDetail.Value.Path))
                    return;

                var logWritePath = LogConfigurationDetail.Value.Path;

                var content = $"Exception Message: {exception.Message} {Environment.NewLine}" +
                    $"InnerException : {exception.InnerException?.Message} {Environment.NewLine}" +
                    $"Stack Trace: {exception.StackTrace}";

                string fileName = $"Log-{DateTime.Now:yyyy-MM-dd HH-mm-ss-fff}.txt";

                if (!Directory.Exists(logWritePath))
                {
                    Directory.CreateDirectory(logWritePath);
                }

                await File.WriteAllTextAsync(Path.Combine(logWritePath, fileName), content);
            }
            catch
            {
                throw new InvalidOperationException(OnlineShoppingStoreConstants.NoLogFile);
            }
        }
    }
}
