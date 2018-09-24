using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        //new pet
        Pet NewPet(Pet pet );
        
        //read pet
        Pet FindPetById(int id);
        //
        List<Pet> GetAllPets();
        //update pet
        Pet UpdatePet(Pet pet);
        
        //delete pet
        void DeletePet(int id);
        Pet FindPetByIdIncludeOwner(int id);
    }
}
