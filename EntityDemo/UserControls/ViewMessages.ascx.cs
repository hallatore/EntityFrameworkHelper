using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityDemo.Model;

namespace EntityDemo.UserControls
{
    public partial class ViewMessages : System.Web.UI.UserControl
    {
        public string UserId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            var ds = DataStore.GetSession();
            var messages = ds.Message.OrderBy(m => m.Subject);

            int userId;
            if (int.TryParse(UserId, out userId))
                messages = (IOrderedQueryable<Message>)messages.Where(m => m.UserId == userId);

            MessageList.DataSource = messages;
            MessageList.DataBind();
        }
    }
}