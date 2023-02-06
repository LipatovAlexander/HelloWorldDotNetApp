var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

var app = builder.Build();

var url = app.Configuration["BffUrl"] ?? "https://ucgcsaapdd.us-east-1.awsapprunner.com/api";

app.MapGet("/", () => "I am batman!");
app.MapGet("/api", async (IHttpClientFactory factory) =>
{
    var client = factory.CreateClient();
    var s = await client.GetStringAsync(url);
    return s;
});

app.Run();