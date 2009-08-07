using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Web;

namespace SharePoint
{
    public partial class SPLibrary
    {
        #region "Lists"

        /// <summary>
        /// Returns all lists in the specified site.
        /// </summary>
        /// <param name="filter">Content Type to filter by.</param>
        /// <returns>Collection with lists.</returns>
        public SPList[] GetLists(ContentType filter)
        {
            //HttpContext.Current.Trace.Warn("GetLists", "Before execute");

            WebServices ws = new WebServices(Credentials, Url);
            SPList[] wsLists = ws.GetLists();

            //HttpContext.Current.Trace.Warn("GetLists", "Lists retrieved");

            //Uri list = Url;
            //ICredentials cred = Credentials;

            List<SPList> lists = new List<SPList>();

            foreach (SPList list in wsLists)
            {
                if (filter.Equals(ContentType.None) || ws.CheckContentTypes(list.Name, filter))
                    lists.Add(list);
            }

            //HttpContext.Current.Trace.Warn("GetLists", "Lists filtered");

            return lists.ToArray();
        }

        /// <summary>
        /// Returns all lists in the specified site.
        /// </summary>
        /// <returns>Collection with lists.</returns>
        public SPList[] GetLists()
        {
            return GetLists(ContentType.None);
        }

        /// <summary>
        /// Returns information about the specified list.
        /// </summary>
        /// <param name="listid"></param>
        /// <returns></returns>
        public SPSingleList GetList(string listid)
        {
            WebServices ws = new WebServices(Credentials, Url);
            return ws.GetList(listid);
        }

        #endregion
    }
}
