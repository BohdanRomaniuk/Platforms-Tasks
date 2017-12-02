using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _7__Entity_Framework__Repository__UnitOfWork.DataTypes
{
    [Table("Orders")]
    public class TaxiOrder
    {
        [Key]
        public int OrderNumber { get; set; }

        public TaxiClient ClientId { get; set; }
        
        public TaxiDriver DriverId { get; set; }
        
        [Required]
        public DateTime ArriveTime { get; set; }

        [MaxLength(200)]
        [Required]
        public string Dispatch { get; set; }

        [MaxLength(200)]
        [Required]
        public string Destination { get; set; }

        [Required]
        public int RoadTime { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public bool IsDone { get; set; }

        public TaxiOrder()
        {
        }
        public TaxiOrder(TaxiClient _clientId, TaxiDriver _driverId, DateTime _arrive, string _dispatch, string _destination, int _roadTime, int _cost = 0, bool _isDone = false)
        {
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
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", OrderNumber, ClientId, DriverId, ArriveTime.ToString("yyyy-MM-dd_HH:mm"), Dispatch, Destination, RoadTime, Cost, IsDone);
        }
    }
}
