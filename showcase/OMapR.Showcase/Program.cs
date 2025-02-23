using OMapR.Api;
using OMapR.Showcase;
using OMapR.Showcase.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddCors(options => options.DefaultPolicyName = "AllowAll");

builder.Services.AddPersistence(builder);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var pProxy = app.Services.GetRequiredService<PersistenceProxy>();
    
    var teachers = pProxy.AccessEntity<Teacher>().ToList();
    var students = pProxy.AccessEntity<Student>().ToList();
}

app.Run();