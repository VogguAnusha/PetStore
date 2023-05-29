using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Pet
    {

        [Key]
        public int PetId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }

    }
}
