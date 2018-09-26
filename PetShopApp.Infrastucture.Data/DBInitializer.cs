using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace PetShop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            Owner owner1 = ctx.Owners.Add(new Owner
            {
                FirstName = "James",
                LastName = "McAdams",
                Address = "11 Daytona Road",
                Email = "jamesmcadams@fakemail.com",
                PhoneNumber = "4550798879"
            }).Entity;

            Owner owner2 = ctx.Owners.Add( new Owner
            {
                FirstName = "Jose",
                LastName = "Murdan",
                Address = "7 Fakey Street",
                Email = "josemurdan@fakemail.com",
                PhoneNumber = "57972647"
            }).Entity;
            
            Pet pet1 = new Pet
            {
                Name = "Don",
                Type = "dog",
                BirthDay = DateTime.Now.AddMonths(-5),
                SoldDate = DateTime.Now,
                Color = "Black",
                owner = owner1,
                Price = 110.2
            };

            Pet pet2 = new Pet
            {
                Name = "James",
                Type = "cat",
                BirthDay = DateTime.Now.AddYears(-2),
                SoldDate = DateTime.Now,
                Color = "Cream",
                owner = owner1,
                Price = 398.8
            };

            Pet pet3 = new Pet
            {
                Name = "Ping",
                Type = "duck",
                BirthDay = DateTime.Now.AddYears(-7),
                SoldDate = DateTime.Now.AddYears(-5).AddMonths(-3),
                Color = "Brown",
                owner = owner2,
                Price = 487.5
            };

            Pet pet4 = new Pet
            {
                Name = "Mandel",
                Type = "spider",
                BirthDay = DateTime.Now.AddYears(-1),
                SoldDate = DateTime.Now.AddMonths(-9),
                Color = "Black",
                owner = owner2,
                Price = 499.9
            };

            Pet pet5 = new Pet
            {
                Name = "Lessie",
                Type = "dog",
                BirthDay = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now.AddYears(-4).AddMonths(-9),
                Color = "Whitish brown",
                owner = owner2,
                Price = 624.36
            };


            Pet pet6 = new Pet
            {
                Name = "fishyMisi",
                Type = "Fish",
                BirthDay = DateTime.Now.AddYears(-12),
                SoldDate = DateTime.Now.AddMonths(-96),
                Color = "fos",
                owner = null,
                Price = 14.9
            };

            ctx.Pets.Add(pet1);
            ctx.Pets.Add(pet2);
            ctx.Pets.Add(pet3);
            ctx.Pets.Add(pet4);
            ctx.Pets.Add(pet5);
            ctx.Pets.Add(pet6);
           
            ctx.SaveChanges();
        }
    }
}