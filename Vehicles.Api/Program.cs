using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Vehicles.Api.Mapping;
using Vehicles.Application.Interfaces;
using Vehicles.Application.Services;
using Vehicles.Infrastructure;
using Vehicles.Infrastructure.Interfaces;
using Vehicles.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://vegaprojectluis.eu.auth0.com/";
    options.Audience = "https://api.vega.com";
});

builder.Services.AddScoped<IVehiclesService, VehiclesService>();
builder.Services.AddScoped<IModelsService, ModelsService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IVehicleRepository, VehiclesRepository>();
builder.Services.AddScoped<IMakeRepository, MakesRepository>();
builder.Services.AddAutoMapper(x => x.AddProfile<MappingProfile>());
builder.Services.AddDbContext<VehiclesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("vehiclesDb")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.Run();