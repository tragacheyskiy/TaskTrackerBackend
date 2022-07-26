using TaskTrackerBackend;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices();

var app = builder.Build();
app.ConfigureApp(args).Run();
