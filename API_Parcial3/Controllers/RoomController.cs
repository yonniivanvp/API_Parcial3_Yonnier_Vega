using API_Parcial3.DAL.Entities;
using API_Parcial3.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Parcial3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet, ActionName("Get")]
        [Route("idHotel/room/{number}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetAvailableRoomsAsync(Guid id, int number)
        {
            if (id == null || number <= 100)
            {
                return BadRequest("Hotel ID or room number is invalid");
            }

            var room = await _roomService.GetAvailableRoomsAsync(id, number);

            if (room == null)
            {
                return NotFound("Room not found");
            }
            else if (room.Availability == false)
            {
                var hotelName = room.Hotel != null ? room.Hotel.Name : "Unkown Hotel";
                return BadRequest($"Room {room.Number} of the hotel {hotelName} already booked");
            }

            return Ok(room);
        }
    }
}
