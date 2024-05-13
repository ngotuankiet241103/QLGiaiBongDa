using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.DTO
{
    class Group
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int roundId { get; set; }
    }
}
