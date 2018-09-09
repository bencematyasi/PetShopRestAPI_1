using System;

public static class FakeDB
{
    public static int id = 1;
    public static List <>;
    public static List<Pet> Pets;

        void InitData()
        {
            Pet brunoDoggy = new Pet
            {
                Name = "Bruno",
                Type = "dog",
                BirthDay = new DateTime(2010, 10, 05).Date,
                SoldDate = new DateTime(2010, 11, 05).Date,
                Color = "blueish",
                PreviousOwner = "Danny Boy",
                Price = 40
            };
            _petService.CreatePet(brunoDoggy);

            Pet armandCat = new Pet
            {
                Name = "Armand",
                Type = "cat",
                BirthDay = new DateTime(2014, 11, 19).Date,
                SoldDate = new DateTime(2010, 12, 24).Date,
                Color = "black",
                PreviousOwner = "Alexandra Bummer",
                Price = 30
            };
            _petService.CreatePet(armandCat);

            Pet sammyTurtle = new Pet
            {
                Name = "Sammy",
                Type = "turtle",
                BirthDay = new DateTime(2012, 01, 03).Date,
                SoldDate = new DateTime(2012, 03, 02).Date,
                Color = "green",
                PreviousOwner = "Franco Davis",
                Price = 10
            };
            _petService.CreatePet(sammyTurtle);

            Pet thunderStromHorse = new Pet
            {

                Name = "Thunder Storm",
                Type = "horse",
                BirthDay = new DateTime(2017, 05, 09).Date,
                SoldDate = new DateTime(2017, 08, 15).Date,
                Color = "brownish",
                PreviousOwner = "Chris Richardson ",
                Price = 3000
            };
            _petService.CreatePet(thunderStromHorse);

            Pet lessieDoggy = new Pet
            {
                Name = "Lessie",
                Type = "dog",
                BirthDay = new DateTime(2011, 05, 23).Date,
                SoldDate = new DateTime(2012, 06, 29).Date,
                Color = "white-brownish",
                PreviousOwner = "David Pizzaro",
                Price = 22
            };
            _petService.CreatePet(lessieDoggy);

            Pet furmyCat = new Pet
            {

                Name = "Furmy",
                Type = "cat",
                BirthDay = new DateTime(2008, 02, 10).Date,
                SoldDate = new DateTime(2008, 03, 21).Date,
                Color = "brownish",
                PreviousOwner = "Chris Richardson ",
                Price = 29
            };
            _petService.CreatePet(furmyCat);

        }
}
