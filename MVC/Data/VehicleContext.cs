using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }
        public DbSet<VehicleMake> Makes { get; set; }
        public DbSet<VehicleModel> Models { get; set; }
    }
}
