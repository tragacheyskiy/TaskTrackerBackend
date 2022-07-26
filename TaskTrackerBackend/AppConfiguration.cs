namespace TaskTrackerBackend;

internal static class AppConfiguration
{
    public static WebApplication ConfigureApp(this WebApplication app, string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
