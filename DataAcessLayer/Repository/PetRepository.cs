using DataAcessLayer.Database;
using DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repository
{
    public class PetRepository : IRepository<Pet>
    {
        private readonly AppDbContext _dbContext;

        public PetRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Pet> GetAll()
        {
            return _dbContext.Pets.ToList();
        }

        public Pet GetById(int id)
        {
            return _dbContext.Pets.FirstOrDefault(p => p.PetId == id);
        }

        public void Add(Pet pet)
        {
            _dbContext.Pets.Add(pet);
            _dbContext.SaveChanges();
        }

        public void Update(Pet pet)
        {
            _dbContext.Pets.Update(pet);
            _dbContext.SaveChanges();
        }

        public void Delete(Pet pet)
        {
            _dbContext.Pets.Remove(pet);
            _dbContext.SaveChanges();
        }
    }
}
