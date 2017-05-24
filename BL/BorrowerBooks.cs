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
    public class BorrowerBooks
    {
        private string _wcField;
        private string _wcValue;
        private string _Barcode;

        public string wcField
        {
            get { return _wcField; }
            set { _wcField = value; }
        }

        public string wcValue
        {
            get { return _wcValue; }
            set { _wcValue = value; }
        }

        public string Barcode
        {
            get { return _Barcode; }
            set { _Barcode = value; }
        }
        

        SqlBase objSqlBase = new SqlBase();

        public DataTable GetAll()
        {
            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Borrow bb JOIN Copy c ON bb.Barcode=c.Barcode JOIN Book b ON c.ISBN=b.ISBN JOIN aspnet_Membership asp ON bb.PersonId=convert(nvarchar(255),asp.Comment)";

            List<Field> f = new List<Field>();
            f.Add(new Field("bb.Barcode", null));
            f.Add(new Field("b.Title", null));
            f.Add(new Field("c.Location", null));
            f.Add(new Field("c.library", null));
            f.Add(new Field("bb.BorrowDate", null));
            f.Add(new Field("bb.ToBeReturnedDate", null));
            f.Add(new Field("bb.ReturnDate", null));

            List<Condition> wcs = new List<Condition>();
            Condition wc = new Condition();
            wc.MoreCondition = null;
            wc.Field = wcField;
            wc.Operators = "=";
            wc.Value = wcValue;
            wcs.Add(wc);

            objSqlStatement.Fields = f;
            objSqlStatement.Conditions = wcs;
            objSqlStatement.OrderBy = null;

            objSqlBase.Sql = objSqlStatement.GenerateSelectStatement();
            return objSqlBase.ExecuteDataSet().Tables[0];
        }

        public void Renew()
        {
            objSqlBase.Sql = "UPDATE Borrow SET ToBeReturnedDate= DATEADD(day,14,ToBeReturnedDate) FROM Borrow AS bb INNER JOIN aspnet_Membership AS asp ON bb.PersonId=convert(nvarchar(255),asp.Comment) WHERE " + wcField +" = '" + wcValue + "' AND bb.Barcode = '" + Barcode + "'";
            objSqlBase.Execute();
            objSqlBase.MessageBox("Renew successful!");
        }
    }
}


