using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Principal;

namespace Librarysystem
{
    public class Global : System.Web.HttpApplication
    {
        public static DataTable Authors;
        public static DataTable Book;

        protected void Application_Start(object sender, EventArgs e)
        {
       
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}