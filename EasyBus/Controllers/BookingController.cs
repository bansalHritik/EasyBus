using EasyBus.Business;
using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("Get")]
        public IActionResult Get(int bookingId)
        {
            return this.GetResponse(bookingBDC.Get(bookingId));
        }

        [HttpGet("ByUser")]
        public IActionResult GetBookingsByUsers()
        {
            return this.GetResponse(bookingBDC.GetAllBookingByUser());
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return this.GetResponse(bookingBDC.GetAll());
        }

        [HttpPost("New")]
        public IActionResult NewBooking(NewBookingModel newBooking)
        {
            return this.GetResponse(bookingBDC.AddBooking(newBooking));
        }
    }
}