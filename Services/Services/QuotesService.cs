using Core;
using DatabaseConnection;
using Services.DTOs;
using Services.Interfaces;
using Services.Mappers;
using System;
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

            return _mappers.MapQuoteToQuoteDTO(quote);
        }
    }
}
