using QLGiaiBongDa.DTO;
using QLGiaiBongDa.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.BusinessLayer
{
    class GroupTeamService : BaseServiceImpl<GroupTeam>
    {
        private static GroupTeamMapper groupTeamMapper = GroupTeamMapper.GetInstance();
        public DataTable getByGroupId(int groupId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@groupId",groupId)
            };
            DataTable table = new DataTable();
            return DB.GetDataTable(ref table, "SP_GroupTeam_Select", sqlParameters);
        }
        public void updateByMatchId(string matchId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@matchId",matchId)
            };
            save("SP_GroupTeam_Update", sqlParameters);
        }
        private SqlParameter[] createParam(GroupTeam groupTeam)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@groupId",groupTeam.groupId),
                 new SqlParameter("@teamId",groupTeam.teamId)
                
            };
            return sqlParameters;
        }
        public void saveGroupTeam(GroupTeam groupTeam)
        {
            save("SP_GroupTeam_Save", createParam(groupTeam));
        }

        internal List<GroupTeam> findByGroupId(int groupId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@groupId",groupId),
               

           };
            return findByCondition("SP_GroupTeam_SelectTeamWin", groupTeamMapper, sqlParameters);
        }
    }
}
