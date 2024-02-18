using Core;
using Services.DTOs;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public class QuotesMappers
    {
       public Quote MapQuoteDTOToQuote(QuoteDTO quoteDTO)
        {
            Quote quote = new Quote
            {
                CityId = quoteDTO.CityId,
                SelectedOptionsIds = quoteDTO.SelectedOptionsIds,
                SquareMeters = quoteDTO.SquareMeters,
                TotalPrice = quoteDTO.TotalPrice
            };
            return quote;
        }

        public QuoteDTO MapQuoteToQuoteDTO(Quote quote, CityDTO cityDTO, List<OptionDTO> optionDTOs)
        {
            QuoteDTO quoteDTO = new QuoteDTO
            {
                Id = quote.Id,
                CityId = quote.CityId,
                SelectedOptionsIds = quote.SelectedOptionsIds,
                SquareMeters = quote.SquareMeters,
                TotalPrice = quote.TotalPrice,
                City = cityDTO,
                SelectedOptions = optionDTOs
            };
            return quoteDTO;
        }

        public CityDTO MapCityToCityDTO(City city)
        {
            CityDTO cityDTO = new CityDTO
            {
                Id = city.Id,
                Name = city.Name,
                PricePerSquareMeter = city.PricePerSquareMeter,
            };
            return cityDTO;
        }

        public OptionDTO MapOptionToOptionDTO(Option option)
        {
            OptionDTO optionDTO = new OptionDTO
            {
                Id = option.Id,
                Name = option.Name,
                Price = option.Price,
            };
            return optionDTO;
        }
    }
}
