using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public City City { get; set; }
        public List<Option> SelectedOptions { get; set; }
        public int TotalPrice { get; set; }
    }
}
