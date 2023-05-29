using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public List<OrderItem> OrderItems { get; set; }

    }
}
