using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace LibraryBL
{
    public class Borrower
    {
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telno { get; set; }
        public int CategoryId { get; set; }
        public string Identifier { get { return PersonId + "(" + FirstName + " " + LastName + ")"; } }

        public Borrower() { }

        public Borrower(string personId, string firstName, string lastName, string telNo)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            Telno = telNo;
        }

        public Borrower(string personId)
        {
            PersonId = personId;
        }

        public static List<Borrower> GetAllBorrowers()
        {
            List<Borrower> allBorrowers = new List<Borrower>();

            DataSet dsBorrowers = DBHelper.ExecuteQuery("SELECT *  FROM [dbo].[BORROWER] ");

            if (dsBorrowers.Tables.Count > 0)
            {
                foreach (DataRow dr in dsBorrowers.Tables[0].Rows)
                {
                    Borrower br = new Borrower();

                    br.PersonId = dr["PersonId"].ToString();
                    br.FirstName = dr["FirstName"].ToString();
                    br.LastName = dr["LastName"].ToString();
                    br.Address = dr["Address"].ToString();
                    br.Telno = dr["Telno"].ToString();
                    br.CategoryId = (int)dr["CategoryId"];

                    allBorrowers.Add(br);
                }
            }

            return allBorrowers;
        }
    }
}
