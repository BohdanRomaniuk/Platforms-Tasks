using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _7__Entity_Framework__Repository__UnitOfWork.DataTypes
{
    public class Driver
    {
        [Key]
        public uint Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Surname { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public uint Age { get; set; }

        [Required]
        public string CarNumber { get; set; }

        [Required]
        public uint Experience { get; set; }

        [Required]
        public uint CostPerMinute { get; set; }

        [Required]
        public double PayCheck { get; set; }

        public Driver()
        {
            PayCheck = 0;
        }
        public Driver(uint _id, string _surname, string _name, uint _age, string _carNumber, uint _experience, uint _cost, double _pay = 0)
        {
            Id = _id;
            Surname = _surname;
            Name = _name;
            Age = _age;
            CarNumber = _carNumber;
            Experience = _experience;
            CostPerMinute = _cost;
            PayCheck = _pay;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", Id, Surname, Name, Age, CarNumber, Experience, CostPerMinute, PayCheck);
        }
    }
}
