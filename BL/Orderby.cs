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
    public class Orderby
    {
        private string _Field;
        private string _Operators;

        public string Field
        {
            get { return _Field; }
            set { _Field = value; }
        }

        public string Operators
        {
            get { return _Operators; }
            set { _Operators = value; }
        }

        public Orderby()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Orderby(string field, string operators)
        {
            _Field = field;
            _Operators = operators;
        }
    }
}
