using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PricePerSquareMeter { get; set; }
        public List<OptionDTO> AvailableOptions { get; set; }
    }
}
