using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.Data.SQLRepositories
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
            pet.owner = _ctx.Owners.FirstOrDefault(o => o.Id == pet.owner.Id);
            _ctx.Pets.Add(pet);
            _ctx.SaveChanges();
            return pet;
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
