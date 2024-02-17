﻿using Core;
using Services.DTOs;
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

        public QuoteDTO MapQuoteToQuoteDTO(Quote quote)
        {
            QuoteDTO quoteDTO = new QuoteDTO
            {
                Id = quote.Id,
                CityId = quote.CityId,
                SelectedOptionsIds = quote.SelectedOptionsIds,
                SquareMeters = quote.SquareMeters,
                TotalPrice = quote.TotalPrice
            };
            return quoteDTO;
        }

        public City MapCityDTOToCity(CityDTO cityDTO)
        {
            City city = new City
            {
                Id = cityDTO.Id,
                Name = cityDTO.Name,
                PricePerSquareMeter = cityDTO.PricePerSquareMeter,
            };
            return city;
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
    }
}
