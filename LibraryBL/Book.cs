using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace LibraryBL
{
    public class Book
    {
        static Book()
        {
        }

        public string isbn
        {
            get { return this._isbn; }
            set { this._isbn = value; }
        }
        public string title
        {
            get { return this._title; }
            set { this._title = value; }
        }
        public string pubYear
        {
            get { return this._pubYear; }
            set { this._pubYear = value; }
        }
        public Publisher publisher
        {
            get { return this._publisher; }
            set { this._publisher = value; }
        }

        public Classification classification
        {
            get { return this._classification; }
            set { this._classification = value; }
        }

        public int libNr
        {
            get { return this._libNr; }
            set { this._libNr = value; }
        }

        public List<Author> authors
        {
            get { return this._authors; }
            set { this._authors = value; }
        }

        public string authorName { get; set; }

        private string _isbn, _title, _pubYear;
        private int _libNr;
        private Publisher _publisher;
        private Classification _classification;
        private List<Author> _authors;

        public Book() { }

        public Book(string Isbn, string Title)
        {
            isbn = Isbn;
            title = Title;
        }

        public static List<Book> GetAllBooks()
        {
            List<Book> allBooks = new List<Book>();

            DataSet dsBooks = DBHelper.ExecuteQuery("SELECT Bk.*, Pub.PublisherName, Cls.Signum   FROM dbo.BOOK Bk INNER JOIN [dbo].[PUBLISHER] Pub ON Pub.[PublisherId] = Bk.Publisher " +
                "INNER JOIN [dbo].[CLASSIFICATION] Cls ON Cls.SignId = Bk.SignId");

            DataSet dsAuthors = DBHelper.ExecuteQuery("SELECT BkAut.ISBN, Aut.Aid, Aut.FirstName, Aut.LastName, Aut.BirthYear "
                + "FROM dbo.BOOK_AUTHOR BkAut INNER JOIN dbo.AUTHOR Aut ON Aut.Aid = BkAut.Aid");

            if (dsBooks.Tables.Count > 0)
            {
                foreach (DataRow dr in dsBooks.Tables[0].Rows)
                {
                    Book bk = new Book();

                    bk.isbn = dr["ISBN"].ToString();
                    bk.title = dr["Title"].ToString();
                    bk.authors = GetAllAuthorsByISBN(bk.isbn, dsAuthors);
                    bk.authorName = bk.GetAuthors();
                    bk.pubYear = dr["PublicationYear"].ToString();
                    bk.publisher =  new Publisher(dr["Publisher"].ToString(), dr["PublisherName"].ToString());
                    bk.classification = new Classification ((int)dr["SignId"], dr["Signum"].ToString());
                    bk.libNr = (int)dr["LibNo"];

                    allBooks.Add(bk);
                }
            }

            return allBooks;
        }

        private static List<Author> GetAllAuthorsByISBN(string Isbn, DataSet dsAuthors)
        {
            List<Author> lstAuthors = new List<Author>();
            if (dsAuthors.Tables.Count > 0)
            {
                foreach (DataRow drAuthor in dsAuthors.Tables[0].Select("ISBN = '" + Isbn + "'"))
                {
                    Author auth = new Author((int)drAuthor["Aid"], drAuthor["FirstName"].ToString(),
                        drAuthor["LastName"].ToString(), drAuthor["BirthYear"].ToString());

                    lstAuthors.Add(auth);
                }
            }
            return lstAuthors;
        }

        public static Book GetDetailsByISBN(string ISBN)
        {
            Book bk = new Book();

            string query = "SELECT Bk.*, Pub.PublisherName, Cls.Signum   FROM dbo.BOOK Bk INNER JOIN [dbo].[PUBLISHER] Pub ON Pub.[PublisherId] = Bk.Publisher " +
                "INNER JOIN [dbo].[CLASSIFICATION] Cls ON Cls.SignId = Bk.SignId";
            query += " WHERE Bk.ISBN = '" + ISBN + "'";

            DataSet dsBooks = DBHelper.ExecuteQuery(query);

            DataSet dsAuthors = DBHelper.ExecuteQuery("SELECT BkAut.ISBN, Aut.Aid, Aut.FirstName, Aut.LastName, Aut.BirthYear "
                + "FROM dbo.BOOK_AUTHOR BkAut INNER JOIN dbo.AUTHOR Aut ON Aut.Aid = BkAut.Aid WHERE BkAut.ISBN = '" + ISBN + "'");

            if (dsBooks.Tables.Count > 0)
            {
                foreach (DataRow dr in dsBooks.Tables[0].Rows)
                {
                    bk.isbn = dr["ISBN"].ToString();
                    bk.title = dr["Title"].ToString();
                    bk.authors = GetAllAuthorsByISBN(bk.isbn, dsAuthors);
                    bk.authorName = bk.GetAuthors();
                    bk.pubYear = dr["PublicationYear"].ToString();
                    bk.publisher = new Publisher(dr["Publisher"].ToString(), dr["PublisherName"].ToString());
                    bk.classification = new Classification((int)dr["SignId"], dr["Signum"].ToString());
                    bk.libNr = (int)dr["LibNo"];
                }
            }

            return bk;
        }

        public string AddToDB()
        {
            string result = "0";

            string query;
            query = "if exists (select 1 from dbo.BOOK where ISBN = '" + isbn + "') begin select -1 end ";
            query += "else begin insert into dbo.BOOK ([ISBN] ,[Title] ,[SignId] ,[PublicationYear] ,[Publisher] ,[LibNo]) ";
            query += "values ('" + isbn + "', '" + title + "', '" + classification.signId + "', '" + pubYear + "', '" + publisher.publisherId + "', '" + libNr + "') ";
            query += "insert into [dbo].[BOOK_AUTHOR] (ISBN, Aid) Values ('" + isbn + "', '" + authors[0].aid + "') ";
            query += "select 1 end";

            DataSet dsResult = DBHelper.ExecuteQuery(query);

            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                result = dsResult.Tables[0].Rows[0][0].ToString();

            return result;
        }

        public string UpdateInDB(string oldIsbn)
        {
            string result = "0";

            string query;

            query = "if exists (select 1 from dbo.BOOK where ISBN = '" + isbn + "' and ISBN <> '" + oldIsbn + "') begin select -1 end ";
            query += "else begin update dbo.BOOK set [ISBN] = '" + isbn + "',[Title] = '" + title + "',[SignId] = '" + classification.signId + "'";
            query += ",[PublicationYear] = '" + pubYear + "',[Publisher] = '" + publisher.publisherId + "',[LibNo] = '" + libNr + "' where ISBN = '" + oldIsbn + "'";
            query += "update [dbo].[BOOK_AUTHOR] set Aid = '" + authors[0].aid + "' where ISBN = '" + oldIsbn + "' ";
            query += "select 1 end";

            DataSet dsResult = DBHelper.ExecuteQuery(query);

            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                result = dsResult.Tables[0].Rows[0][0].ToString();

            return result;
 
        }

        public void RemoveFromDB()
        {
            string query = "DELETE FROM dbo.Book WHERE ISBN = '" + isbn + "' ";
            query += "DELETE FROM [dbo].[BOOK_AUTHOR] where ISBN = '" + isbn + "' ";
            DBHelper.ExecuteNonQuery(query);
        }

        public string GetAuthors()
        {
            string strAuthors = string.Empty;

            foreach (Author auth in this.authors)
                strAuthors += auth.fullName + ",";

            return strAuthors.TrimEnd(',');
        }
    }
}
