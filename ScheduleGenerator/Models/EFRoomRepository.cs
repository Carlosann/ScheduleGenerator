using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleGenerator.Models
{
    public class EFRoomRepository : IRoomRepository
    {
        private ApplicationDbContext context;
        public EFRoomRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Room> Rooms => context.Rooms;

        public void SaveRoom(Room room)
        {
            if (room.RoomID == 0)
            {
                context.Rooms.Add(room);
            }
            else
            {
                Room roomEntry = context.Rooms
                    .FirstOrDefault(r => r.RoomID == room.RoomID);
                if (roomEntry != null)
                {
                    roomEntry.RoomBuilding = room.RoomBuilding;
                    roomEntry.RoomNumber = room.RoomNumber;
                }
            }
            context.SaveChanges();
        }
    }
}
