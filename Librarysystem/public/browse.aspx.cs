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
    public partial class public_browse : System.Web.UI.Page
    {
        PublicBrowse objPublicBrowse = new PublicBrowse();
        public string browse;
        public string index;

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
                this.browse = Request.QueryString["browse"];
                objPublicBrowse.Browse = browse;
                this.index = Request.QueryString["index"];
                objPublicBrowse.Index = index + "%";
                if (objPublicBrowse.Browse == "book")
                {
                    GridView1.DataSource = objPublicBrowse.GetAll();
                    GridView1.AllowPaging = true;
                    GridView1.DataBind();
                }
                if (objPublicBrowse.Browse == "author")
                {
                    GridView2.DataSource = objPublicBrowse.GetAll();
                    GridView2.AllowPaging = true;
                    GridView2.DataBind();
                }
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

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Data_Binding();
        }

        protected void PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            Data_Binding();
        }
    }
}