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
    public class Condition
    {
        private string _Field;
        private object _Value;
        private string _Operators;
        private string _MoreCondition;

        public string Field
        {
            get { return _Field; }
            set { _Field = value; }
        }
        public object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public string Operators
        {
            get { return _Operators; }
            set { _Operators = value; }
        }
        public string MoreCondition
        {
            get { return _MoreCondition; }
            set { _MoreCondition = value; }
        }

        public Condition()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Condition(string field, object value, string operators, string moreCondition)
        {
            _Field = field;
            _Value = value;
            _Operators = operators;
            _MoreCondition = moreCondition;
        }
    }
}
