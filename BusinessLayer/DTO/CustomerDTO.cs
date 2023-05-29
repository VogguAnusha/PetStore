using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
public CustomerDTO(int Id,string Name,string Email){
this.Id=Id;
this.Name=Name;
this.Email=Email;
    }
}
