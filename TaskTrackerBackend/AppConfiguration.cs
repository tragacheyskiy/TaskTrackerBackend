using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using TaskTrackerBackend.Data;

namespace TaskTrackerBackend;

internal static class AppConfiguration
{
    private const string DbMigrationCommand = "-m";

    public static WebApplication ConfigureApp(this WebApplication app, string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        using (IServiceScope scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            bool exists = (dbContext.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!.Exists();
            bool isCommand = args.Length > 0 && args[0] == DbMigrationCommand;

            if (!exists || isCommand)
                dbContext.Database.Migrate();
        }
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
