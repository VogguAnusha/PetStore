using BusinessLayer.DTO;
using DataAcessLayer.Models;
using DataAcessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class InventoryService
    {
        private readonly IRepository<Inventory> _inventoryRepository;

        public InventoryService(IRepository<Inventory> inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public IEnumerable<InventoryDTO> GetAllInventories()
        {
            IEnumerable<Inventory> inventories = _inventoryRepository.GetAll();
            return inventories.Select(MapInventoryToDTO);
        }

        public InventoryDTO GetInventoryById(int id)
        {
            Inventory inventory = _inventoryRepository.GetById(id);
            return MapInventoryToDTO(inventory);
        }

        public void AddInventory(InventoryDTO inventoryDTO)
        {
            Inventory inventory = MapDTOToInventory(inventoryDTO);
            _inventoryRepository.Add(inventory);
        }

        public void UpdateInventory(InventoryDTO inventoryDTO)
        {
            Inventory existingInventory = _inventoryRepository.GetById(inventoryDTO.Id);
            if (existingInventory != null)
            {
                existingInventory.Quantity = inventoryDTO.Quantity;
                // Update other properties
                _inventoryRepository.Update(existingInventory);
            }
        }

        public void DeleteInventory(int id)
        {
            Inventory inventory = _inventoryRepository.GetById(id);
            if (inventory != null)
            {
                _inventoryRepository.Delete(inventory);
            }
        }

        private InventoryDTO MapInventoryToDTO(Inventory inventory)
        {
            if (inventory == null)
                return null;

            return new InventoryDTO
            {
                Id = inventory.InventoryId,
                Quantity = inventory.Quantity,
                // Map other properties
            };
        }

        private Inventory MapDTOToInventory(InventoryDTO inventoryDTO)
        {
            if (inventoryDTO == null)
                return null;

            return new Inventory
            {
                InventoryId = inventoryDTO.Id,
                Quantity = inventoryDTO.Quantity,
                // Map other properties
            };
        }
    }
}
