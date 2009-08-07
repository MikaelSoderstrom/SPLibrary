using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net;

namespace SharePoint
{
    /// <summary>
    /// Get data from SharePoint.
    /// </summary>
    public partial class SPLibrary
    {
        #region "List items"

        /// <summary>
        /// Returns a filtered list with items in the specified list.
        /// </summary>
        /// <param name="listid">Id of the list.</param>
        /// <param name="filter">Key to filter by, and value to search for.</param>
        /// <returns>Collection with list items.</returns>
        public SPListItem[] GetListItems(string listid, Dictionary<string, string> filter)
        {
            WebServices ws = new WebServices(this.Credentials, this.Url);
            SPListItem[] items = ws.GetListItems(listid, filter);
            return items;
        }

        /// <summary>
        /// Returns a list with items in the specified list.
        /// </summary>
        /// <param name="listid"></param>
        /// <returns></returns>
        public SPListItem[] GetListItems(string listid)
        {
            return GetListItems(listid, new Dictionary<string, string>());
        }

        #endregion
    }
}
