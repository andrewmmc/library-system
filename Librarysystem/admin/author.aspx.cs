using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BL;

namespace Librarysystem
{
    public partial class AuthorPage : System.Web.UI.Page
    {
        AdminAuthor objAuthor = new AdminAuthor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Data_Binding();
            }
        }

        protected void Data_Binding()
        {
            try
            {
                GridView1.DataSource = objAuthor.GetAll();
                GridView1.AllowPaging = true;
                GridView1.DataBind();
            }
            catch (SqlException ex)
            {
                //handle exception
            }
            catch (Exception ex)
            {
                //handle exception
            }
        }

        protected void RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Data_Binding();
        }

        protected void RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Data_Binding();
        }

        protected void RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Get data from textbox.
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label Aid = (Label)row.FindControl("lblAid");
            TextBox textFirstName = (TextBox)row.FindControl("txtFirstName");
            TextBox textLastName = (TextBox)row.FindControl("txtLastName");
            TextBox textBirthYear = (TextBox)row.FindControl("txtBirthYear");

            //Convert Aid from string to int.
            int intAid = Convert.ToInt32(Aid.Text);
            GridView1.EditIndex = -1;

            objAuthor.Aid = intAid;
            objAuthor.FirstName = textFirstName.Text;
            objAuthor.LastName = textLastName.Text;
            objAuthor.BirthYear = textBirthYear.Text;
            objAuthor.Update();

            Data_Binding();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Get Aid from specific rows.
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label Aid = (Label)row.FindControl("lblAid");

            //Convert Aid from string to int
            int intAid = Convert.ToInt32(Aid.Text);

            objAuthor.Aid = intAid;
            objAuthor.Delete();

            Data_Binding();
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Data_Binding();
        }

        protected void ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            //Get data from textbox. (Remarks: Aid is auto increment value.)
            TextBox textFirstName = (TextBox)FormView1.FindControl("addFirstName");
            TextBox textLastName = (TextBox)FormView1.FindControl("addLastName");
            TextBox textBirthYear = (TextBox)FormView1.FindControl("addBirthYear");
            GridView1.EditIndex = -1;

            objAuthor.FirstName = textFirstName.Text;
            objAuthor.LastName = textLastName.Text;
            objAuthor.BirthYear = textBirthYear.Text;
            objAuthor.Insert();

            Data_Binding();
        }

    }
}