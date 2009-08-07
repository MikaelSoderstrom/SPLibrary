using System;
using System.ComponentModel;
using SharePoint.Properties;
using System.Xml;

namespace SharePoint
{
    /// <summary>
    /// A list from sharepoint.
    /// </summary>
    public class SPList
    {
        #region "Private variables"

        private string _name;
        private string _id;
        private string _url;
        private XmlNode _xml;

        #endregion

        #region "Properties"

        /// <summary>
        /// Name of the view.
        /// </summary>
        [Description("Name of the view"), DefaultValue("")]
        public string Name
        {
            get { return _name; }
            internal set { _name = value; }
        }

        /// <summary>
        /// Id of the view.
        /// </summary>
        [Description("Id of the view"), DefaultValue("")]
        public string Id
        {
            get { return _id; }
            internal set { _id = value; }
        }

        /// <summary>
        /// Url to the list.
        /// </summary>
        [Description("Url to the list"), DefaultValue("")]
        public string Url
        {
            get { return _url; }
            internal set { _url = value; }
        }

        /// <summary>
        /// XmlNode with full information about the list.
        /// </summary>
        [Description("XmlNode with full information about the list."), DefaultValue("")]
        public XmlNode Xml
        {
            get { return _xml; }
            internal set { _xml = value; }
        }

        #endregion

        #region "Public methods"

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <exception cref="NotSupportedException">NotSupportedException</exception>
        [Obsolete("Constructor without parameters are not supported.", true)]
        public SPList()
        {
            throw new NotSupportedException(Resources.NotUsedConstructor);
        }

        #endregion

        #region "Internal methods"

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the view.</param>
        /// <param name="id">Id of the view.</param>
        /// <param name="url">Url to the lst.</param>
        /// <param name="xml">XML from SharePoint.</param>
        internal SPList(string name, string id, Uri url, XmlNode xml)
        {
            _name = name;
            _id = id;
            _url = url.ToString();
            _xml = xml;
        }

        #endregion
    }
}