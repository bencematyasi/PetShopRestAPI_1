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

            string password = "1234";
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            Console.WriteLine();

            Owner owner1 = new Owner
            {
                FirstName = "Dave",
                LastName = "McColgan",
                Address = "93 Mendota Road",
                Email = "dave@fakemail.com",
                PhoneNumber = "52467277",
                Username = "ASD",
                IsAdmin = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            Owner owner2 = new Owner
            {
                FirstName = "Munroe",
                LastName = "Wardlaw",
                Address = "6 Commercial Lane",
                Email = "mwardlaw7@fakemail.com",
                PhoneNumber = "53595277",
                Username = "ASDASD",
                IsAdmin = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            

            Owner owner3 = ctx.Owners.Add(new Owner
            {
                FirstName = "James",
                LastName = "McAdams",
                Address = "11 Daytona Road",
                Email = "jamesmcadams@fakemail.com",
                PhoneNumber = "4550798879"
            }).Entity;

            Owner owner4 = ctx.Owners.Add( new Owner
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
            ctx.Owners.Add(owner1);
            ctx.Owners.Add(owner2);
            ctx.Owners.Add(owner3);
            ctx.Owners.Add(owner4);
            ctx.SaveChanges();
        }

        // This method computes a hashed and salted password using the HMACSHA512 algorithm.
        // The HMACSHA512 class computes a Hash-based Message Authentication Code (HMAC) using 
        // the SHA512 hash function. When instantiated with the parameterless constructor (as
        // here) a randomly Key is generated. This key is used as a password salt.

        // The computation is performed as shown below:
        //   passwordHash = SHA512(password + Key)

        // A password salt randomizes the password hash so that two identical passwords will
        // have significantly different hash values. This protects against sophisticated attempts
        // to guess passwords, such as a rainbow table attack.
        // The password hash is 512 bits (=64 bytes) long.
        // The password salt is 1024 bits (=128 bytes) long.
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}