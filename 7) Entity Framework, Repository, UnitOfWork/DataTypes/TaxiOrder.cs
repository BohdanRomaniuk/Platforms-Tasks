using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _7__Entity_Framework__Repository__UnitOfWork.DataTypes
{
    public class TaxiOrder
    {
        public uint Id { get; set; }
        
        public uint ClientId { get; set; }
        
        public uint DriverId { get; set; }
        
        public DateTime ArriveTime { get; set; }

        [MaxLength(200)]
        [Required]
        public string Dispatch { get; set; }

        [MaxLength(200)]
        [Required]
        public string Destination { get; set; }

        [Required]
        public uint RoadTime { get; set; }

        [Required]
        public uint Cost { get; set; }

        [Required]
        public bool IsDone { get; set; }

        public TaxiOrder()
        {
        }
        public TaxiOrder(uint _id, uint _clientId, uint _driverId, DateTime _arrive, string _dispatch, string _destination, uint _roadTime, uint _cost = 0, bool _isDone = false)
        {
            Id = _id;
            ClientId = _clientId;
            DriverId = _driverId;
            ArriveTime = _arrive;
            Dispatch = _dispatch;
            Destination = _destination;
            RoadTime = _roadTime;
            Cost = _cost;
            IsDone = _isDone;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", Id, ClientId, DriverId, ArriveTime.ToString("yyyy-MM-dd_HH:mm"), Dispatch, Destination, RoadTime, Cost, IsDone);
        }
    }
}
