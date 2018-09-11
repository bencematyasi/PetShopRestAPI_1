using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;
        private  IOwnerRepository _ownerRipo;

        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepo = petRepository;
            _ownerRipo = ownerRepository;
            
        }
        public Pet NewPet(Pet pet)
        {
            _petRepo.Create(pet);
            return pet;
            
        }

        //public Pet CreatePet(Pet pet)
        //{
        //    return _petRepo.Create(pet);
        //}

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadById(id);
        }

        public List<Pet> GetAllPets()
        {
            List<Pet> pets = _petRepo.ReadAll().ToList();
            foreach (var pet in pets)
            {
                pet.owner = _ownerRipo.GetOwnerById(pet.owner.Id);
            }
            return pets;
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.Type = petUpdate.Type;
            pet.BirthDay = petUpdate.BirthDay;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Color = petUpdate.Color;
            pet.owner = petUpdate.owner;
            pet.Price = petUpdate.Price;

            return pet;
        }
   
        public void DeletePet(int id)
        {
            _petRepo.Delete(id);
        }
        
        public List<Pet> SearchType(string input)
        {
           return _petRepo.ReadAll().Where(p => p.Type == input).ToList() ;
        }

        public List<Pet> SortingPetsList()
        {
           return _petRepo.ReadAll().OrderBy(p => p.Price).ToList();
        }

        public List<Pet> GetFiveCheapsestPets()
        {
            return _petRepo.ReadAll().OrderBy(p => p.Price).Take(5).ToList();
        }
    }
}
