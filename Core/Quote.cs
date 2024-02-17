using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Quote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        public int CityId { get; set; }
        public int SquareMeters { get; set; }
        public List<int> SelectedOptionsIds { get; set; }
        public int TotalPrice { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] public DateTime CretedAt { get; set; }
    }
}
