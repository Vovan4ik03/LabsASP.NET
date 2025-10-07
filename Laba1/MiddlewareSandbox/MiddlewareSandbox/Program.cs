using MiddlewareSandbox;

using static MiddlewareSandbox.RequestCounter;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseRequestLogging();   // 1. ���������
app.UseCustomQuery();      // 2. �������� ��������� custom
app.UseApiKeyCheck();      // 3. �������� API �����
app.UseRequestCounter();   // 4. ϳ�������� ������


app.MapGet("/api/test", () => "Hello from API!");

app.Run();