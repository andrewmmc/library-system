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
    public class Field
    {
        private string _FieldName;
        private object _FieldValue;

        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }
        public object FieldValue
        {
            get { return _FieldValue; }
            set { _FieldValue = value; }
        }

        public Field()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Field(string fieldName, object fieldValue)
        {
            _FieldName = fieldName;
            _FieldValue = fieldValue;
        }
    }
}
