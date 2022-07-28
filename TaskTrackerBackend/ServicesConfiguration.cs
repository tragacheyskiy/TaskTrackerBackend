using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using TaskTrackerBackend.Data;
using TaskTrackerBackend.Data.QueryServices;
using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Providers;
using TaskTrackerBackend.Domain.Providers.Abstractions;
using TaskTrackerBackend.Domain.Queries;
using TaskTrackerBackend.Dtos;
using TaskTrackerBackend.Options;
using TaskTrackerBackend.Validation;
using TaskTrackerBackend.Validation.Abstractions;

namespace TaskTrackerBackend;

internal static class ServicesConfiguration
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options => options.SchemaGeneratorOptions.SupportNonNullableReferenceTypes = true)
            .AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                var dbOptions = serviceProvider.GetRequiredService<IOptionsSnapshot<DbOptions>>().Value;
                options.UseNpgsql(dbOptions.ConnectionString);
            })
            .AddCommandsAndQueries()
            .AddServices();

        builder.Services
            .Configure<DbOptions>(options => builder.Configuration.GetRequiredSection(nameof(DbOptions)).Bind(options))
            .AddSingleton<IDateTimeProvider, DateTimeProvider>()
            .AddScoped<IValidationService<NewProjectTaskDto>, ProjectTaskValidationService>();
    }

    private static IServiceCollection AddCommandsAndQueries(this IServiceCollection services)
    {
        foreach (Type type in typeof(ICommand).Assembly.GetTypes())
        {
            bool validTypeName = type.Name.EndsWith("Commands") || type.Name.EndsWith("Queries");

            if (!type.IsAbstract && validTypeName)
            {
                services.TryAddScoped(type.GetInterfaces().Single(), type);
            }
        }

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        Type[] types = typeof(AppDbContext).Assembly.GetTypes();
        Type commandService = typeof(ICommandService<>);
        Type queryService = typeof(IQueryService<,>);

        var mappings = from type in types
                       where !type.IsAbstract && !type.IsGenericType
                       from i in type.GetInterfaces()
                       where i.IsGenericType
                       let gType = i.GetGenericTypeDefinition()
                       where gType == commandService || gType == queryService
                       select (i, type);

        foreach ((Type service, Type implementation) in mappings)
        {
            services.TryAdd(new ServiceDescriptor(service, implementation, ServiceLifetime.Scoped));
        }

        services.TryAddScoped<IQueryService<EntityExistsQuery<Project>, bool>, EntityExistsQueryService<Project>>();
        services.TryAddScoped<IQueryService<EntityExistsQuery<ProjectTask>, bool>, EntityExistsQueryService<ProjectTask>>();

        return services;
    }
}
