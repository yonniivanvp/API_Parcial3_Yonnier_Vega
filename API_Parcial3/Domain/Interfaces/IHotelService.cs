using API_Parcial3.DAL;
using API_Parcial3.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace API_Parcial3.Domain.Interfaces
{

    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotelsWithAvailableRoomsAsync();
        Task<Hotel> GetHotelByIdWithAvailableRoomsAsync(Guid id);
        Task<Hotel> GetHotelByCityNameAsync(string city);
        Task<Hotel> EditStarsHotelAsync(Guid id, int stars);
        Task<Hotel> DeleteHotelAsync(Guid id);
    }
}
