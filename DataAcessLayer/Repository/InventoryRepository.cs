using DataAcessLayer.Database;
using DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repository
{
    public class InventoryRepository : IRepository<Inventory>
    {
        private readonly AppDbContext _dbContext;

        public InventoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Inventory> GetAllInventoryItems()
        {
            return _dbContext.Inventory.ToList();
        }

        public Inventory GetInventoryItemById(int inventoryItemId)
        {
            return _dbContext.Inventory
                .FirstOrDefault(i => i.InventoryItemId == inventoryItemId);
        }

        public void AddInventoryItem(Inventory inventoryItem)
        {
            _dbContext.Inventory.Add(inventoryItem);
            _dbContext.SaveChanges();
        }

        public void UpdateInventoryItem(Inventory inventoryItem)
        {
            _dbContext.Inventory.Update(inventoryItem);
            _dbContext.SaveChanges();
        }

        public void DeleteInventoryItem(Inventory inventoryItem)
        {
            _dbContext.Inventory.Remove(inventoryItem);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Inventory> GetAll()
        {
            throw new NotImplementedException();
        }

        public Inventory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Inventory entity)
        {
            throw new NotImplementedException();
        }
    }
}
