using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using BL;

namespace Librarysystem
{
    public partial class public_bookdetails : System.Web.UI.Page
    {
        PublicBookdetails objBookdetails = new PublicBookdetails();

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
                //  Set the value of the Keyword & DDlist so it gets title / author and keywords.
                objBookdetails.ISBNvalue = Request.QueryString["ISBN"];
                DetailsView1.DataSource = objBookdetails.GetAll();
                DetailsView1.AllowPaging = true;
                DetailsView1.DataBind();
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

        protected void PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            DetailsView1.PageIndex = e.NewPageIndex;
            Data_Binding();
        }
    }
}