using Microsoft.EntityFrameworkCore;
using Survey.API;
using Survey.API.Filter;
using Survey.DAL.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ControllerExceptionFilter>(int.MinValue);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Program extensions.
builder.Services.AddAppHandlers();

builder.Services.AddAppVersioning();

builder.Services.AddDbContext<PostgreSQLContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
});

var app = builder.Build();

app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
