using BusinessLayer.DTO;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace PetStoreMangement.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InventoryDTO>> GetAllInventory()
        {
            IEnumerable<InventoryDTO> inventoryItems = _inventoryService.GetAllInventories();
            return Ok(inventoryItems);
        }

        [HttpGet("{id}")]
        public ActionResult<InventoryDTO> GetInventoryById(int id)
        {
            InventoryDTO inventoryItem = _inventoryService.GetInventoryById(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            return Ok(inventoryItem);
        }

        [HttpPost]
        public ActionResult CreateInventory(InventoryDTO inventoryDTO)
        {
            _inventoryService.AddInventory(inventoryDTO);
            return CreatedAtAction(nameof(GetInventoryById), new { id = inventoryDTO.Id }, inventoryDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateInventory(int id, InventoryDTO inventoryDTO)
        {
            if (id != inventoryDTO.Id)
            {
                return BadRequest();
            }

            _inventoryService.UpdateInventory(inventoryDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteInventory(int id)
        {
            _inventoryService.DeleteInventory(id);
            return NoContent();
        }
    }
}
