var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapGet("/hello", () => "Hello, World!")
    .WithSummary("Get a greeting")
    .WithDescription("This endpoint returns a friendly greeting.");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
