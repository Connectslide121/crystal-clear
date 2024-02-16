using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int PricePerSquareMeter { get; set; }
        public List<Option> AvailableOptions { get; set; }
    }
}
