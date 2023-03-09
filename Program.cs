using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AzureNet7WebApi.Data;
using AzureNet7WebApi.Controllers;
using AzureNet7WebApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AzureNet7WebApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureNet7WebApiContext") ?? throw new InvalidOperationException("Connection string 'AzureNet7WebApiContext' not found.")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapOrderEndpoints();

app.UseCors();

app.Run();
