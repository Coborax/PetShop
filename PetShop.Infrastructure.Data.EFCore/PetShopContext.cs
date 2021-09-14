using Microsoft.EntityFrameworkCore;
using PetShop.Infrastructure.Data.EFCore.Entities;

namespace PetShop.Infrastructure.Data.EFCore
{
    public class PetShopContext : DbContext
    {
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }

        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {
        }
    }
}