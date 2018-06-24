using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InventoryManagement.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<testModel> testTable { get; set; }

        public DbSet<Material> Materials { get; set; }
        public DbSet<BOM_Header> BOM_Headers { get; set; }
        public DbSet<BOM_Item> BOM_Items { get; set; }

        public DbSet<WO_Header> WO_Headers { get; set; }
        public DbSet<WO_Item> WO_Items { get; set; }

        public DbSet<StockPosting_Header> StockPosting_Headers { get; set; }
        public DbSet<StockPosting_Item> StockPosting_Items { get; set; }

        public DbSet<PO_Header> PO_Headers { get; set; }
        public DbSet<PO_Item> PO_Items { get; set; }
        public DbSet<SO_Header> SO_Headers { get; set; }
        public DbSet<SO_Item> SO_Items { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}