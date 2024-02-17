using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
        public int Price { get; set; }

    }
}
