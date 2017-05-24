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
    public partial class WebForm4 : System.Web.UI.Page
    {
        AdminBorrower objBorrower = new AdminBorrower();

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
                GridView1.DataSource = objBorrower.GetAll();
                GridView1.AllowPaging = true;
                GridView1.Columns[0].Visible = true;
                GridView1.DataBind();
                GridView1.Columns[0].Visible = false; //Hide UserId column
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
            Label UserId = (Label)row.FindControl("lblUserId");
            TextBox textPersonId = (TextBox)row.FindControl("txtPersonId");
            TextBox textFirstName = (TextBox)row.FindControl("txtFirstName");
            TextBox textLastName = (TextBox)row.FindControl("txtLastName");
            TextBox textAddress = (TextBox)row.FindControl("txtAddress");
            TextBox textTelNo = (TextBox)row.FindControl("txtTelNo");
            DropDownList textCategory = (DropDownList)row.FindControl("txtCategory");

            //Convert Aid and BirthYear from string to int.
            int intUserId = Convert.ToInt32(UserId.Text);
            int intCategoryId = Convert.ToInt32(textCategory.Text);

            GridView1.EditIndex = -1;

            objBorrower.UserId = intUserId;
            objBorrower.PersonId = textPersonId.Text;
            objBorrower.FirstName = textFirstName.Text;
            objBorrower.LastName = textLastName.Text;
            objBorrower.Address = textAddress.Text;
            objBorrower.TelNo = textTelNo.Text;
            objBorrower.CategoryId = intCategoryId;
            objBorrower.Update();

            Data_Binding();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Get Aid from specific rows.
            //int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label UserId = (Label)row.FindControl("lblUserId");

            //Convert Aid from string to int
            int intUserId = Convert.ToInt32(UserId.Text);

            objBorrower.UserId = intUserId;
            objBorrower.Delete();

            Data_Binding();
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Data_Binding();
        }

        protected void ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            //Get data from textbox. (Remarks: UserId is auto increment value.)
            TextBox textPersonId = (TextBox)FormView1.FindControl("addPersonId");
            TextBox textFirstName = (TextBox)FormView1.FindControl("addFirstName");
            TextBox textLastName = (TextBox)FormView1.FindControl("addLastName");
            TextBox textTelNo = (TextBox)FormView1.FindControl("addTelNo");
            TextBox textAddress = (TextBox)FormView1.FindControl("addAddress");
            DropDownList textCategory = (DropDownList)FormView1.FindControl("addCategory");

            int intCategoryId = Convert.ToInt32(textCategory.Text);

            GridView1.EditIndex = -1;

            objBorrower.PersonId = textPersonId.Text;
            objBorrower.FirstName = textFirstName.Text;
            objBorrower.LastName = textLastName.Text;
            objBorrower.Address = textAddress.Text;
            objBorrower.TelNo = textTelNo.Text;
            objBorrower.CategoryId = intCategoryId;
            objBorrower.Insert();

            Data_Binding();
        }
    }
}

