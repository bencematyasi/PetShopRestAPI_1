using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadAll();
        Owner UpdateOwner(Owner ownerUpdate);
        Owner GetOwnerById(int id);
        Owner CreatOwner(Owner owner);
        void DeleteOwner(int id);

    }
}
