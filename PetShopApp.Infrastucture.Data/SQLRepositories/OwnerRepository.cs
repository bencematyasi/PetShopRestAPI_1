﻿using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.Data.SQLRepositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetShopAppContext _ctx;

        public OwnerRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }
        public Owner CreatOwner(Owner owner)
        {
            var newOwner = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return newOwner;
        }

        public Owner DeleteOwner(int id)
        {
            var ownerId = GetOwnerById(id);
            _ctx.Owners.Remove(ownerId);
            _ctx.SaveChanges();
            return ownerId;
        }

        public Owner FindOwnerByIdIncludePets(int id)
        {
            return _ctx.Owners.Where(o => o.Id == id).Include(o => o.Pets).FirstOrDefault();
        }

        public Owner GetOwnerById(int id)
        {
            var changeTracker = _ctx.ChangeTracker.Entries<Owner>();
            return _ctx.Owners.FirstOrDefault(owner => owner.Id == id);   
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _ctx.Owners.ToList();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            _ctx.Attach(ownerUpdate).State = EntityState.Modified;
            _ctx.Entry(ownerUpdate).Collection(o => o.Pets).IsModified = true;
            _ctx.SaveChanges();
            return ownerUpdate;
        }
    }
}
