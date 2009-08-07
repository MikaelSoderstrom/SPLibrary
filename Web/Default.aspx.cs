using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharePoint;
using System.Net;

namespace Web
{
    public partial class _Default : System.Web.UI.Page
    {
        SPLibrary sp;

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "http://moss";

            sp = new SPLibrary(new Uri(url), new NetworkCredential("user", "password", "domain"));
        }

        protected void btnGetWebs_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbWebs.Text))
                sp.Url = new Uri(tbWebs.Text);

            gvWebs.DataSource = sp.GetWebs();
            gvWebs.DataBind();

            SPList[] lists = sp.GetLists();

            gvFiles.DataSource = lists;
            gvFiles.DataBind();
        }

        protected void btnGetList_Click(object sender, EventArgs e)
        {
            List<SPSingleList> list = new List<SPSingleList>();
            list.Add(sp.GetList(tbList.Text));

            gvList.DataSource = list;
            gvList.DataBind();

            gvListItems.DataSource = sp.GetListItems(tbList.Text);
            gvListItems.DataBind();
        }

        protected void gvListItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            GridView gv = (GridView)e.Row.Cells[8].FindControl("gvListItemsMetaData");
            gv.DataSource = ((SPListItem)e.Row.DataItem).MetaData;
            gv.DataBind();
        }
    }
}
