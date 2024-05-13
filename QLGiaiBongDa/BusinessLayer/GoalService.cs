using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.BusinessLayer
{
    class GoalService : BaseServiceImpl<Goal>
    {
        public DataTable getByMatchId(string matchId)
        {

            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@matchId",matchId)
           };
            DataTable table = new DataTable();
            return DB.GetDataTable(ref table, "SP_Goals_Select", sqlParameters);
        }

        internal void saveGoal(Goal goal)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
          {
                new SqlParameter("@matchId",goal.matchId),
                 new SqlParameter("@playerId",goal.playerId),
                  new SqlParameter("@timeGoal",goal.timeGoal)
          };
            save("SP_Goal_Save", sqlParameters);
        }
    }
}
