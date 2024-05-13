using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    class KnockoutBranchMapper : ModelMapper<KnockoutBranches>
    {
        private static KnockoutBranchMapper knockoutBranchMapper = null;
        public KnockoutBranches map(DataRow row)
        {
            return new KnockoutBranches() {
            
                branchId = Int32.Parse(row["branch_id"].ToString()),
                branchName = row["branch_name"].ToString(),
                startDate = DateTime.Parse(row["start_date"].ToString()),
                endDate = DateTime.Parse(row["end_date"].ToString()),
                roundId = Int32.Parse(row["round_id"].ToString())
            };
        }
        public static KnockoutBranchMapper GetInstance()
        {
            if (knockoutBranchMapper == null)
            {
                knockoutBranchMapper = new KnockoutBranchMapper();
            }
            return knockoutBranchMapper;
        }
    }
}
