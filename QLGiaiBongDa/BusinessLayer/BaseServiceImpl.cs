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
    class BaseServiceImpl<T> : BaseService<T>
    {
        public List<T> findByCondition(string proc, ModelMapper<T> modelMapper, SqlParameter[] param)
        {
            List<T> response = null;
            try
            {

                DataTable dt = new DataTable();
                DB.GetDataTable(ref dt, proc, param);
                response = (from DataRow dr in dt.Rows
                            select modelMapper.map(dr)).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public List<T> getAll(string proc, ModelMapper<T> modelMapper)
        {
            List<T> response = null;
            try
            {
                DataTable dt = new DataTable();
                DB.GetDataTable(ref dt, proc);
                response = (from DataRow dr in dt.Rows
                            select modelMapper.map(dr)).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public int save(string proc, SqlParameter[] param)
        {
            DataRow row = null;
            try
            {

                DB.GetOneRow(ref row, proc, param);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Int32.Parse(row["TotalRowChanged"].ToString());
        }


        public T findOne(string proc, ModelMapper<T> modelMapper, SqlParameter[] param)
        {
            DataRow row = null;
            try
            {

                DB.GetOneRow(ref row, proc, param);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return modelMapper.map(row);
        }

      

       
    }
}
