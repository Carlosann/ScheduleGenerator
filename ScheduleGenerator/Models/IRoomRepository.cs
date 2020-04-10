using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public interface IRoomRepository
    {
        IQueryable<Room> Rooms { get; }
        void SaveRoom(Room room);
    }
}
