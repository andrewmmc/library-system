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
    public class AdminAuthor
    {
        private int _Aid;
        private string _FirstName;
        private string _LastName;
        private string _BirthYear;

        public int Aid
        {
            get { return _Aid; }
            set { _Aid = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string BirthYear
        {
            get { return _BirthYear; }
            set { _BirthYear = value; }
        }

        SqlBase objSqlBase = new SqlBase();

        public DataTable GetAll()
        {
            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Author";

            objSqlStatement.Fields = null;
            objSqlStatement.Conditions = null;
            objSqlStatement.OrderBy = null;

            objSqlBase.Sql = objSqlStatement.GenerateSelectStatement();
            return objSqlBase.ExecuteDataSet().Tables[0];
        }

        public void Update()
        {
            int i;

            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Author";

            List<Field> f = new List<Field>();
            f.Add(new Field("FirstName", _FirstName));
            f.Add(new Field("LastName", _LastName));
            if (_BirthYear.Length == 0)
            {
                f.Add(new Field("BirthYear", null));
            }
            else
            {
                int _intBirthYear = Convert.ToInt32(_BirthYear);
                f.Add(new Field("BirthYear", _intBirthYear));
            }

            List<Condition> wcs = new List<Condition>();
            Condition wc = new Condition();
            wc.MoreCondition = null;
            wc.Field = "Aid";
            wc.Operators = "=";
            wc.Value = _Aid;
            wcs.Add(wc);

            objSqlStatement.Fields = f;
            objSqlStatement.Conditions = wcs;

            if (_FirstName.Length > 0 && _LastName.Length > 0 && (int.TryParse(_BirthYear, out i) || _BirthYear.Length == 0))
            {
                objSqlBase.Sql = objSqlStatement.GenerateUpdateStatement();
                objSqlBase.Execute();
                objSqlBase.MessageBox("Update successful!");
            }
            else
            {
                objSqlBase.MessageBox("Please check your input.");
            }


        }

        public void Delete()
        {
            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Author";

            List<Condition> wcs = new List<Condition>();
            Condition wc = new Condition();
            wc.MoreCondition = null;
            wc.Field = "Aid";
            wc.Operators = "=";
            wc.Value = _Aid;
            wcs.Add(wc);

            objSqlStatement.Fields = null;
            objSqlStatement.Conditions = wcs;

            objSqlBase.Sql = objSqlStatement.GenerateDeleteStatement();
            objSqlBase.Execute();
        }

        public void Insert()
        {
            int i;

            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Author";

            List<Field> f = new List<Field>();
            f.Add(new Field("FirstName", _FirstName));
            f.Add(new Field("LastName", _LastName));
            if (_BirthYear.Length == 0)
            {
                f.Add(new Field("BirthYear", null));
            }
            else
            {
                if (int.TryParse(_BirthYear, out i))
                {
                    int _intBirthYear = Convert.ToInt32(_BirthYear);
                    f.Add(new Field("BirthYear", _intBirthYear));
                }
            }

            objSqlStatement.Fields = f;
            objSqlStatement.Conditions = null;

            if (_FirstName.Length > 0 && _LastName.Length > 0 && (int.TryParse(_BirthYear, out i) || _BirthYear.Length == 0))
            {
                objSqlBase.Sql = objSqlStatement.GenerateInsertStatement();
                objSqlBase.Execute();
                objSqlBase.MessageBox("Update successful!");
            }
            else
            {
                objSqlBase.MessageBox("Please check your input.");
            }

        }
    }
}


