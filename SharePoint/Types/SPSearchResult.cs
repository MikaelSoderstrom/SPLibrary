using System;
using System.Collections.Generic;
using System.Text;
using SharePoint.Properties;
using System.Xml;
using System.ComponentModel;

namespace SharePoint
{
    /// <summary>
    /// Search result from MOSS Search
    /// </summary>
    public class SPSearchResult
    {
        #region "Private variables"

        private Int64 _relevance;
        private string _title;
        private string _url;
        private Int64 _fileSize;
        private string _fileExtension;
        private string _description;
        private DateTime _date;
        private XmlNode _xml;
        private string _summary;

        #endregion

        #region "Properties"

        /// <summary>
        /// Relevance of result.
        /// </summary>
        [Description("Relevance of result"), DefaultValue(0)]
        public Int64 Relevance
        {
            get { return _relevance; }
            internal set { _relevance = value; }
        }

        /// <summary>
        /// Title of document.
        /// </summary>
        [Description("Title of document"), DefaultValue("")]
        public string Title
        {
            get { return _title; }
            internal set { _title = value; }
        }

        /// <summary>
        /// Url to document.
        /// </summary>
        [Description("Url to document"), DefaultValue("")]
        public string Url
        {
            get { return _url; }
            internal set { _url = value; }
        }

        /// <summary>
        /// File size of document.
        /// </summary>
        [Description("File size of document"), DefaultValue(0)]
        public Int64 FileSize
        {
            get { return _fileSize; }
            internal set { _fileSize = value; }
        }

        /// <summary>
        /// File extension of document.
        /// </summary>
        [Description("File extension of document"), DefaultValue("")]
        public string FileExtension
        {
            get { return _fileExtension; }
            internal set { _fileExtension = value; }
        }

        /// <summary>
        /// Description of document.
        /// </summary>
        [Description("Description of document"), DefaultValue("")]
        public string Description
        {
            get { return _description; }
            internal set { _description = value; }
        }

        /// <summary>
        /// Date and time when document was created.
        /// </summary>
        [Description("Date and time when document was created")]
        public DateTime Date
        {
            get { return _date; }
            internal set { _date = value; }
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

        /// <summary>
        /// Get a summary from the document.
        /// </summary>
        public string Summary
        {
            get { return _summary; }
            internal set { _summary = value; }
        }

        #endregion

        #region "Public methods"

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <exception cref="NotSupportedException">NotSupportedException</exception>
        [Obsolete("Constructor without parameters are not supported.", true)]
        public SPSearchResult()
        {
            throw new NotSupportedException(Resources.NotUsedConstructor);
        }

        #endregion

        #region "Internal methods"

        internal SPSearchResult(Int64 relevance, string title, string url, Int64 fileSize, string fileExtension, string description, DateTime date, string summary)
        {
            _relevance = relevance;
            _title = title;
            _url = url;
            _fileSize = fileSize;
            _fileExtension = fileExtension;
            _description = description;
            _date = date;
            _summary = summary;
            _xml = null;
        }

        #endregion
    }
}
