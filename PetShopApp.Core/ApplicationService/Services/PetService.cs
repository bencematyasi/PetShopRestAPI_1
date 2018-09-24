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
        public Pet FindPetById(int id)
        {
            Pet pet = _petRepo.ReadAll().FirstOrDefault(o => o.Id == id);
            pet.owner = _ownerRipo.GetOwnerById(id);
            return pet;
        }
        public List<Pet> GetAllPets()
        {
            
            return _petRepo.ReadAll().ToList();
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            return _petRepo.Update(petUpdate);
        }
   
        public void DeletePet(int id)
        {
            _petRepo.Delete(id);
        }

        public Pet FindPetByIdIncludeOwner(int id)
        {
            return _petRepo.FindPetByIdIncludeOwner(id);
        }
    }
}
