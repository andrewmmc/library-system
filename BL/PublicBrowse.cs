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
using System.Text.RegularExpressions;

namespace BL
{
    public class PublicBrowse
    {
        private int _ISBN;
        private string _Title;
        private string _Index;
        private string _Browse;

        public int ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public string Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        public string Browse
        {
            get { return _Browse; }
            set { _Browse = value; }
        }

        SqlBase objSqlBase = new SqlBase();

        public DataTable GetAll()
        {
            SqlStatement objSqlStatement = new SqlStatement();
            if (_Browse == "book")
            {
                objSqlStatement.TableName = "Book";
            }
            if (_Browse == "author")
            {
                objSqlStatement.TableName = "Author";
            }

            List<Field> f = new List<Field>();
            if (_Browse == "book")
            {
                f.Add(new Field("ISBN", null));
                f.Add(new Field("Title", null));
            }
            if (_Browse == "author")
            {
                f.Add(new Field("Aid", null));
                f.Add(new Field("(FirstName + ' ' + LastName) AS Name", null));
            }

            List<Condition> wcs = new List<Condition>();
            Condition wc1 = new Condition();
            wc1.MoreCondition = null;
            if (_Browse == "book")
            {
                wc1.Field = "Title";
            }
            if (_Browse == "author")
            {
                wc1.Field = "FirstName";
            }
            wc1.Operators = "LIKE";
            wc1.Value = _Index;
            wcs.Add(wc1);

            List<Orderby> o = new List<Orderby>();
            Orderby o1 = new Orderby();
            if (_Browse == "book")
            {
                o1.Field = "Title";
            }
            if (_Browse == "author")
            {
                o1.Field = "FirstName";
            }
            o1.Operators = "ASC";
            o.Add(o1);

            objSqlStatement.Fields = f;
            objSqlStatement.Conditions = wcs;
            objSqlStatement.OrderBy = o;

            objSqlBase.Sql = objSqlStatement.GenerateSelectStatement();
            return objSqlBase.ExecuteDataSet().Tables[0];
        }
    }
}
