using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class OrderItem
    {
        public OrderItem(object inventory, int v)
        {
            Inventory = inventory;
            V = v;
        }

        [Key]
        public int OrderItemId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int PetId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]

        public Order Order { get; set; }
        public Pet Pet { get; set; }
        public object Inventory { get; }
        public int V { get; }
    }
}
