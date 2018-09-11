using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerRepository.ReadAll().ToList();
        }

        // GET api/owners/1
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
             return _ownerRepository.GetOwnerById(id);
        }

        // POST api/owners
        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
             _ownerRepository.CreatOwner(owner);
        }

        // PUT api/owners/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id)
            {
                return BadRequest("Parameter id and pet Id must be the same");
            }
            return _ownerRepository.UpdateOwner(owner);

        }


        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            _ownerRepository.DeleteOwner(id);
            return Ok("Deleted");
        }
    }
}
