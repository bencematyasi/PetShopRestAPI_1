using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
       

        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
           
        }

        // GET api/owners
       // [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerRepository.ReadAll().ToList();
        }

        // GET api/owners/1
        //[Authorize]
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        //// GET api/owners/1
        ////[Authorize]
        //[HttpGet("{id}")]
        //public Owner GetOwner(int id)
        //{
        //    return _ownerRepository.FindOwnerByIdIncludePets(id);
        //}

        // POST api/owners
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            Owner result = null;
                if(owner.FirstName == null)
                {
                    BadRequest("The owner has no firstname");
                }
                else if(owner.LastName == null)
                {
                    BadRequest("The owner has no lastname");
                }
                else if(owner.Address == null)
                {
                    BadRequest("The owner has no address");
                }

            try
            {
                result = _ownerRepository.CreatOwner(owner);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

                if  (result != null)
                {
                   return Ok("Owner with ID: " + owner.Id + " has been added!");
                }
                else
                {
                    return BadRequest("Something went wrong!");
                }

        }
        // Post api/pets/multipost
        //[Authorize(Roles = "Administrator")]
        [HttpPost("multipost")]
        public ActionResult<Owner> PostMulti([FromBody] Owner[] owners)
        {

            bool passed = true;
            foreach (Owner owner in owners)
            {
                Owner result = _ownerRepository.CreatOwner(owner);
                if (result == null)
                    passed = false;
            }
            if (passed)
                return Ok("Owners with has been added!");
            else
                return BadRequest("Something went wrong!");
        }


        // PUT api/owners/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id)
            {
                return BadRequest("Parameter id and pet Id must be the same");
            }
            Owner result = _ownerRepository.UpdateOwner(owner);
            if (result != null)
                return Ok("Owner with ID: " + id + " has been updated!");
            else
                return BadRequest("Something went wrong!");
        }


        // DELETE api/owners/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            Owner result = _ownerRepository.DeleteOwner(id);
            if (result != null)
                return Ok("Owner with ID: " + id + " has been deleted!");
            else
                return BadRequest("Something went wrong!");
        }
    }
}
