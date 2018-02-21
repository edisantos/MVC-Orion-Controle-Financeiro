using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionSystem.DAO
{
   public class Contexto
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader Dr;
        protected SqlDataAdapter Adp;
        /// <summary>
        /// OPEN CONNECTION
        /// </summary>
        /// <returns></returns>
        public SqlConnection openCon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        /// <summary>
        /// CLOSE CONNECTION
        /// </summary>
        /// <returns></returns>
        public SqlConnection CloseCon()
        {
            
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
            return con;
        }
    }
}
