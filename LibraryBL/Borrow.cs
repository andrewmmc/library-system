using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace LibraryBL
{
    public class Borrow
    {
        public string Barcode { get; set; }
        public string PersonId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ToBeReturnedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Book BorrowedBook { get; set; }
        public string BookTitle { get { return this.BorrowedBook.title; } }
        public string BookISBN { get { return this.BorrowedBook.isbn; } }

        public static List<Borrow> GetAllBorrows()
        {
            List<Borrow> allBorrows = new List<Borrow>();

            DataSet dsBorrows = DBHelper.ExecuteQuery("SELECT Br.*, Bk.ISBN, Bk.Title  FROM [dbo].[BORROW] Br INNER JOIN COPY C "+
                "ON C.Barcode = Br.Barcode INNER JOIN Book Bk ON Bk.ISBN = C.ISBN WHERE [ReturnDate] IS NULL");

            if (dsBorrows.Tables.Count > 0)
            {
                foreach (DataRow dr in dsBorrows.Tables[0].Rows)
                {
                    Borrow br = new Borrow();

                    br.Barcode = dr["Barcode"].ToString();
                    br.PersonId = dr["PersonId"].ToString();
                    br.BorrowDate = (DateTime)dr["BorrowDate"];
                    br.ToBeReturnedDate = (DateTime)dr["ToBeReturnedDate"];
                    br.BorrowedBook = new Book(dr["ISBN"].ToString(), dr["Title"].ToString());

                    allBorrows.Add(br);
                }
            }

            return allBorrows;
        }

        public static List<Borrow> GetBorrowsByPersonId(string personId)
        {
            List<Borrow> allBorrows = new List<Borrow>();

            DataSet dsBorrows = DBHelper.ExecuteQuery("SELECT Br.*, Bk.ISBN, Bk.Title  FROM [dbo].[BORROW] Br INNER JOIN COPY C " +
                "ON C.Barcode = Br.Barcode INNER JOIN Book Bk ON Bk.ISBN = C.ISBN WHERE [ReturnDate] IS NULL AND Br.PersonId = '" + personId + "'");

            if (dsBorrows.Tables.Count > 0)
            {
                foreach (DataRow dr in dsBorrows.Tables[0].Rows)
                {
                    Borrow br = new Borrow();

                    br.Barcode = dr["Barcode"].ToString();
                    br.PersonId = dr["PersonId"].ToString();
                    br.BorrowDate = ((DateTime)dr["BorrowDate"]).Date;
                    br.ToBeReturnedDate = ((DateTime)dr["ToBeReturnedDate"]).Date;
                    br.BorrowedBook = new Book(dr["ISBN"].ToString(), dr["Title"].ToString());

                    allBorrows.Add(br);
                }
            }

            return allBorrows;
        }

        public void Renew()
        {
            string qryRenew = "update Br set Br.ToBeReturnedDate = DATEADD(DAY, C.Period,convert( date, GETDATE())), ";
            qryRenew += "Br.BorrowDate = convert( date, GETDATE()) ";
            qryRenew += "from BORROW Br inner join BORROWER Brr ON Brr.PersonId = Br.PersonId ";
            qryRenew += "inner join CATEGORY C ON C.CatergoryId = Brr.CategoryId ";
            qryRenew += "where Br.Barcode = '"+this.Barcode+"' and Br.PersonId = '"+this.PersonId+"'";

            DBHelper.ExecuteNonQuery(qryRenew);
        }
    }
}
