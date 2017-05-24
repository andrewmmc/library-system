using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ApplicationServices;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using BL;


namespace Librarysystem
{
    public partial class BorrowerBooksPage : System.Web.UI.Page
    {
        BorrowerBooks objBorrowerBooks = new BorrowerBooks();
        public string personid;
        public string editable;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.editable = Request.QueryString["adminedit"];
            if ((Roles.IsUserInRole("Admin")) && (editable == "true"))
            {
                objBorrowerBooks.wcField = "bb.PersonId";
                this.personid = Request.QueryString["personid"];
                objBorrowerBooks.wcValue = personid;
            }
            else
            {
                objBorrowerBooks.wcField = "asp.UserId";
                objBorrowerBooks.wcValue = Membership.GetUser().ProviderUserKey.ToString();
            }

            if (!IsPostBack)
            {
                Data_Binding();
            }
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Data_Binding();
        }

        protected void Data_Binding()
        {
            try
            {
                GridView1.DataSource = objBorrowerBooks.GetAll();
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
        protected void FireRowCommand(object sender, GridViewCommandEventArgs e)
        {
            string command = e.CommandName;
            objBorrowerBooks.Barcode = e.CommandArgument.ToString();
            string editable = Request.QueryString["adminedit"];
            if ((Roles.IsUserInRole("Admin")) && (editable == "true"))
            {
                objBorrowerBooks.wcField = "bb.PersonId";
                objBorrowerBooks.wcValue = Request.QueryString["personid"];
            }
            else
            {
                objBorrowerBooks.wcField = "asp.UserId";
                objBorrowerBooks.wcValue = Membership.GetUser().ProviderUserKey.ToString();
            }

            switch (command)
            {
                case "Renew":
                    objBorrowerBooks.Renew();
                    Data_Binding();
                    break;
            }
        }
    }
}