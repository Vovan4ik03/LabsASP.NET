var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/who", () =>
{
    return new { Name = "Volodymyr", Surname = "Makarov"};
});

app.MapGet("/time", () =>
{
    return new { ServerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
});

app.Run();
