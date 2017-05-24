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
    public class PublicBookdetails
    {
        private int _ISBN;
        private string _Title;
        private string _Name;
        private string _ISBNvalue;

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

        public string ISBNvalue
        {
            get { return _ISBNvalue; }
            set { _ISBNvalue = value; }
        }

        SqlBase objSqlBase = new SqlBase();

        public DataTable GetAll()
        {
            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "BOOK b JOIN BOOK_AUTHOR ba ON b.ISBN=ba.ISBN JOIN AUTHOR a ON ba.Aid=a.Aid JOIN CLASSIFICATION c ON c.SignId=b.SignId";

            List<Field> f = new List<Field>();
            f.Add(new Field("b.ISBN", null));
            f.Add(new Field("b.Title", null));
            f.Add(new Field("(a.FirstName + ' ' + a.LastName) AS Name", null));
            f.Add(new Field("c.Signum", null));
            f.Add(new Field("b.publicationinfo", null));
            f.Add(new Field("b.PublicationYear", null));
            f.Add(new Field("b.pages", null));

            List<Condition> wcs = new List<Condition>();
            Condition wc1 = new Condition();
            wc1.MoreCondition = null;
            wc1.Field = "b.ISBN";
            wc1.Operators = "=";
            wc1.Value = _ISBNvalue;
            //wc1.Value = "0070062722";
            wcs.Add(wc1);

            objSqlStatement.Fields = f;
            objSqlStatement.Conditions = wcs;
            objSqlStatement.OrderBy = null;

            objSqlBase.Sql = objSqlStatement.GenerateSelectStatement();
            return objSqlBase.ExecuteDataSet().Tables[0];
        }
    }
}
