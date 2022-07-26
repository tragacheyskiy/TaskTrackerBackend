namespace TaskTrackerBackend;

internal static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddControllers();

        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return services;
    }
}
