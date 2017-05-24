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
    public partial class BookPage : System.Web.UI.Page
    {
        AdminBook objBook = new AdminBook();

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
                GridView1.DataSource = objBook.GetAll();
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
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            GridView1.EditIndex = -1;

            objBook.ISBN = ((Label)row.FindControl("lblISBN")).Text;
            objBook.Title = ((TextBox)row.FindControl("txtTitle")).Text;
            objBook.SignId = Convert.ToInt32(((TextBox)row.FindControl("txtSignId")).Text);
            objBook.PublicationYear = ((TextBox)row.FindControl("txtPublicationYear")).Text;
            objBook.PublicationInfo = ((TextBox)row.FindControl("txtPublicationInfo")).Text;
            objBook.Pages = Convert.ToInt16(((TextBox)row.FindControl("txtPages")).Text);
            objBook.Aid = Convert.ToInt32(((Label)row.FindControl("lblAid")).Text);
            objBook.Update();

            Data_Binding();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

            objBook.ISBN = ((Label)row.FindControl("lblISBN")).Text;
            objBook.Delete();

            Data_Binding();
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Data_Binding();
        }

        protected void ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            GridView1.EditIndex = -1;
            string SignId = ((TextBox)FormView1.FindControl("addSignId")).Text;
            string Pages = ((TextBox)FormView1.FindControl("addPages")).Text;
            string Aid = ((TextBox)FormView1.FindControl("addAid")).Text;

            objBook.ISBN = ((TextBox)FormView1.FindControl("addISBN")).Text;
            objBook.Title = ((TextBox)FormView1.FindControl("addTitle")).Text;
            if (SignId == "") {
                objBook.SignId = 0;
            }
            else
            {
                objBook.SignId = Convert.ToInt32(SignId);
            }
            objBook.PublicationYear = ((TextBox)FormView1.FindControl("addPublicationYear")).Text;
            objBook.PublicationInfo = ((TextBox)FormView1.FindControl("addPublicationInfo")).Text;
            if (Pages == "")
            {
                objBook.Pages = 0;
            }
            else
            {
                objBook.Pages = Convert.ToInt16(Pages);
            }
            if (Aid == "")
            {
                objBook.Aid = 0;
            }
            else
            {
                objBook.Aid = Convert.ToInt32(Aid);
            }
            objBook.Insert();

            Data_Binding();
        }

    }
}