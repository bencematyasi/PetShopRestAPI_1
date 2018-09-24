using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IOwnerService
    {
        //new owner
        Owner NewOwner(Owner owner);

        //read owner
        Owner GetOwnerById(int id);
        //
        List<Owner> GetAllOwners();
        //update owner
        Owner UpdateOwner(Owner updateOwner);

        //delete owner
        void DeleteOwner(int id);

        Owner FindOwnerByIdIncludePets(int id);
    }
}
