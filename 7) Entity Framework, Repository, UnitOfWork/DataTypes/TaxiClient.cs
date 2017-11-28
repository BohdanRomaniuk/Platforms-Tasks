using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _7__Entity_Framework__Repository__UnitOfWork.DataTypes
{
    public class TaxiClient
    {
        [Key]
        public uint Id { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(13)]
        [Required]
        public string PhoneNumber { get; set; }
        
        public TaxiClient()
        {
        }
        public TaxiClient(uint _id, string _name, string _phoneNumber)
        {
            Id = _id;
            Name = _name;
            PhoneNumber = _phoneNumber;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Id, Name, PhoneNumber);
        }
    }
}
