using E_Commerce.Infrastructure.Extension;
using E_Commerce.Business.Dtos;
using E_Commerce.Business.Services;
using E_Commerce.Infrastructure.Interfaces;
using E_Commerce.Infrastructure.Repositories;
using E_Commerce.Shared.Models;
using AutoMapper;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(E_Commerce.Business.AutoMapper.AutoMapperProfiles));
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddInfrastructureService(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<Service<Product, ProductDto>>();

var app = builder.Build();

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
