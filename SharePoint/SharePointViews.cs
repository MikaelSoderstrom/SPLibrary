using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net;

namespace SharePoint
{
    public partial class SPLibrary
    {
        #region "Views"

        /// <summary>
        /// Get a list with views for the selected list.
        /// </summary>
        /// <param name="listname">Name of the list.</param>
        /// <returns>List with SPView.</returns>
        public SPView[] GetViews(string listname)
        {
            WebServices ws = new WebServices(Credentials, Url);
            return ws.GetViews(listname);
        }

        /// <summary>
        /// Get a specific view.
        /// </summary>
        /// <param name="listname">Name of the list.</param>
        /// <param name="listid">Id of the view.</param>
        /// <returns></returns>
        public List<string> GetView(string listname, string listid)
        {
            WebServices ws = new WebServices(Credentials, Url);
            return ws.GetView(listname, listid);
        }

        #endregion
    }
}
