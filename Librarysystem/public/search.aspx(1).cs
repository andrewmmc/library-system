using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class public_search : System.Web.UI.Page
    {
        PublicSearch objPublic = new PublicSearch();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSearch.Text = Request.QueryString["q"];
                ddlistSearch.Text = Request.QueryString["browse"];
                Data_Binding();
            }
        }

        protected void Data_Binding()
        {
            try
            {
                //  Set the value of the Keyword & DDlist so it gets title / author and keywords.
                if (ddlistSearch.Text == "title")
                {
                    objPublic.DDlist = "b.Title";
                }
                if (ddlistSearch.Text == "author")
                {
                    objPublic.DDlist = "(a.FirstName+' '+a.LastName)";
                }
                objPublic.Keyword = "%" + txtSearch.Text + "%";
                GridView1.DataSource = objPublic.GetAll();
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

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Data_Binding();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Data_Binding();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            //  Simple clean up text to return the Gridview to it's default state.
            txtSearch.Text = "";
            objPublic.Keyword = "";
            Data_Binding();
        }

        public string ReplaceKeyWords(Match m)
        {
            return ("<span class='highlight'>" + m.Value + "</span>");
        }

        public string HighlightText(string InputTxt)
        {
            string Keyword_Highlight = txtSearch.Text;
            // Setup the regular expression and add the Or operator.
            Regex RegExp = new Regex(Keyword_Highlight.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
            // Highlight keywords by calling the delegate each time a keyword is found.
            return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
        }
    }
}