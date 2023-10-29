using API_Parcial3.DAL.Entities;
using API_Parcial3.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics.Metrics;

namespace API_Parcial3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetHotels")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelsWithAvailableRoomsAsync()
        {
            var hotels = await _hotelService.GetHotelsWithAvailableRoomsAsync();
            if (hotels == null || !hotels.Any())
            {
                return NotFound();
            }
            return Ok(hotels);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelByIdWithAvailableRoomsAsync(Guid id)
        {
            if (id == null) return BadRequest("Id is required!");

            var hotel = await _hotelService.GetHotelByIdWithAvailableRoomsAsync(id);

            if (hotel == null) 
            {
                return NotFound(); //NotFound = 404 Http Status Code
            }

            return Ok(hotel); // OK = 200 Http Status Code
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByCity/{city}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelByCityNameAsync(string city)
        {
            if (city == null) return BadRequest("Id is required!");

            var hotel = await _hotelService.GetHotelByCityNameAsync(city);

            if (hotel == null)
            {
                return NotFound(); //NotFound = 404 Http Status Code
            }

            return Ok(hotel); // OK = 200 Http Status Code
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult> EditStarsHotelAsync(Guid id, int stars)
        {
            try
            {
                var editedHotel = await _hotelService.EditStarsHotelAsync(id, stars);
                if (editedHotel == null)
                {
                    return NotFound("The hotel with the specified ID does not exist."); //NotFound = 404 Http Status Code
                }

                return Ok(editedHotel);//Retorne un 200
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Hotel>> DeleteHotelAsync(Guid id)
        {
            if (id == null) return BadRequest("Id is required");

            var deleteHotel = await _hotelService.DeleteHotelAsync(id);

            if (deleteHotel == null) return NotFound("Hotel nof found");
            return Ok(deleteHotel);
        }

    }
}
