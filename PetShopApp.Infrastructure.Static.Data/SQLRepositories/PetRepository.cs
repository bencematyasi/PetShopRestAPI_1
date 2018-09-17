using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data.SQLRepositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopAppContext _ctx;

        public PetRepository (PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Pet Create(Pet pet)
        {
             var newPet = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return newPet;
        }
        
        public Pet Delete(int id)
        {
            var petId = ReadById(id); 
            _ctx.Remove(petId);
            _ctx.SaveChanges();
            return petId;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets.ToList();
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            _ctx.Pets.Update(petUpdate);
            _ctx.SaveChanges();
            return petUpdate;
        }
    }
}
