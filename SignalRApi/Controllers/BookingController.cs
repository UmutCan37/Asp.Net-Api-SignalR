using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;


        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking();
            {
                booking.Mail = createBookingDto.Mail;
                booking.Date = createBookingDto.Date;
                booking.Name = createBookingDto.Name;
                booking.PersonCount = createBookingDto.PersonCount;
                booking.Phone = createBookingDto.Phone;
            }
            _bookingService.TAdd(booking);
            return Ok("REZERVASYON YAPILDI");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon silindi.");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking();
            {
                booking.Mail = updateBookingDto.Mail;
                booking.Date = updateBookingDto.Date;
                booking.Name = updateBookingDto.Name;
                booking.PersonCount = updateBookingDto.PersonCount;
                booking.Phone = updateBookingDto.Phone;
            }
            _bookingService.TUpdate(booking);
            return Ok("REZERVASYON GÜNCELLENDİ");
        }
       
        [HttpGet("{id}")]
        
        public IActionResult GetBooking(int id)
        {
            var value=_bookingService.TGetById(id);
            return Ok(value);
        }
}



    }

