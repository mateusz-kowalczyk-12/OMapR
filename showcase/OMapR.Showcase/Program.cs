using OMapR.Api;
using OMapR.Api.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddCors(options => options.DefaultPolicyName = "AllowAll");

builder.Services.AddOMapR(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new ArgumentException("Connection string not found.")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var score = app.Services.CreateScope())
{
    var pProxy = app.Services.GetRequiredService<IPersistenceProxy>();
    pProxy.ConnectToDb();
}

app.Run();