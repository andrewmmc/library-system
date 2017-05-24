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
public class SqlStatement
    {
        private string _TableName;
        private List<Field> _Fields;
        private List<Condition> _Conditions;
        private List<Orderby> _OrderBy;

        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        public List<Field> Fields
        {
            get { return _Fields; }
            set { _Fields = value; }
        }

        public List<Condition> Conditions
        {
            get { return _Conditions; }
            set { _Conditions = value; }
        }

        public List<Orderby> OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }

        public SqlStatement()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string GenerateSelectStatement()
        {
            string fieldLists = string.Empty;
            string whereLists = string.Empty;
            string orderLists = string.Empty;

            if (_Fields != null)
            {
                _Fields.ForEach(delegate(Field field) {
                    fieldLists = fieldLists + "," + field.FieldName;
                });

                fieldLists = fieldLists.Substring(1);
            }
            else
                fieldLists = " * ";


            if (_Conditions != null)
            {
                _Conditions.ForEach(delegate(Condition c)
                {
                    whereLists = whereLists + " " + c.MoreCondition + " " + c.Field + " " + c.Operators + " '" + c.Value + "'";
                });
            }

            if (_OrderBy != null)
            {
                _OrderBy.ForEach(delegate(Orderby o)
                {
                    orderLists = orderLists + " " + o.Field + " " + o.Operators;
                });
            }

            string sql = string.Empty;

            sql = "SELECT " + fieldLists + " FROM " + _TableName;
            if (string.IsNullOrEmpty(whereLists) && !string.IsNullOrEmpty(orderLists))
            {
                sql = "SELECT " + fieldLists + " FROM " + _TableName + " ORDER BY " + orderLists;
            }
            else if (!string.IsNullOrEmpty(whereLists) && !string.IsNullOrEmpty(orderLists))
            {
                sql = "SELECT " + fieldLists + " FROM " + _TableName + " WHERE " + whereLists + " ORDER BY " + orderLists;
            }
            else if (!string.IsNullOrEmpty(whereLists) && string.IsNullOrEmpty(orderLists))
            {
                sql = "SELECT " + fieldLists + " FROM " + _TableName + " WHERE " + whereLists;
            }

            return sql;
        }

        public string GenerateInsertStatement()
        {
            string fieldLists = string.Empty;
            string valueLists = string.Empty;

            if (_Fields != null)
            {               
                _Fields.ForEach(delegate(Field field)
                {
                    fieldLists = fieldLists + "," + field.FieldName;
                    valueLists = valueLists + ",'" + Convert.ToString(field.FieldValue) + "'";
                });                

                fieldLists = fieldLists.Substring(1);
                valueLists =  valueLists.Substring(1);
            }

            return "INSERT INTO " + _TableName + " (" + fieldLists + ") VALUES (" + valueLists + ")";
        }

        public string GenerateUpdateStatement()
        {
            string fieldValueLists = string.Empty;
            string whereLists = string.Empty;

            if (_Fields != null)
            {
                _Fields.ForEach(delegate(Field field)
                {
                    fieldValueLists = fieldValueLists + ",[" + field.FieldName + "] = '" + Convert.ToString(field.FieldValue) + "'";
                });

                fieldValueLists = fieldValueLists.Substring(1);
            }

            string sql = string.Empty;

            if (_Conditions != null)
            {
                _Conditions.ForEach(delegate(Condition c)
                {
                    whereLists = whereLists + " " + c.MoreCondition + " " + c.Field + " " + c.Operators + " '" + c.Value + "'";
                });

                sql = "UPDATE " + _TableName + " SET " + fieldValueLists + " WHERE " + whereLists;
            }

            return sql;
        }

        public string GenerateDeleteStatement()
        {
            string whereLists = string.Empty;
            string sql = string.Empty;

            if (_Conditions != null)
            {
                _Conditions.ForEach(delegate(Condition c)
                {
                    whereLists = whereLists + " " + c.MoreCondition + " " + c.Field + " " + c.Operators + " '" + c.Value + "'";
                });

                sql = "DELETE FROM " + _TableName + " WHERE " + whereLists;
            }
            return sql;
        }
    }
}
