using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Repositories;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IMusicRepository, MusicRepository>();
builder.Services.AddScoped<IMusicService, MusicService>();

builder.Services.AddDbContext<MusicDbContext>(opt =>
{
    string conString = builder.Configuration.GetConnectionString("Default");
    opt.UseSqlServer(conString);
});

//dotnet new tool-manifest
//dotnet tool install dotnet-ef
//dotnet ef migrations add Init
//dotnet ef database update

//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Design

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

