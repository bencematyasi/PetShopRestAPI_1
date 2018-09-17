using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data
{
   public class PetShopAppContext : DbContext
    {

        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt)
        {

        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

    }
}
