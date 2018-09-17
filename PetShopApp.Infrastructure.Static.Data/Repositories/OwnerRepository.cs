using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        
        public Owner CreatOwner(Owner owner)
        {
            owner.Id = FakeDB.OwnerId++;
            var owners = FakeDB.Owners.ToList();
            owners.Add(owner);
            FakeDB.Owners = owners;
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            var owners = FakeDB.Owners.ToList();
            var ownerToDelete = owners.FirstOrDefault(o => o.Id == id);
            owners.Remove(ownerToDelete);
            FakeDB.Owners = owners;
            return ownerToDelete;
        }

        public Owner GetOwnerById(int id)
        {
            return FakeDB.Owners.FirstOrDefault(owner => owner.Id == id);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return FakeDB.Owners.ToList();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {

            var ownerFromDB = GetOwnerById(ownerUpdate.Id);
            if (ownerFromDB != null)
            {
                ownerFromDB.FirstName = ownerUpdate.FirstName;
                ownerFromDB.LastName = ownerUpdate.LastName;
                ownerFromDB.PhoneNumber = ownerUpdate.PhoneNumber;
                ownerFromDB.Email = ownerUpdate.Email;
               
                return ownerFromDB;
            }
            return null;
        }
    }
}   
