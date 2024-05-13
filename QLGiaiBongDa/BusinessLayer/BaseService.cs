using QLGiaiBongDa.Mapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.BusinessLayer
{
    interface BaseService<T>
    {
        List<T> getAll(string proc, ModelMapper<T> modelMapper);
        List<T> findByCondition(string proc, ModelMapper<T> modelMapper, SqlParameter[] param);
        T findOne(string proc, ModelMapper<T> modelMapper, SqlParameter[] param);
        int save(string proc, SqlParameter[] param);
        
    }
}
