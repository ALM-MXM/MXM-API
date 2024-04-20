using MXM.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//CORS CONFIGURATION
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        string[] origins = {"http://localhost:4200"};
        builder.
         WithOrigins(origins)
         .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials(); ;
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
