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
    class KnockoutMatchService : BaseServiceImpl<KnockoutMatch>
    {
        private static KnockoutMatchMapper knockoutMatchMapper = KnockoutMatchMapper.GetInstance();
        private SqlParameter[] createParam(KnockoutMatch knockoutMatch)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                new SqlParameter("@knockoutMatchId",knockoutMatch.knockoutMatchId),
                new SqlParameter("@branchId",knockoutMatch.branchId),
                new SqlParameter("@teamWin",knockoutMatch.teamWin)

             };
            return sqlParameters;

        }
        public int saveKnockoutMatch(KnockoutMatch knockoutMatch)
        {
            return save("SP_KnockoutMatch_Save", createParam(knockoutMatch));
        }

        internal List<KnockoutMatch> findByBranchId(int branchId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                new SqlParameter("@branchId",branchId),
               

             };
            return findByCondition("SP_KnockoutMatch_SelectByBranchId", knockoutMatchMapper, sqlParameters);
        }

        internal void updateMatch(int knockoutMatchId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
              {
                new SqlParameter("@knockoutMatchId",knockoutMatchId)


            };
            save("SP_KnockoutMatch_Update", sqlParameters);
        }
    }
}
