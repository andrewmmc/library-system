using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace LibraryBL
{
    public class Classification
    {
        private int _signId;
        private string _signum;

        public int signId
        {
            get { return (int)this._signId; }
            set { this._signId = value; }
        }

        public string signum
        {
            get { return this._signum; }
            set { this._signum = value; }
        }

        public Classification(int id, string classification)
        {
            signId = id;
            signum = classification;
        }

        public static List<Classification> GetAllClassifications()
        {
            List<Classification> allClassifications = new List<Classification>();

            string query = "SELECT Cls.SignId, Cls.Signum  FROM [dbo].[CLASSIFICATION] Cls";

            DataSet dsClassifications = DBHelper.ExecuteQuery(query);

            if (dsClassifications.Tables.Count > 0)
            {
                foreach (DataRow dr in dsClassifications.Tables[0].Rows)
                {
                    Classification cls = new Classification((int)dr["SignId"], dr["Signum"] as string);
                    allClassifications.Add(cls);
                }
            }

            return allClassifications;
        }

        public override string ToString()
        {
            return signum;
        }
    }
}
