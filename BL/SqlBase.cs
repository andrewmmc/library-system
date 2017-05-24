using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BL
{

    public class SqlBase
    {
        private string _Sql;

        public string Sql
        {
            get { return _Sql; }
            set { _Sql = value; }
        }

        SqlConnection sqlConnection = null;
        SqlCommand sqlCommand = null;
        SqlDataAdapter sqlDataAdapter = null;

        string _ConnectionString = ConfigurationManager.ConnectionStrings["Conn"].ToString();

        public DataSet ExecuteDataSet()
        {

            sqlConnection = new SqlConnection(_ConnectionString);
            sqlCommand = new SqlCommand(_Sql, sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet objDs = new DataSet();
            sqlConnection.Open();
            sqlDataAdapter.Fill(objDs);
            sqlConnection.Close();
            return objDs;
        }

        public SqlDataReader ExecuteDataReader()
        {

            sqlConnection = new SqlConnection(_ConnectionString);
            sqlCommand = new SqlCommand(_Sql, sqlConnection);
            sqlConnection.Open();
            SqlDataReader objDr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return objDr;
        }

        public void Execute()
        {

            sqlConnection = new SqlConnection(_ConnectionString);
            sqlCommand = new SqlCommand(_Sql, sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MessageBox(string msg)
        {
            string js = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            System.Web.HttpContext.Current.Response.Write(js);
        }

    }
}
