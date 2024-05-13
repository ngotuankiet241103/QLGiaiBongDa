using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    class KnockoutMatchMapper : ModelMapper<KnockoutMatch>
    {
        private static KnockoutMatchMapper knockoutMatchMapper = null;
        public KnockoutMatch map(DataRow row)
        {
            return new KnockoutMatch() { 
            
                branchId = Int32.Parse(row["branch_id"].ToString()),
                knockoutMatchId = Int32.Parse(row["knockoutMatches_id"].ToString()),
                teamWin = Int32.Parse(row["teamWin"].ToString())
            };
        }
        public static KnockoutMatchMapper GetInstance()
        {
            if (knockoutMatchMapper == null)
            {
                knockoutMatchMapper = new KnockoutMatchMapper();
            }
            return knockoutMatchMapper;
        }
    }
}
