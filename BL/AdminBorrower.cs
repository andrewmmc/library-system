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
    public class AdminBorrower
    {
        private int _UserId; //Auto-increment value
        private string _PersonId;
        private string _FirstName;
        private string _LastName;
        private string _Address;
        private string _TelNo;
        private int _CategoryId;

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public string PersonId
        {
            get { return _PersonId; }
            set { _PersonId = value; }
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

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string TelNo
        {
            get { return _TelNo; }
            set { _TelNo = value; }
        }

        public int CategoryId
        {
            get { return _CategoryId; }
            set { _CategoryId = value; }
        }

        SqlBase objSqlBase = new SqlBase();

        public DataTable GetAll()
        {
            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Borrower";

            List<Field> f = new List<Field>();
            f.Add(new Field("UserId", null));
            f.Add(new Field("PersonId", null));
            f.Add(new Field("FirstName", null));
            f.Add(new Field("LastName", null));
            f.Add(new Field("Address", null));
            f.Add(new Field("TelNo", null));
            f.Add(new Field("CategoryId", null));

            objSqlStatement.Fields = f;
            objSqlStatement.Conditions = null;
            objSqlStatement.OrderBy = null;

            objSqlBase.Sql = objSqlStatement.GenerateSelectStatement();
            return objSqlBase.ExecuteDataSet().Tables[0];
        }

        public void Update()
        {
            int i;

            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Borrower";

            List<Field> f = new List<Field>();
            //f.Add(new Field("UserId", null));
            f.Add(new Field("PersonId", _PersonId));
            f.Add(new Field("FirstName", _FirstName));
            f.Add(new Field("LastName", _LastName));
            if (_Address.Length == 0)
            {
                f.Add(new Field("Address", null));
            }
            else
            {
                f.Add(new Field("Address", _Address));
            }
            if (_TelNo.Length == 0)
            {
                f.Add(new Field("TelNo", null));
            }
            else
            {
                f.Add(new Field("TelNo", _TelNo));
            }
            int _intCategoryId = Convert.ToInt32(_CategoryId);
            f.Add(new Field("CategoryId", _intCategoryId));
            
            List<Condition> wcs = new List<Condition>();
            Condition wc = new Condition();
            wc.MoreCondition = null;
            wc.Field = "UserId";
            wc.Operators = "=";
            int _intUserId = Convert.ToInt32(_UserId);
            wc.Value = _intUserId;
            wcs.Add(wc);

            objSqlStatement.Fields = f;
            objSqlStatement.Conditions = wcs;

            if (_FirstName.Length > 0 && _LastName.Length > 0 && (int.TryParse(_TelNo, out i)|| _TelNo.Length == 0))
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
            objSqlStatement.TableName = "Borrower";

            List<Condition> wcs = new List<Condition>();
            Condition wc = new Condition();
            wc.MoreCondition = null;
            wc.Field = "UserId";
            wc.Operators = "=";
            int _intUserId = Convert.ToInt32(_UserId);
            wc.Value = _intUserId;
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
            objSqlStatement.TableName = "Borrower";

            List<Field> f = new List<Field>();
            f.Add(new Field("PersonId", null));

            List<Condition> wcs = new List<Condition>();
            Condition wc = new Condition();
            wc.MoreCondition = null;
            wc.Field = "PersonId";
            wc.Operators = "=";
            wc.Value = _PersonId;
            wcs.Add(wc);

            objSqlStatement.Fields = f;
            objSqlStatement.Conditions = wcs;
            objSqlStatement.OrderBy = null;

            objSqlBase.Sql = objSqlStatement.GenerateSelectStatement();

            SqlStatement objSqlStatement1 = new SqlStatement();
            objSqlStatement1.TableName = "Borrower";

            List<Field> f1 = new List<Field>();
            f1.Add(new Field("PersonId", _PersonId));
            f1.Add(new Field("FirstName", _FirstName));
            f1.Add(new Field("LastName", _LastName));
            if (_Address.Length == 0)
            {
                f1.Add(new Field("Address", null));
            }
            else
            {
                f1.Add(new Field("Address", _Address));
            }
            if (_TelNo.Length == 0)
            {
                f1.Add(new Field("TelNo", null));
            }
            else
            {
                f1.Add(new Field("TelNo", _TelNo));
            }
            int _intCategoryId = Convert.ToInt32(_CategoryId);
            f1.Add(new Field("CategoryId", _intCategoryId));

            objSqlStatement1.Fields = f1;
            objSqlStatement1.Conditions = null;

            if (objSqlBase.ExecuteDataReader().HasRows)
            {
                objSqlBase.MessageBox("The Person ID is exist. Please check your input.");
            }
            else if (_FirstName.Length > 0 && _LastName.Length > 0 && (int.TryParse(_TelNo, out i) || _TelNo.Length == 0))
            {
                objSqlBase.Sql = objSqlStatement1.GenerateInsertStatement();
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


