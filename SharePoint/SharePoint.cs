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
        #region "Private variables"

        private Uri _url;
        private ICredentials _credentials;

        #endregion

        #region "Properties"

        /// <summary>
        /// Set the credentials to use when connecting to the web services in SharePoint.
        /// </summary>
        [Description("Set the credentials to use when connecting to the web services in SharePoint")]
        public ICredentials Credentials
        {
            get { return _credentials; }
            set { _credentials = value; }
        }

        /// <summary>
        /// Url to list.
        /// </summary>
        [Description("Set the url to the list"), DefaultValue("")]
        public Uri Url
        {
            get
            {
                return new Uri(_url.ToString() + "/_vti_bin/lists.asmx");
            }
            set { _url = value; }
        }

        #endregion

        #region "Constructors"
        /// <summary>
        /// Constructor.
        /// </summary>
        public SPLibrary()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">Url to list.</param>
        public SPLibrary(Uri url)
        {
            Url = url;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="credentials">Credentials to use when connecting to web services.</param>
        public SPLibrary(ICredentials credentials)
        {
            _credentials = credentials;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">Url to list.</param>
        /// <param name="credentials">Credentials to use when connecting to web services.</param>
        public SPLibrary(Uri url, ICredentials credentials)
        {
            Url = url;
            _credentials = credentials;
        }

        #endregion
    }
}
