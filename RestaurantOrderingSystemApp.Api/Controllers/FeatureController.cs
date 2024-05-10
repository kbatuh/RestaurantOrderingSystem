using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.Abstract;
using RestaurantOrderingSystemApp.DtoLayer.FeatureDto;
using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var value = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("FeaturesByStatusTrue")]
        public IActionResult FeaturesByStatusTrue()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetFeaturesByStatusTrue());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(new Feature()
            {
                Title = createFeatureDto.Title,
                Description = createFeatureDto.Description,
                ImageUrl = createFeatureDto.ImageUrl,
                Status = createFeatureDto.Status,
               
            });
            return Ok("Öne Çıkan Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            _featureService.TDelete(value);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpGet("{id}")]

        public IActionResult Getfeature(int id)
        {
            var value = _featureService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]

        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                Title = updateFeatureDto.Title,
                Description = updateFeatureDto.Description,
                ImageUrl = updateFeatureDto.ImageUrl,
                Status = updateFeatureDto.Status
            });
            return Ok("Öne Çıkan Alan Bilgisi Güncellendi");
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _featureService.TChangeStatus(id);
            return Ok("Durum değiştirildi");
        }
    }
}
