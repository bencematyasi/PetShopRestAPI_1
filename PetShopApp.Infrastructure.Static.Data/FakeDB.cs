using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data
{
    public class FakeDB
    {
        public static int PetId = 1;

        public static IEnumerable<Pet> Pets;

        public static int OwnerId = 1;

        public static IEnumerable<Owner> Owners;



        public static void InitData()
        {
            Owner owner1 = new Owner
            {
                Id = OwnerId++,
                Address = "Smth street 2",
                Email = "test@easv.dk",
                FirstName = "Emily",
                LastName = "Adams",
                PhoneNumber = "+45 50 16 78 98"
            };

            Owner owner2 = new Owner
            {
                Id = OwnerId++,
                Address = "Smth street 23 A",
                Email = "test2@easv.dk",
                FirstName = "David",
                LastName = "McCurry",
                PhoneNumber = "+45 50 91 11 03"
            };

            Owners = new List<Owner> { owner1, owner2 };
            /*-------------------------------------------------------------------------------------------------------------------------------*/

            Pet brunoDoggy = new Pet
            {
                Id = PetId++,
                Name = "Bruno",
                Type = "dog",
                BirthDay = new DateTime(2010, 10, 05).Date,
                SoldDate = new DateTime(2010, 11, 05).Date,
                Color = "blueish",
                owner = new Owner() { Id = 1 },
                Price = 40
            };
            

            Pet armandCat = new Pet
            {
                Id = PetId++,
                Name = "Armand",
                Type = "cat",
                BirthDay = new DateTime(2014, 11, 19).Date,
                SoldDate = new DateTime(2010, 12, 24).Date,
                Color = "black",
                owner = new Owner() { Id = 2 },
                Price = 30
            };
            Pets = new List<Pet>() { brunoDoggy, armandCat};

        }
    }
}
