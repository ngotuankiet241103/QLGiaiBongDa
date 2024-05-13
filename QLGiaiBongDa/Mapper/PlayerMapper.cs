using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    class PlayerMapper : ModelMapper<Player>
    {
        private static PlayerMapper playerMapper = null;
        public Player map(DataRow row)
        {
            return new Player() {
                playerId = Int32.Parse(row["player_id"].ToString()),
                teamName = row["player_name"].ToString()
            
            };
        }
        public static PlayerMapper GetInstance()
        {
            if (playerMapper == null)
            {
                playerMapper = new PlayerMapper();
            }
            return playerMapper;
        }
    }
}
