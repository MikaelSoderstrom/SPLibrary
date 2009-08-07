using System;
using System.ComponentModel;
using SharePoint.Properties;
using System.Xml;

namespace SharePoint
{
    /// <summary>
    /// A view from a list.
    /// </summary>
    public class SPView
    {
        #region "Private variables"

        private string _name;
        private string _id;
        private XmlNode _xml;

        #endregion

        #region "Properties"

        /// <summary>
        /// Name of the view
        /// </summary>
        [Description("Name of the view"), DefaultValue("")]
        public string Name
        {
            get { return _name; }
            internal set { _name = value; }
        }

        /// <summary>
        /// Id of the view
        /// </summary>
        [Description("Id of the view"), DefaultValue("")]
        public string Id
        {
            get { return _id; }
            internal set { _id = value; }
        }

        /// <summary>
        /// XML from SharePoint.
        /// </summary>
        [Description("XML from SharePoint")]
        public XmlNode Xml
        {
            get { return _xml; }
            internal set { _xml = value; }
        }

        #endregion

        #region "Public methods"



        #endregion
        /// <summary>
        /// Not supported.
        /// </summary>
        /// <exception cref="NotSupportedException">NotSupportedException</exception>
        [Obsolete("Constructor without parameters are not supported.", true)]
        public SPView()
        {
            throw new NotSupportedException(Resources.NotUsedConstructor);
        }
        #region "Internal methods"

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the view.</param>
        /// <param name="id">Id of the view.</param>
        /// <param name="xml">XML from SharePoint.</param>
        internal SPView(string name, string id, XmlNode xml)
        {
            _name = name;
            _id = id;
            _xml = xml;
        }

        #endregion
    }
}
