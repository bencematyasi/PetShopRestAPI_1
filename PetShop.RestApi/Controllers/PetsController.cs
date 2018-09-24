using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;

namespace PetShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petservice;

        public PetsController(IPetService petService)
        {
            _petservice = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petservice.GetAllPets();
        }

        // GET api/pets/1
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petservice.FindPetByIdIncludeOwner(id);
        }

        // POST api/pets
        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            _petservice.NewPet(pet);
        }

        // POST api/pets
        [HttpPost ("multipost")]
        public void Post([FromBody] Pet[] pets)
        {
            foreach (var pet in pets)
            {
                _petservice.NewPet(pet);
            }
        }

        // PUT api/pets/1
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id)
            {
                return BadRequest("Parameter id and pet Id must be the same");
            }
            return _petservice.UpdatePet(pet);
        }


        // DELETE api/pets/1
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            _petservice.DeletePet(id);
            return Ok("Deleted");
        }
    }
}
