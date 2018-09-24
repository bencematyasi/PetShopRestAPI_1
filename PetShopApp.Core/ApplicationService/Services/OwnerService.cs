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

        public OwnerService (IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
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

    }
}
