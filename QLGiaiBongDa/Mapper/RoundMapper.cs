using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    class RoundMapper : ModelMapper<Round>
    {
        private static RoundMapper roundMapper = null;
        public Round map(DataRow row)
        {
            return new Round()
            {
                roundId = Int32.Parse(row["round_id"].ToString()),
                touramentId = Int32.Parse(row["tournament_id"].ToString()),
                roundName = row["round_name"].ToString(),
                startDate = DateTime.Parse(row["start_date"].ToString()),
                endDate = DateTime.Parse(row["end_date"].ToString())

            };
        }
        public static RoundMapper GetInstance()
        {
            if(roundMapper == null)
            {
                roundMapper = new RoundMapper();
            }
            return roundMapper;
        }
    }
}
