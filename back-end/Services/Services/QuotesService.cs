using Core;
using DatabaseConnection;
using Microsoft.Extensions.Options;
using Services.DTOs;
using Services.Interfaces;
using Services.Mappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class QuotesService : IQuotesService
    {
        private readonly AppDbContext _dbContext;
        private QuotesMappers _mappers;

        public QuotesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _mappers = new QuotesMappers();
        }

        public async Task<QuoteDTO> CreateQuote(CityDTO city, List<OptionDTO> options, int squareMeters)
        {
            int totalPrice = city.PricePerSquareMeter * squareMeters;

            foreach (OptionDTO option in options)
            {
                totalPrice += option.Price;
            }

            QuoteDTO quoteDTO = new QuoteDTO
            {
                CityId = city.Id,
                SelectedOptionsIds = options.Select(o => o.Id).ToList(),
                SquareMeters = squareMeters,
                TotalPrice = totalPrice
            };

            Quote quote = _mappers.MapQuoteDTOToQuote(quoteDTO);

            _dbContext.Quotes.Add(quote);

            await _dbContext.SaveChangesAsync();

            return GetQuoteById(quote.Id);
        }

        public QuoteDTO GetQuoteById(int id)
        {
            Quote? quote = _dbContext.Quotes
                .Where(q => q.Id == id)
                .SingleOrDefault();

            CityDTO cityDTO = GetCityById(quote.CityId);

            List<OptionDTO> optionDTOs = new List<OptionDTO>();

            foreach (int optionId in quote.SelectedOptionsIds)
            {
                OptionDTO optionDTO = GetOptionById(optionId);
                optionDTOs.Add(optionDTO);
            }

            return _mappers.MapQuoteToQuoteDTO(quote, cityDTO, optionDTOs);

        }

        public CityDTO GetCityById(int id)
        {
            City? city = _dbContext.Cities
                .Where(c => c.Id == id)
                .SingleOrDefault();

            return _mappers.MapCityToCityDTO(city);
        }

        public OptionDTO GetOptionById(int id)
        {
            Option? option = _dbContext.Options
                .Where(o => o.Id == id)
                .SingleOrDefault();

            return _mappers.MapOptionToOptionDTO(option);
        }

    }
}
