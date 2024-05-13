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
    class PlayerService : BaseServiceImpl<Player>
    {
        private static PlayerMapper playerMapper = PlayerMapper.GetInstance();
        public List<Player> findByTeamId(int teamId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@teamId",teamId)
           };
            return findByCondition("SP_Player_SelectByTeamId", playerMapper, sqlParameters);
        }
        public DataTable getByTeamId(int teamId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@teamId",teamId)
           };
            DataTable table = new DataTable();
            return DB.GetDataTable(ref table, "SP_Player_SelectByTeamId", sqlParameters);
        }
        private SqlParameter[] createParam(Player player)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@teamId",player.teamId),
                new SqlParameter("@playerId",player.playerId),
                new SqlParameter("@playerName",player.playerName),
           };
            return sqlParameters;
        }
        internal void savePlayer(Player player)
        {
            save("SP_Player_Save", createParam(player));
        }
    }
}
