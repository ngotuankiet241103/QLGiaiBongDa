using QLGiaiBongDa.DTO;
using QLGiaiBongDa.Mapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.BusinessLayer
{
    class KnockoutBranchService : BaseServiceImpl<KnockoutBranches>
    {
        private static KnockoutBranchMapper knockoutBranchMapper = KnockoutBranchMapper.GetInstance();
        private SqlParameter[] createParam(KnockoutBranches knockoutBranches) {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                new SqlParameter("@branchId",0),
                new SqlParameter("@branchName",knockoutBranches.branchName),
                new SqlParameter("@roundId",knockoutBranches.roundId),
                new SqlParameter("@startDate",knockoutBranches.startDate),
                new SqlParameter("@endDate",knockoutBranches.endDate)

             };
            return sqlParameters;

        }
        
        public int saveKnockoutBrances(KnockoutBranches knockoutBranches)
        {
            return save("SP_KnockoutBranch_Save", createParam(knockoutBranches));
        }

        internal List<KnockoutBranches> findByRoundId(int roundId)
        {

            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                new SqlParameter("@roundId",roundId),
             

             };
            return findByCondition("SP_KnockoutBranch_SelectByRoundId", knockoutBranchMapper, sqlParameters);
        }
    }
}
