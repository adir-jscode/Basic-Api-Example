using BasicApiExample.Context;
using BasicApiExample.Logging;
using BasicApiExample.Repositories.Implementations;
using BasicApiExample.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

//DPI
builder.Services.AddScoped<IPatient,PatientRepository>();
builder.Services.AddTransient<IUser, UserRepository>();

//custom logger
builder.Services.AddSingleton<Ilogging, Logging>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
