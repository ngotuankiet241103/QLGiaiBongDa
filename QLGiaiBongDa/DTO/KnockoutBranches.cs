using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.DTO
{
    class KnockoutBranches
    {
        public int branchId { get; set; }
        public string branchName { get; set; }
        public int roundId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        internal List<KnockoutBranches> findByRoundId(int roundId)
        {
            throw new NotImplementedException();
        }
    }
}
