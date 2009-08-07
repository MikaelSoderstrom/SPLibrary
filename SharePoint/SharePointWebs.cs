using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net;

namespace SharePoint
{
    public partial class SPLibrary
    {
        #region "Webs"

        /// <summary>
        /// Get a collection with webs on the SharePoint site.
        /// </summary>
        /// <returns>Collection with webs.</returns>
        public SPWeb[] GetWebs()
        {
            WebServices ws = new WebServices(Credentials, Url);
            return ws.GetWebs();
        }

        #endregion
    }
}
