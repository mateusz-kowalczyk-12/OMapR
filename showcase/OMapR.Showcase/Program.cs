using OMapR.Api;
using OMapR.Api.DependencyInjection;
using OMapR.Showcase.Entities;

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

using (var scope = app.Services.CreateScope())
{
    var pProxy = app.Services.GetRequiredService<IPersistenceProxy>();

    pProxy
        .AddEntityMapping<Teacher>()
        .SetTableName("TEACHERS")
        .SetPrimaryKey(teacher => teacher.Number)
        .MapProperty(teacher => teacher.Number, "TNO")
        .MapProperty(teacher => teacher.Name, "TNAME")
        .MapProperty(teacher => teacher.Title, "TITLE")
        .MapProperty(teacher => teacher.City, "CITY");

    pProxy
        .AddEntityMapping<Student>()
        .SetTableName("STUDENTS")
        .SetPrimaryKey(student => student.Number)
        .MapProperty(student => student.Number, "SNO")
        .MapProperty(student => student.Name, "SNAME")
        .MapProperty(student => student.Year, "SYEAR")
        .MapProperty(student => student.City, "CITY");
    
    var teachers = pProxy.AccessEntity<Teacher>().ToList();
    var students = pProxy.AccessEntity<Student>().ToList();
}

app.Run();