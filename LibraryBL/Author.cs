using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace LibraryBL
{
    public class Author
    {
        public int aid
        {
            get { return this._aid; }
            set { this._aid = value; }
        }

        public string firstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }

        public string lastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }

        public string birthYear
        {
            get { return this._birthYear; }
            set { this._birthYear = value; }
        }

        public string fullName
        {
            get { return firstName + " " + lastName; }
        }

        private int _aid;
        private string _firstName, _lastName, _birthYear;

        public Author(int Aid)
        {
            this.aid = Aid;
        }

        public Author(int Aid, string FirstName, string LastName)
        {
            this.aid = Aid;
            this.firstName = FirstName;
            this.lastName = LastName;
        }

        public Author(int Aid, string FirstName, string LastName, string BirthYear)
        {
            this.aid = Aid;
            this.firstName = FirstName;
            this.lastName = LastName;
            this.birthYear = BirthYear;
        }

        public static List<Author> GetAllAuthors()
        {
            List<Author> allAuthors = new List<Author>();

            string query = "SELECT Aid ,FirstName ,LastName ,BirthYear FROM [dbo].[AUTHOR]";

            DataSet dsAuthors = DBHelper.ExecuteQuery(query);

            if (dsAuthors.Tables.Count > 0)
            {
                foreach (DataRow dr in dsAuthors.Tables[0].Rows)
                {
                    Author auth = new Author((int)dr["Aid"], dr["FirstName"] as string, dr["LastName"] as string, dr["BirthYear"] as string);
                    allAuthors.Add(auth);
                }
            }

            return allAuthors;
        }
    }
}
