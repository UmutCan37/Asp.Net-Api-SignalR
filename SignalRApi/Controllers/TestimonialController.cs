using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.Testimonial;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService1 _testimonialService1;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService1 testimonialService1, IMapper mapper)
        {
            _testimonialService1 = testimonialService1;
            _mapper = mapper;
        }

        [HttpGet]
		public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService1.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService1.TAdd(new SignalR.EntityLayer.Entities.Testimonial()
            {
                Comment = createTestimonialDto.Comment, 
                ImageUrl = createTestimonialDto.ImageUrl,
                Status = createTestimonialDto.Status,
                TestimonialName= createTestimonialDto.TestimonialName,
                Title = createTestimonialDto.Title,
            });
            return Ok("müşteri yorum Eklendi");
        }
        [HttpDelete("{id}")]
		public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService1.TGetById(id);
            _testimonialService1.TDelete(value);
            return Ok("müşteri yorum Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService1.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService1.TUpdate(new SignalR.EntityLayer.Entities.Testimonial()
            {
                Status = updateTestimonialDto.Status,
                Comment = updateTestimonialDto.Comment,
                TestimonialName=updateTestimonialDto.TestimonialName,
                Title = updateTestimonialDto.Title,
                ImageUrl = updateTestimonialDto.ImageUrl,
                TestimonialId=updateTestimonialDto.TestimonialId,

            });
            return Ok("müşteri yorum  güncellendi");
        }
    }
}
