using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace EntityDemo
{
    public class Global : System.Web.HttpApplication
    {
        protected void Request_End(object sender, EventArgs e)
        {
            DataStore.Dispose();
        }
    }
}