using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data
{
    public class FakeDB
    {
        public static int id = 1;

        public static List<Pet> Pets;

        public static void InitData()
        {
            Pet brunoDoggy = new Pet
            {
                Id = id++,
                Name = "Bruno",
                Type = "dog",
                BirthDay = new DateTime(2010, 10, 05).Date,
                SoldDate = new DateTime(2010, 11, 05).Date,
                Color = "blueish",
                PreviousOwner = "Danny Boy",
                Price = 40
            };

            Pet armandCat = new Pet
            {
                Id = id++,
                Name = "Armand",
                Type = "cat",
                BirthDay = new DateTime(2014, 11, 19).Date,
                SoldDate = new DateTime(2010, 12, 24).Date,
                Color = "black",
                PreviousOwner = "Alexandra Bummer",
                Price = 30
            };
            Pets = new List<Pet>() { brunoDoggy, armandCat};

        }
    }
}
