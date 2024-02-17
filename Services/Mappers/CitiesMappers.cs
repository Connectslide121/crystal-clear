using Core;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public class CitiesMappers
    {
        public List<CityDTO> MapCitiesToCityDTOs (List<City> cities)
        {
            List<CityDTO> cityDTOs = new List<CityDTO> ();

            foreach (City city in cities) 
            {
                CityDTO cityDTO = new CityDTO
                {
                    Id = city.Id,
                    Name = city.Name,
                    PricePerSquareMeter = city.PricePerSquareMeter,
                    AvailableOptions = MapOptionsToOptionDTOs(city.AvailableOptions)
                };
                cityDTOs.Add(cityDTO);
            }
            return cityDTOs;
        }

        public List<OptionDTO> MapOptionsToOptionDTOs(List<Option> options)
        {
            List<OptionDTO> optionDTOs = new List<OptionDTO>();

            foreach (Option option in options)
            {
                OptionDTO optionDTO = new OptionDTO
                {
                    Id = option.Id,
                    Name = option.Name,
                    Price = option.Price,
                };
                optionDTOs.Add(optionDTO);
            }
            return optionDTOs;
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
