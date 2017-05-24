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
    public class PublicSearch
    {
        private int _ISBN;
        private string _Title;
        private string _Name;
        private string _DDlist;
        private string _Keyword;

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

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string DDlist
        {
            get { return _DDlist; }
            set { _DDlist = value; }
        }

        public string Keyword
        {
            get { return _Keyword; }
            set { _Keyword = value; }
        }

        SqlBase objSqlBase = new SqlBase();

        public DataTable GetAll()
        {
            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Book b JOIN Book_Author ba ON b.ISBN=ba.ISBN JOIN Author a ON ba.Aid=a.Aid";

            List<Field> f = new List<Field>();
            f.Add(new Field("b.ISBN", null));
            f.Add(new Field("b.Title", null));
            f.Add(new Field("(a.FirstName + ' ' + a.LastName) AS Name", null));

            List<Condition> wcs = new List<Condition>();
            Condition wc1 = new Condition();
            wc1.MoreCondition = null;
            wc1.Field = _DDlist;
            wc1.Operators = "LIKE";
            wc1.Value = _Keyword;
            wcs.Add(wc1);

            objSqlStatement.Fields = f;
            objSqlStatement.Conditions = wcs;
            objSqlStatement.OrderBy = null;

            objSqlBase.Sql = objSqlStatement.GenerateSelectStatement();
            return objSqlBase.ExecuteDataSet().Tables[0];
        }
    }
}
