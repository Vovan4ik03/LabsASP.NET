using MiddlewareSandbox;

using static MiddlewareSandbox.RequestCounter;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseRequestLogging();   // 1. Логування
app.UseCustomQuery();      // 2. Перевірка параметра custom
app.UseApiKeyCheck();      // 3. Перевірка API ключа
app.UseRequestCounter();   // 4. Підрахунок запитів


app.MapGet("/api/test", () => "Hello from API!");

app.Run();