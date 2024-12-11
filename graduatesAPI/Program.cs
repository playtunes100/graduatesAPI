using Microsoft.EntityFrameworkCore;
using graduatesAPI.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://playtunes100.github.io",
                                            "https://playtunes100.github.io/_LevelUpAssessment",
                                              "*")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<GraduatesContext>(opt =>
    opt.UseInMemoryDatabase("Graduates"));
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

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://playtunes100.github.io","https://playtunes100.github.io/_LevelUpAssessment","*"));

app.UseAuthorization();

app.MapControllers();

app.Run();
