using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FieldMRIServices.Entities;
using FieldMRIServices.Model;
using Syncfusion.Blazor.Schedule.Internal;

namespace FieldMRIServices.Data
{
    public class FMIventoryDbContext : IdentityDbContext<IdentityUser>
    {
        public FMIventoryDbContext(DbContextOptions<FMIventoryDbContext> options) : base(options)
        {

        }
       
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Photo> Photos { get; set; }
       
    }
}
