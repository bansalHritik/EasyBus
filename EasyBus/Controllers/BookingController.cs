using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingBDC bookingBDC;

        public BookingController(IBookingBDC bookingBDC)
        {
            this.bookingBDC = bookingBDC;
        }

        // api/booking/get
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("Get")]
        public IActionResult Get(int bookingId)
        {
            return this.GetResponse(bookingBDC.Get(bookingId));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // api/booking/byUser
        [HttpGet("ByUser")]
        public IActionResult GetBookingsByUsers()
        {
            string currentUserId = this.GetCurrentUser();
            return this.GetResponse(bookingBDC.GetAllBookingByUser(currentUserId));
        }

        // api/booking/getAll
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return this.GetResponse(bookingBDC.GetAll());
        }

        // api/booking/new
        [HttpPost("New")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult NewBooking(NewBookingModel newBooking)
        {
            string currentUserId = this.GetCurrentUser();
            return this.GetResponse(bookingBDC.AddBooking(newBooking, currentUserId));
        }
    }
}