using Microsoft.EntityFrameworkCore;
using Vehicles.Infrastructure.Entities;

namespace Vehicles.Infrastructure;

public class VehiclesDbContext : DbContext
{
    public DbSet<Make> Makes { get; set; }

    public DbSet<Model> Models { get; set; }

    public DbSet<Vehicle?> Vehicles { get; set; }

    public VehiclesDbContext(DbContextOptions<VehiclesDbContext> options) 
        : base (options)
    {

    }
}