using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomBuilding { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
    }
}
