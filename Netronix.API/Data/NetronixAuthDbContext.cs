using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Netronix.API.Data
{
    public class NetronixAuthDbContext : IdentityDbContext
    {
        public NetronixAuthDbContext(DbContextOptions<NetronixAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminId = "45ab5d30-226b-4e5d-a601-013600aa5d90";
            var MarketingUserID = "671a3094-b2af-49bb-bddd-6bf7ff8c8e45";
            var OperationsUserId = "b2b4af0e-f667-4bf3-8e50-40d3d44662ef";
            var TechUserID = "4c02d1da-cfa7-42f5-9392-bf06336f51e4";
            var CustomerId = "d8c83c62-fa3a-46a5-b9da-905c3d7d50e3";


            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminId,
                    ConcurrencyStamp = adminId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = MarketingUserID,
                    ConcurrencyStamp = MarketingUserID,
                    Name = "Merketing",
                    NormalizedName = "Marketing".ToUpper()
                },
                new IdentityRole
                {
                    Id = OperationsUserId,
                    ConcurrencyStamp = OperationsUserId,
                    Name = "Ops",
                    NormalizedName = "Ops".ToUpper()
                },
                new IdentityRole
                {
                    Id = TechUserID,
                    ConcurrencyStamp = TechUserID,
                    Name = "Tech",
                    NormalizedName = "Tech".ToUpper()
                },
                new IdentityRole
                {
                    Id = CustomerId,
                    ConcurrencyStamp = CustomerId,
                    Name = "Customer",
                    NormalizedName = "Customer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

       


           
        }
    }
}
