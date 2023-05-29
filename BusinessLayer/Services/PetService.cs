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
    public class PetService
    {
        private readonly IRepository<Pet> _petRepository;

        public PetService(IRepository<Pet> petRepository)
        {
            _petRepository = petRepository;
        }

        public IEnumerable<PetDTO> GetAllPets()
        {
            IEnumerable<Pet> pets = _petRepository.GetAll();
            return pets.Select(MapPetToDTO);
        }

        public PetDTO GetPetById(int id)
        {
            Pet pet = _petRepository.GetById(id);
            return MapPetToDTO(pet);
        }

        public void AddPet(PetDTO petDTO)
        {
            Pet pet = MapDTOToPet(petDTO);
            _petRepository.Add(pet);
        }

        public void UpdatePet(PetDTO petDTO)
        {
            Pet existingPet = _petRepository.GetById(petDTO.Id);
            if (existingPet != null)
            {
                existingPet.Name = petDTO.Name;
                // Update other properties
                _petRepository.Update(existingPet);
            }
        }

        public void DeletePet(int id)
        {
            Pet pet = _petRepository.GetById(id);
            if (pet != null)
            {
                _petRepository.Delete(pet);
            }
        }

        private PetDTO MapPetToDTO(Pet pet)
        {
            if (pet == null)
                return null;

            return new PetDTO
            {
                Id = pet.PetId,
                Name = pet.Name,
                // Map other properties
            };
        }

        private Pet MapDTOToPet(PetDTO petDTO)
        {
            if (petDTO == null)
                return null;

            return new Pet
            {
                PetId = petDTO.Id,
                Name = petDTO.Name,
                // Map other properties
            };
        }
    }
}
