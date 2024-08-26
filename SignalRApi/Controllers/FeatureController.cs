using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.FeatureDto;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _FeatureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _FeatureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var value = _mapper.Map<List<ResultFeatureDto>>(_FeatureService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _FeatureService.TAdd(new SignalR.EntityLayer.Entities.Feature()
            {
                Description1 = createFeatureDto.Description1,
                Description2 = createFeatureDto.Description2,
                Description3 = createFeatureDto.Description3,
                Title1 = createFeatureDto.Title1,
                Title2 = createFeatureDto.Title2,
                Title3 = createFeatureDto.Title3,
            });
            return Ok("öne çıkan Eklendi");
        }
        [HttpDelete("{id}")]
		public IActionResult DeleteFeature(int id)
        {
            var value = _FeatureService.TGetById(id);
            _FeatureService.TDelete(value);
            return Ok("Kategori Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _FeatureService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _FeatureService.TUpdate(new SignalR.EntityLayer.Entities.Feature()
            {
              Description1=updateFeatureDto.Description1,
              Description2 = updateFeatureDto.Description2,
              Description3 = updateFeatureDto.Description3,
              Title1 = updateFeatureDto.Title1,
              Title2 = updateFeatureDto.Title2,
              Title3 = updateFeatureDto.Title3,
            });
            return Ok("iletişim  güncellendi");
        }
    }
}
