using System.Reflection;
using Kabutar.Server.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("Kabutar");

if (builder.Configuration["DB_CONNECTIONSTRING"] is not null)
{
    connectionString = builder.Configuration["DB_CONNECTIONSTRING"].ToString();
}

var applicationUrl = "http://*:8080";

if (builder.Configuration["KABUTAR_BASE_URI"] is not null)
{
    applicationUrl = builder.Configuration["KABUTAR_BASE_URI"].ToString();
}

builder.Services.AddDbContext<KabutarDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services
    .AddMediatR(
        options => 
            options
                .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<KabutarDbContext>();
db.Database.EnsureDeleted();
await db.Database.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(applicationUrl);
