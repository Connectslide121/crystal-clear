using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class QuoteDTO
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public CityDTO City { get; set; }
        public int SquareMeters { get; set; }
        public List<int> SelectedOptionsIds { get; set; }
        public List<OptionDTO> SelectedOptions { get; set; }
        public int TotalPrice { get; set; }

    }
}
