using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa
{
    class DB
    {
        public static string strConn = Cls_Main.path;
        public static SqlConnection conn = new SqlConnection(strConn);

        public static DataTable GetDataTable(ref DataTable dt, string store_proc_name, params SqlParameter[] param)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand command = new SqlCommand()
                {
                    Connection = conn,
                    CommandText = store_proc_name,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 600
                };
                if (param != null)
                {
                   

                    if (param.Length > 0)
                    {
                        foreach (SqlParameter item in param)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return dt;
        }
        public static DataSet GetDataSet(ref DataSet dt, string store_proc_name, params SqlParameter[] param)
        {

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand command = new SqlCommand()
                {
                    Connection = conn,
                    CommandText = store_proc_name,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 600
                };

                if (param.Length > 0)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return dt;
        }
        public static DataRow GetOneRow(ref DataRow dr, string store_proc_name, params SqlParameter[] param)
        {
            try
            {

                DataTable dt = new DataTable();
                GetDataTable(ref dt, store_proc_name, param);
                dr = dt.Rows[0];

                return dr;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
