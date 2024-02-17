using API.InputModels;
using Services.DTOs;

namespace API.Mappers
{
    public class InputModelMappers
    {
        public CityDTO MapCityInputModelToCityDTO(CityInputModel city)
        {
            CityDTO cityDTO = new CityDTO
            {
                Id = city.Id,
                Name = city.Name,
                PricePerSquareMeter = city.PricePerSquareMeter,
            };
            return cityDTO;
        }

        public List<OptionDTO> MapOptionInputModelsToOptionDTOs(List<OptionInputModel> options)
        {
            List<OptionDTO> optionDTOs = new List<OptionDTO>();

            foreach (OptionInputModel option in options)
            {
                OptionDTO optionDTO = new OptionDTO
                {
                    Id = option.Id,
                    Name = option.Name,
                    Price = option.Price
                };
                optionDTOs.Add(optionDTO);
            }
            return optionDTOs;
        }
    }
}
