using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data.Reporsitories
{
    public class PetRepository : IPetRepository
    {
        public Pet Create(Pet pet)
        {
            pet.Id = FakeDB.PetId++;
            var pets = FakeDB.Pets.ToList();
            pets.Add(pet);
            FakeDB.Pets = pets;
            return pet;
            
        }



        public Pet ReadById(int id)
        {
           return FakeDB.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            var petFromDB = ReadById(petUpdate.Id);
            if (petFromDB != null)
            {
                petFromDB.Name = petUpdate.Name;
                petFromDB.Type = petUpdate.Type;
                petFromDB.BirthDay = petUpdate.BirthDay;
                petFromDB.SoldDate = petUpdate.SoldDate;
                petFromDB.Color = petUpdate.Color;
                petFromDB.owner = petUpdate.owner;
                petFromDB.Price = petUpdate.Price;

                return petFromDB;
            }
            return null;
        }
        public Pet Delete(int id)
        {
            var pets = FakeDB.Pets.ToList();
            var petToDelete = pets.FirstOrDefault(p => p.Id == id);
            pets.Remove(petToDelete);
            FakeDB.Pets = pets;
            return petToDelete;
        }
        
        

        public IEnumerable<Pet> ReadAll()
        {
            
            return FakeDB.Pets;
        }
    }

}
