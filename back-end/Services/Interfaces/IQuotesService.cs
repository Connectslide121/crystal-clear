using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IQuotesService
    {
        public Task<QuoteDTO> CreateQuote(CityDTO city, List<OptionDTO> options, int squareMeters);
    }
}
