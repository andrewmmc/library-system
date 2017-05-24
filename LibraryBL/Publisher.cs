using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace LibraryBL
{
    public class Publisher
    {
        private string _publisherId, _publisherName;

        public string publisherId
        {
            get { return this._publisherId; }
            set { this._publisherId = value; }
        }

        public string publisherName
        {
            get { return this._publisherName; }
            set { this._publisherName = value; }
        }

        public Publisher(string id, string name)
        {
            publisherId = id;
            publisherName = name;

        }

        public static List<Publisher> GetAllPublishers()
        {
            List<Publisher> allPublishers = new List<Publisher>();

            string query = "SELECT Pub.PublisherId, Pub.PublisherName  FROM [dbo].[PUBLISHER] Pub";

            DataSet dsPublishers = DBHelper.ExecuteQuery(query);

            if (dsPublishers.Tables.Count > 0)
            {
                foreach (DataRow dr in dsPublishers.Tables[0].Rows)
                {
                    Publisher pub = new Publisher(dr["PublisherId"] as string, dr["PublisherName"] as string);
                    allPublishers.Add(pub);
                }
            }

            return allPublishers;
        }

        public override string ToString()
        {
            return publisherName;
        }
    }
}
