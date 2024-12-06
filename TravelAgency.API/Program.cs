using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Application.Services;
using TravelAgency.Application.Validation;
using TravelAgency.Domain.Interfaces;
using TravelAgency.Domain.Validation;
using TravelAgency.Infrastructure;
using TravelAgency.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Добавление базы данных
builder.Services.AddDbContext<TravelAgencyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

// Регистрация репозиториев и сервисов
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<TransportService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<TourService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<TourLocationService>();

// Добавление AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddValidatorsFromAssemblyContaining<ClientRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LocationRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TourRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TransportRequestValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();