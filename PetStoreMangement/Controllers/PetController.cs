using BusinessLayer.DTO;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace PetStoreMangement.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly PetService _petService;

        public PetController(PetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PetDTO>> GetAllPets()
        {
            IEnumerable<PetDTO> pets = _petService.GetAllPets();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public ActionResult<PetDTO> GetPetById(int id)
        {
            PetDTO pet = _petService.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        [HttpPost]
        public ActionResult CreatePet(PetDTO petDTO)
        {
            _petService.AddPet(petDTO);
            return CreatedAtAction(nameof(GetPetById), new { id = petDTO.Id }, petDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePet(int id, PetDTO petDTO)
        {
            if (id != petDTO.Id)
            {
                return BadRequest();
            }

            _petService.UpdatePet(petDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePet(int id)
        {
            _petService.DeletePet(id);
            return NoContent();
        }
    }
}
