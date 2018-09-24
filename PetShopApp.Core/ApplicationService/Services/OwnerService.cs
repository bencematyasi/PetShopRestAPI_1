using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetRepository _petRepository;

        public OwnerService (IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            _ownerRepository = ownerRepository;
            _petRepository = petRepository;
        }
        public Owner NewOwner(Owner owner)
        {
            return _ownerRepository.CreatOwner(owner);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.ReadAll().ToList();
        }

        public Owner UpdateOwner(Owner updateOwner)
        {
            return _ownerRepository.UpdateOwner(updateOwner);
        }
        public void DeleteOwner(int id)
        {
            _ownerRepository.DeleteOwner(id);
        }

        public Owner GetOwnerById(int id)
        {
            Owner owner = _ownerRepository.ReadAll().FirstOrDefault(o => o.Id == id);
            return owner;
        }

        public Owner FindOwnerByIdIncludePets(int id)
        {
            var owner = _ownerRepository.GetOwnerById(id);
            owner.Pets = _petRepository.ReadAll().Where(pet => pet.owner != null && pet.owner.Id == owner.Id).ToList();
            return owner;
           
        }
    }
}
