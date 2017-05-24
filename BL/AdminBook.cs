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
    public class AdminBook
    {
        private string _ISBN;
        private string _Title;
        private int _SignId;
        private string _PublicationYear;
        private string _PublicationInfo;
        private int _Pages;
        private int _Aid;

        public string ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public int SignId
        {
            get { return _SignId; }
            set { _SignId = value; }
        }

        public string PublicationYear
        {
            get { return _PublicationYear; }
            set { _PublicationYear = value; }
        }

        public string PublicationInfo
        {
            get { return _PublicationInfo; }
            set { _PublicationInfo = value; }
        }

        public int Pages
        {
            get { return _Pages; }
            set { _Pages = value; }
        }

        public int Aid
        {
            get { return _Aid; }
            set { _Aid = value; }
        }

        SqlBase objSqlBase = new SqlBase();

        public DataTable GetAll()
        {
            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Book b JOIN BOOK_AUTHOR ba ON b.ISBN=ba.ISBN";

            List<Field> f = new List<Field>();
            f.Add(new Field("b.ISBN", null));
            f.Add(new Field("b.Title", null));
            f.Add(new Field("b.SignId", null));
            f.Add(new Field("b.PublicationYear", null));
            f.Add(new Field("b.publicationinfo", null));
            f.Add(new Field("b.pages", null));
            f.Add(new Field("ba.Aid", null));

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
            objSqlStatement.TableName = "Book";

            List<Field> f = new List<Field>();
            f.Add(new Field("Title", _Title));
            f.Add(new Field("SignId", Convert.ToInt32(_SignId)));
            if (_PublicationYear.Length == 0)
            {
                f.Add(new Field("PublicationYear", null));
            }
            else
            {
                f.Add(new Field("PublicationYear", _PublicationYear));
            }
            if (_PublicationInfo.Length == 0)
            {
                f.Add(new Field("publicationinfo", null));
            }
            else
            {
                f.Add(new Field("publicationinfo", _PublicationInfo));
            }
            f.Add(new Field("pages", Convert.ToInt16(Pages)));

            List<Condition> wcs = new List<Condition>();
            Condition wc = new Condition();
            wc.MoreCondition = null;
            wc.Field = "ISBN";
            wc.Operators = "=";
            wc.Value = _ISBN;
            wcs.Add(wc);

            objSqlStatement.Fields = f;
            objSqlStatement.Conditions = wcs;

            //SqlStatement objSqlStatement1 = new SqlStatement();
            //objSqlStatement1.TableName = "Book_Author";

            //List<Field> f2 = new List<Field>();
            //f2.Add(new Field("ISBN", _ISBN));
            //f2.Add(new Field("Aid", Convert.ToInt32(_Aid)));

            //objSqlStatement1.Fields = f2;
            //objSqlStatement1.Conditions = wcs;

            if (Title.Length > 0 && (int.TryParse(_PublicationYear, out i) || _PublicationYear.Length == 0))
            {
                objSqlBase.Sql = objSqlStatement.GenerateUpdateStatement();
                objSqlBase.Execute();

                //objSqlBase.Sql = objSqlStatement1.GenerateUpdateStatement();
                //objSqlBase.Execute();

                objSqlBase.MessageBox("Update successful!");
            }
            else
            {
                objSqlBase.MessageBox("Please check your input.");
            }
        }

        public void Delete()
        {
            //Delete related records in Book Table
            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Book";

            List<Condition> wcs = new List<Condition>();
            Condition wc = new Condition();
            wc.MoreCondition = null;
            wc.Field = "ISBN";
            wc.Operators = "=";
            wc.Value = _ISBN;
            wcs.Add(wc);

            objSqlStatement.Fields = null;
            objSqlStatement.Conditions = wcs;

            objSqlBase.Sql = objSqlStatement.GenerateDeleteStatement();
            objSqlBase.Execute();

            /*Delete related records in Book_Author Table
            SqlStatement objSqlStatement2 = new SqlStatement();
            objSqlStatement.TableName = "Book_Author";

            objSqlStatement2.Fields = null;
            objSqlStatement2.Conditions = wcs;

            objSqlBase.Sql = objSqlStatement2.GenerateDeleteStatement();
            objSqlBase.Execute();*/
        }

        public void Insert()
        {
            int i;

            SqlStatement objSqlStatement = new SqlStatement();
            objSqlStatement.TableName = "Book";

            List<Condition> wcs = new List<Condition>();
            Condition wc = new Condition();
            wc.MoreCondition = null;
            wc.Field = "ISBN";
            wc.Operators = "=";
            wc.Value = _ISBN;
            wcs.Add(wc);

            objSqlStatement.Fields = null;
            objSqlStatement.Conditions = wcs;
            objSqlStatement.OrderBy = null;

            objSqlBase.Sql = objSqlStatement.GenerateSelectStatement();

            SqlStatement objSqlStatement1 = new SqlStatement();
            objSqlStatement1.TableName = "Book";

            List<Field> f1 = new List<Field>();
            f1.Add(new Field("ISBN", _ISBN));
            f1.Add(new Field("Title", _Title));
            f1.Add(new Field("SignId", Convert.ToInt32(_SignId)));
            if (_PublicationYear.Length == 0)
            {
                f1.Add(new Field("PublicationYear", null));
            }
            else
            {
                f1.Add(new Field("PublicationYear", _PublicationYear));
            }
            if (_PublicationInfo.Length == 0)
            {
                f1.Add(new Field("publicationinfo", null));
            }
            else
            {
                f1.Add(new Field("publicationinfo", _PublicationInfo));
            }
            f1.Add(new Field("pages", Convert.ToInt16(_Pages)));

            objSqlStatement1.Fields = f1;
            objSqlStatement1.Conditions = null;

            SqlStatement objSqlStatement2 = new SqlStatement();
            objSqlStatement2.TableName = "Book_Author";

            List<Field> f2 = new List<Field>();
            f2.Add(new Field("ISBN", _ISBN));
            f2.Add(new Field("Aid", Convert.ToInt32(_Aid)));

            objSqlStatement2.Fields = f2;
            objSqlStatement2.Conditions = null;

            if (objSqlBase.ExecuteDataReader().HasRows)
            {
                SqlStatement objSqlStatement3 = new SqlStatement();
                objSqlStatement3.TableName = "Book_Author";

                List<Condition> wcs3 = new List<Condition>();
                Condition wc3 = new Condition();
                wc3.MoreCondition = null;
                wc3.Field = "Aid";
                wc3.Operators = "=";
                wc3.Value = _Aid;
                wcs3.Add(wc3);
                Condition wc4 = new Condition();
                wc4.MoreCondition = "AND";
                wc4.Field = "ISBN";
                wc4.Operators = "=";
                wc4.Value = _ISBN;
                wcs3.Add(wc4);

                objSqlStatement3.Fields = null;
                objSqlStatement3.Conditions = wcs3;
                objSqlStatement3.OrderBy = null;

                objSqlBase.Sql = objSqlStatement3.GenerateSelectStatement();

                if (objSqlBase.ExecuteDataReader().HasRows)
                { objSqlBase.MessageBox("The Author ID is exist. Please check your input."); }
                else
                {
                    objSqlBase.Sql = objSqlStatement2.GenerateInsertStatement();
                    objSqlBase.Execute();
                    objSqlBase.MessageBox("Update successful! Please noted that only Author ID updated because ISBN is exist.");
                }
            }
            else if (Title.Length > 0 && (int.TryParse(_PublicationYear, out i) || _PublicationYear.Length == 0))
            {
                objSqlBase.Sql = objSqlStatement1.GenerateInsertStatement();
                objSqlBase.Execute();
                objSqlBase.Sql = objSqlStatement2.GenerateInsertStatement();
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


