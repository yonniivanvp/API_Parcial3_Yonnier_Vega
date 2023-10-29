using API_Parcial3.DAL;
using API_Parcial3.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace API_Parcial3.Domain.Interfaces
{

    public interface IRoomService
    {
        Task<Room> GetAvailableRoomsAsync(Guid id, int number);
    }
}
