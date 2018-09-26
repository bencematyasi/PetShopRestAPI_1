using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
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
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerRepository.ReadAll().ToList();
        }



        // GET api/owners/1
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return _ownerRepository.FindOwnerByIdIncludePets(id);
        }

        // POST api/owners
        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
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

             _ownerRepository.CreatOwner(owner);
            Ok(owner.FirstName + " " + owner.LastName + " owner has been added");

        }
        [HttpPost("multipost")]
        public void MultiPost([FromBody] Owner[] owners)
        {
            
            foreach (var owner in owners)
            {
                _ownerRepository.CreatOwner(owner);
                Ok("The owner with " + owner.FirstName + " " + owner.LastName + "have been added to the database");
            }

        }

        // PUT api/owners/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id)
            {
                return BadRequest("Parameter id and pet Id must be the same");
            }
             _ownerRepository.UpdateOwner(owner);
            return Ok(owner.FirstName + " " + owner.LastName + " owner has been updated");
        }


        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            _ownerRepository.DeleteOwner(id);
            return Ok("Owner with " + id + " have been deleted");
        }
    }
}
