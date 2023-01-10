﻿using API_BARBEARIA.DAL.DAO;
using API_BARBEARIA.DAL.Entities;
using API_BARBEARIA.Manager;
using API_BARBEARIA.Manager.Interfaces;
using API_BARBEARIA.Repository;
using API_BARBEARIA.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Injen��o de Dependencia
builder.Services.AddScoped<IDAO<User>, UserDAO>();
builder.Services.AddScoped<IDAO<Scheduling>, BaseDAO<Scheduling>>();
builder.Services.AddScoped<IDAO<Barber>, BaseDAO<Barber>>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();