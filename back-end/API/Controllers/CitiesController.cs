using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController(ICitiesService _citiesService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            List<CityDTO> cities = _citiesService.GetCities();
            return cities == null ? NotFound() : Ok(cities);
        }
    }
}
