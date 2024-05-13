using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.BusinessLayer
{
    class PenaltyService : BaseServiceImpl<Penalty>
    {
        private SqlParameter[] createParam(Penalty penalty)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
               new SqlParameter("@matchId",penalty.matchId),
              new SqlParameter("@team1Id",penalty.team1Id),
              new SqlParameter("@team2Id",penalty.team2Id),
              new SqlParameter("@team1Score",penalty.team1Score),
              new SqlParameter("@team2Score",penalty.team2Score),


           };
            return sqlParameters;
        }
        internal void savePenalty(Penalty penalty)
        {
            save("SP_Penalty_Save", createParam(penalty));
        }
    }
}
