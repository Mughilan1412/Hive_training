using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add configuration sources
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var app = builder.Build();

// Read values
var aspnetEnv = builder.Environment.EnvironmentName; // ASPNETCORE_ENVIRONMENT
var currentEnv = builder.Configuration["InputEnvironmentName"] ?? "Not Set";
var connectionString = builder.Configuration["Database:ConnectionString"] ?? "Not Set";

app.MapGet("/", () =>
{
    var html =
        "<html>" +
        "<head>" +
        "<title>Configuration Values</title>" +
        "<style>" +
        "body { font-family: Arial, sans-serif; margin: 40px; background: #f9f9f9; color: #333; }" +
        "h1 { color: #444; }" +
        ".box { background: white; padding: 20px; border-radius: 10px; box-shadow: 0 2px 6px rgba(0,0,0,0.1); width: 400px; }" +
        ".item { margin: 10px 0; font-size: 18px; }" +
        ".label { font-weight: bold; }" +
        "</style>" +
        "</head>" +
        "<body>" +
        "<h1>Configuration</h1>" +
        "<div class='box'>" +
        $"<div class='item'><span class='label'>ASPNETCORE_ENVIRONMENT:</span> {aspnetEnv}</div>" +
        $"<div class='item'><span class='label'>CurrentEnvironment:</span> {currentEnv}</div>" +
        $"<div class='item'><span class='label'>Database:ConnectionString:</span> {connectionString}</div>" +
        "</div>" +
        "</body>" +
        "</html>";

    return Results.Content(html, "text/html");
});

app.Run();
