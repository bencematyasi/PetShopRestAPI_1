using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.Data
{
   public class PetShopAppContext : DbContext
    {

        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.owner)
                .WithMany(o => o.Pets);
        }



        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

    }
}
