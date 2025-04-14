using Microsoft.OpenApi.Models;
using MXM.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

//CORS CONFIGURATION
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        string[] origins = { "http://localhost:4200", "https://luiza-mxm-frontend.vercel.app" };
        builder.WithOrigins(origins)
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomMiddlewares();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
