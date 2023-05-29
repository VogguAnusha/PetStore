using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
   public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        [Required]
        public int PetId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Pet Pet { get; set; }
        [Required]
        public int InventoryItemId { get; internal set; }
    }
}
