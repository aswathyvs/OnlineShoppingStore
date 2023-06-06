namespace OnlineShoppingStore.Infrastructure.Settings.Log
{
    public static class LogSettings
    {
        public static void LogConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var logConfiguration = configuration
                .GetSection("LogConfiguration")
                .Get<LogConfiguration>();

            services.Configure<LogConfiguration>(configuration.GetSection("logConfiguration"));
        }
    }
}
