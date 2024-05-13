using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.DTO
{
    class Round
    {
        public int roundId { get; set; }
        public string roundName { get; set; }
        public int touramentId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
     }
}
