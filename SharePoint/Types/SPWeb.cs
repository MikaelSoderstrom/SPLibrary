using System;
using System.ComponentModel;
using SharePoint.Properties;
using System.Xml;

namespace SharePoint
{
    /// <summary>
    /// A web in SharePoint
    /// </summary>
    public class SPWeb
    {

        #region "Private variables"

        private string _name;
        private string _url;
        private XmlNode _xml;

        #endregion

        #region "Properties"

        /// <summary>
        /// Name of the view.
        /// </summary>
        [Description("Name of the web"), DefaultValue("")]
        public string Name
        {
            get { return _name; }
            internal set { _name = value; }
        }

        /// <summary>
        /// Id of the view.
        /// </summary>
        [Description("Url to the web"), DefaultValue("")]
        public string Url
        {
            get { return _url; }
            internal set { _url = value; }
        }

        /// <summary>
        /// XML from SharePoint.
        /// </summary>
        [Description("XML from SharePoint")]
        public XmlNode Xml
        {
            get { return _xml; }
            set { _xml = value; }
        }

        #endregion

        #region "Public methods"

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <exception cref="NotSupportedException">NotSupportedException</exception>
        [Obsolete("Constructor without parameters are not supported.", true)]
        public SPWeb()
        {
            throw new NotSupportedException(Resources.NotUsedConstructor);
        }

        #endregion

        #region "Internal methods"

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the web.</param>
        /// <param name="url">Url to the web.</param>
        /// <param name="xml">XML from SharePoint.</param>
        internal SPWeb(string name, string url, XmlNode xml)
        {
            _name = name;
            _url = url;
            _xml = xml;
        }

        #endregion
    }
}
