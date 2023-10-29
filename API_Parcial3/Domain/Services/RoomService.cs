using API_Parcial3.DAL;
using API_Parcial3.DAL.Entities;
using API_Parcial3.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace API_Parcial3.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly DataBaseContext _context;
        public RoomService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Room> GetAvailableRoomsAsync(Guid id, int number)
        {
            var room = await _context.Rooms.Include(o => o.Hotel).FirstOrDefaultAsync(r => r.HotelId == id && r.Number == number);

            if (room == null)
            {
                return null;
            }

            return room;
        }

    }
}
