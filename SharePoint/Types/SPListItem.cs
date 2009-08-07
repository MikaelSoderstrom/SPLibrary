using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using SharePoint.Properties;
using System.Xml;

namespace SharePoint
{
    /// <summary>
    /// List item from SharePoint.
    /// </summary>
    public class SPListItem
    {
        #region "Private variables"

        private string _id;
        private string _name;
        private string _url;
        private string _createdBy;
        private DateTime _created;
        private string _modifiedBy;
        private DateTime _modified;
        private string _itemType;
        private string _contentTypeId;
        private XmlNode _xml;
        private Dictionary<string, string> _metaData;

        #endregion

        #region "Properties"

        /// <summary>
        /// Id of the item.
        /// </summary>
        [Description("Id of the item"), DefaultValue("")]
        public string Id
        {
            get { return _id; }
            internal set { _id = value; }
        }

        /// <summary>
        /// Name of the listitem.
        /// </summary>
        [Description("Name of the listitem"), DefaultValue("")]
        public string Name
        {
            get { return _name; }
            internal set { _name = value; }
        }

        /// <summary>
        /// URL to the document if any.
        /// </summary>
        [Description("URL to the document if any")]
        public string Url
        {
            get { return _url; }
            internal set { _url = value; }
        }

        /// <summary>
        /// Name of the user who created the item.
        /// </summary>
        [Description("Name of the user who created the item"), DefaultValue("")]
        public string CreatedBy
        {
            get { return _createdBy; }
            internal set { _createdBy = value; }
        }

        /// <summary>
        /// When the item was created.
        /// </summary>
        [Description("When the item was created"), DefaultValue("0001-01-01 00:00:00")]
        public DateTime Created
        {
            get { return _created; }
            internal set { _created = value; }
        }

        /// <summary>
        /// User who modifed the item the last time.
        /// </summary>
        [Description("User who modifed the item the last time"), DefaultValue("")]
        public string ModifiedBy
        {
            get { return _modifiedBy; }
            internal set { _modifiedBy = value; }
        }

        /// <summary>
        /// Last time the item was modified.
        /// </summary>
        [Description("Last time the item was modified"), DefaultValue("0001-01-01 00:00:00")]
        public DateTime Modified
        {
            get { return _modified; }
            internal set { _modified = value; }
        }

        /// <summary>
        /// Type of the item.
        /// </summary>
        [Description("Type of the item"), DefaultValue("")]
        public string ItemType
        {
            get { return _itemType; }
            internal set { _itemType = value; }
        }

        /// <summary>
        /// Xml from SharePoint.
        /// </summary>
        [Description("Xml from SharePoint")]
        public XmlNode Xml
        {
            get { return _xml; }
            internal set { _xml = value; }
        }

        /// <summary>
        /// Returns metadata for the item.
        /// </summary>
        public Dictionary<string, string> MetaData
        {
            get { return _metaData; }
            internal set { _metaData = value; }
        }

        #endregion

        #region "Public methods"

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <exception cref="NotSupportedException">NotSupportedException</exception>
        [Obsolete("Constructor without are not supported.", true)]
        public SPListItem()
        {
            throw new NotSupportedException(Resources.NotUsedConstructor);
        }

        #endregion

        #region "Internal methods"

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Id of the item.</param>
        /// <param name="name">Name of the listitem.</param>
        /// <param name="url">URL to the document if any.</param>
        /// <param name="createdby">Name of the user who created the item.</param>
        /// <param name="created">When the item was created.</param>
        /// <param name="modifiedby">User who modifed the item the last time.</param>
        /// <param name="modified">Last time the item was modified.</param>
        /// <param name="itemtype">Type of the item.</param>
        /// <param name="contenttypeid">Id of the content type.</param>
        /// <param name="xml">XML from SharePoint.</param>
        internal SPListItem(string id, string name, Uri url, string createdby, DateTime created, string modifiedby, DateTime modified, string itemtype, string contenttypeid, XmlNode xml)
        {
            _id = id;
            _name = name;
            _url = url.ToString();
            _createdBy = createdby;
            _created = created;
            _modifiedBy = modifiedby;
            _modified = modified;
            _itemType = itemtype;
            _contentTypeId = contenttypeid;
            _xml = xml;

            _metaData = new Dictionary<string, string>();

            foreach (XmlAttribute attrib in xml.Attributes)
                _metaData.Add(attrib.Name.Replace("ows_", String.Empty), attrib.Value);
        }

        #endregion
    }
}
