using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
           About about = new About();
            {
                about.Title = createAboutDto.Title;
                about.Description = createAboutDto.Description;
                about.ImageUrl = createAboutDto.ImageUrl;

            }

            _aboutService.TAdd(about);
            return Ok("hakkımda kısmı başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id) 
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda alanı silindi");
        }
        [HttpPut]
           public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto) 
        {
            About about = new About();
            {
                about.AboutID = updateAboutDto.AboutID;
                about.ImageUrl=updateAboutDto.ImageUrl;
                about.Title = updateAboutDto.Title;
                about.Description=updateAboutDto.Description;
               
            }

            _aboutService.TUpdate(about);
            return Ok("hakkımda alanı güncellendi");
        }
        [HttpGet("id")]
		public IActionResult GetAbout(int id) 
        {
            var value=_aboutService.TGetById(id);
            return Ok("value");
        }


    }
}
