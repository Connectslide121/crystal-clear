using API.InputModels;
using API.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;
using Services.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesService _quotesService;
        private InputModelMappers _mappers;

        public QuotesController(IQuotesService quotesService)
        {
            _quotesService = quotesService;
            _mappers = new InputModelMappers();
        }

        [HttpPost("create")]
        public async Task<ActionResult<QuoteDTO>> CreateQuote(QuoteInputModel model)
        {
            CityDTO cityDTO = _mappers.MapCityInputModelToCityDTO(model.City);
            List<OptionDTO> optionDTOs = _mappers.MapOptionInputModelsToOptionDTOs(model.Options);
            int squareMeters = model.SquareMeters;

            QuoteDTO createdQuote = await _quotesService.CreateQuote(cityDTO, optionDTOs, squareMeters);

            return Ok(createdQuote);
        }
    }
}
