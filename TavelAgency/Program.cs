using Application.IServices;
using Application.Services;
using Domain.IRepos;
using Infrastructure.Repos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<TravelAgencyDatabaseSettings>(
builder.Configuration.GetSection(nameof(TravelAgencyDatabaseSettings)));

builder.Services.AddSingleton<ITravelAgencyDatabaseSettings>(sp =>
sp.GetRequiredService<IOptions<TravelAgencyDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("TravelDatabaseSettings:ConnectionString")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITravelAgencyDatabaseSettings, TravelAgencyDatabaseSettings>();
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
