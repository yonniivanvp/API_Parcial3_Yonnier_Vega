using API_Parcial3.DAL;
using API_Parcial3.DAL.Entities;
using API_Parcial3.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace API_Parcial3.Domain.Services
{
    public class HotelService : IHotelService
    {
        private readonly DataBaseContext _context;
        public HotelService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsWithAvailableRoomsAsync()
        {
            return await _context.Hotels.Include(o => o.Rooms.Where(r => r.Availability == true)).ToListAsync();
        }

        public async Task<Hotel> GetHotelByIdWithAvailableRoomsAsync(Guid id)
        {
            var hotel = await _context.Hotels.Include(o => o.Rooms.Where(r => r.Availability == true)).FirstOrDefaultAsync(i => i.Id == id);

            if (hotel == null)
            {
                return null;
            }

            return hotel;
        }

        public async Task<Hotel> GetHotelByCityNameAsync(string city)
        {
            var hotel = await _context.Hotels.Include(o => o.Rooms.Where(r => r.Availability == true)).FirstOrDefaultAsync(c => c.City == city);

            if (hotel == null)
            {
                return null;
            }

            return hotel;
        }

        public async Task<Hotel> EditStarsHotelAsync(Guid id, int stars)
        {
            try
            {
                var hotelById = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);

                if (hotelById == null)
                {
                    throw new Exception("The hotel with the specified ID does not exist.");
                }

                hotelById.Stars = stars;
                hotelById.ModifiedDate = DateTime.Now;

                _context.Hotels.Update(hotelById);
                await _context.SaveChangesAsync();

                return hotelById;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Hotel> DeleteHotelAsync(Guid id)
        {
            try
            {
                var hotel = await _context.Hotels.Include(r => r.Rooms).FirstOrDefaultAsync(h => h.Id == id);
                if (hotel == null) return null;

                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                return hotel;
            }
            catch (DbUpdateException dbex)
            {
                throw new Exception(dbex.InnerException?.Message ?? dbex.Message);
            }
        }
    }
}
