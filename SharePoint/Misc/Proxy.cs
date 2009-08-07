using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Net;
using SharePoint.WSCopy;
using SharePoint.WSLists;
using SharePoint.WSViews;
using System.IO;
using SharePoint.SPSearch;
using SharePoint.WSWebs;
using System.Text;
using System.Data;
using System.Web;

namespace SharePoint
{
    /// <summary>
    /// Internal proxy class for the web services.
    /// </summary>
    public class WebServices
    {
        #region "Private variables"

        ICredentials _credentials;
        Uri _url;

        #endregion

        #region "Properties"

        /// <summary>
        /// Crendentials for authentication.
        /// </summary>
        public ICredentials Credentials
        {
            get { return _credentials; }
            set { _credentials = value; }
        }

        /// <summary>
        /// Url to web service.
        /// </summary>
        public Uri Url
        {
            get { return _url; }
            set { _url = value; }
        }

        #endregion

        #region "Private const"

        /// <summary>
        /// SharePoint Namespace Prefix.
        /// </summary>
        private const string SharePointNamespacePrefix = "sp";

        /// <summary>
        /// SharePoint Namespace URI.
        /// </summary>
        private const string SharePointNamespaceURI = "http://schemas.microsoft.com/sharepoint/soap/";

        /// <summary>
        /// List Items Namespace Prefix.
        /// </summary>
        private const string ListItemsNamespacePrefix = "z";

        /// <summary>
        /// List Items Namespace URI.
        /// </summary>
        private const string ListItemsNamespaceURI = "#RowsetSchema";

        /// <summary>
        /// Picture Libraries Namespace Prefix.
        /// </summary>
        private const string PictureLibrariesNamespacePrefix = "y";

        /// <summary>
        /// Picture Libraries Namespace URI.
        /// </summary>
        private const string PictureLibrariesNamespaceURI = "http://schemas.microsoft.com/sharepoint/soap/ois/";

        /// <summary>
        /// Web Parts Namespace Prefix.
        /// </summary>
        private const string WebPartsNamespacePrefix = "w";

        /// <summary>
        /// Web Parts Namespace URI.
        /// </summary>
        private const string WebPartsNamespaceURI = "http://schemas.microsoft.com/WebPart/v2";

        /// <summary>
        /// Directory Namespace Prefix.
        /// </summary>
        private const string DirectoryNamespacePrefix = "d";

        /// <summary>
        /// Directory Namespace URI.
        /// </summary>
        private const string DirectoryNamespaceURI = "http://schemas.microsoft.com/sharepoint/soap/directory/";

        /// <summary>
        /// Search Results Document Prefix.
        /// </summary>
        private const string SearchResultsDocumentPrefix = "r";

        /// <summary>
        /// Search Results Document URI.
        /// </summary>
        private const string SearchResultsDocumentURI = "urn:Microsoft.Search.Response.Document";

        /// <summary>
        /// Search Results Document Document Prefix.
        /// </summary>
        private const string SearchResultsDocumentDocumentPrefix = "d";

        /// <summary>
        /// Search Results Document Document URI.
        /// </summary>
        private const string SearchResultsDocumentDocumentURI = "urn:Microsoft.Search.Response.Document.Document";

        #endregion

        #region "Private methods"

        /// <summary>
        /// Returns a XmlNodeList filtered by an XPath.
        /// </summary>
        /// <param name="doc">XmlDocument with XML from the Web Service.</param>
        /// <param name="XPathQuery">XPath to use for the query.</param>
        /// <returns>XmlNodeList with filtered XML.</returns>
        protected static XmlNodeList RunXPathQuery(XmlDocument doc, string XPathQuery)
        {
            XmlNamespaceManager NamespaceMngr = new XmlNamespaceManager(doc.NameTable);
            NamespaceMngr.AddNamespace(SharePointNamespacePrefix, SharePointNamespaceURI);
            NamespaceMngr.AddNamespace(ListItemsNamespacePrefix, ListItemsNamespaceURI);
            NamespaceMngr.AddNamespace(PictureLibrariesNamespacePrefix, PictureLibrariesNamespaceURI);
            NamespaceMngr.AddNamespace(WebPartsNamespacePrefix, WebPartsNamespaceURI);
            NamespaceMngr.AddNamespace(DirectoryNamespacePrefix, DirectoryNamespaceURI);
            NamespaceMngr.AddNamespace(SearchResultsDocumentPrefix, SearchResultsDocumentURI);
            NamespaceMngr.AddNamespace(SearchResultsDocumentPrefix, SearchResultsDocumentURI);
            NamespaceMngr.AddNamespace(SearchResultsDocumentDocumentPrefix, SearchResultsDocumentDocumentURI);

            return doc.SelectNodes(XPathQuery, NamespaceMngr);
        }

        /// <summary>
        /// Get the value from a node. If null, then return an empty string.
        /// </summary>
        /// <param name="node">Node to get value from.</param>
        /// <returns>Value for the node. Empty string if null.</returns>
        private string GetNode(XmlNode node)
        {
            if (node == null) return String.Empty;
            return (node.Value ?? node.InnerText);
        }

        /// <summary>
        /// Get the value from an attribute. If null, then return an empty string.
        /// </summary>
        /// <param name="attrib">Attribute to get value from.</param>
        /// <returns>Value for the attribute. Empty string if null.</returns>
        private string GetNodeAttribute(XmlAttribute attrib)
        {
            if (attrib == null) return String.Empty;
            else return Utils.ParseSPField(attrib.Value).LookupValue;
        }

        /// <summary>
        /// Parses the date in the string.
        /// </summary>
        /// <param name="date">Date to parse.</param>
        /// <returns>DateTime with the parsed date.</returns>
        private DateTime GetDateTime(string date)
        {
            DateTime d = DateTime.MinValue;

            DateTime.TryParse(date, out d);

            return d;
        }

        /// <summary>
        /// Return a value if it exists.
        /// </summary>
        /// <param name="node">XmlNode with attribute.</param>
        /// <param name="attribute">Attribute to get.</param>
        /// <returns>XmlAttribute if exists.</returns>
        private XmlAttribute TryGetAttribute(XmlNode node, string attribute)
        {
            if (node.Attributes.Count > 0)
                return node.Attributes[attribute];

            return null;
        }

        /// <summary>
        /// Check if the list contains any items with the specified content type.
        /// </summary>
        /// <param name="listname">SharePoint List</param>
        /// <param name="filter">Content Type to filter by.</param>
        /// <returns>True if the list contains at least one item with the specified Content Type.</returns>
        public bool CheckContentTypes(string listname, ContentType filter)
        {
            HttpContext.Current.Trace.Warn("Proxy", String.Format("CheckContentTypes(\"{0}\", ContentType.{1})", listname, filter.ToString()));

            Lists lists = new Lists();
            lists.Credentials = Credentials;
            lists.Url = Url.ToString();
            lists.Proxy = GetProxy();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(lists.GetListContentTypes(listname, filter.GetHashCode().ToString()).OuterXml);

            foreach (XmlNode node in RunXPathQuery(doc, "//sp:ContentType"))
            {
                if (Utils.IsInvalidDocument(node.Attributes["ID"].Value))
                    return false;

                if (Utils.IsTypeOf(node.Attributes["ID"].Value, filter))
                    return true;
            }

            return false;
        }

        #endregion

        #region "Public methods"

        #region "Search"

        /// <summary>
        /// Queries the SharePoint Web Service.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <returns>Collection with results.</returns>
        public SPSearchResult[] Search(string keyword)
        {
            List<SPSearchResult> items = new List<SPSearchResult>();

            QueryService query = new QueryService();
            query.Credentials = Credentials;
            query.Url = Url.ToString().Replace("lists.asmx", "search.asmx"); //search.asmx for MOSS, spsearch.asmx for WSS.
            query.Proxy = GetProxy();

            ServicePointManager.ServerCertificateValidationCallback += ((sender, certificate, chain, sslPolicyErrors) => true);

            //string postXml = String.Format("<QueryPacket xmlns=\"urn:Microsoft.Search.Query\"><Query><SupportedFormats><Format>urn:Microsoft.Search.Response.Document:Document</Format></SupportedFormats><Context><QueryText type=\"STRING\" language=\"en-us\">{0}</QueryText></Context><Range><StartAt>1</StartAt><Count>25</Count></Range><EnableStemming>true</EnableStemming><TrimDuplicates>true</TrimDuplicates><IgnoreAllNoiseQuery>true</IgnoreAllNoiseQuery><ImplicitAndBehavior>true</ImplicitAndBehavior><IncludeRelevanceResults>true</IncludeRelevanceResults><IncludeSpecialTermResults>true</IncludeSpecialTermResults><IncludeHighConfidenceResults>true</IncludeHighConfidenceResults></Query></QueryPacket>", keyword);
            string postXml = String.Format("<QueryPacket xmlns=\"urn:Microsoft.Search.Query\"><Query><SupportedFormats><Format>urn:Microsoft.Search.Response.Document:Document</Format></SupportedFormats><Context><QueryText type=\"STRING\" language=\"en-us\">{0}</QueryText></Context><Range><StartAt>1</StartAt><Count>50</Count></Range><Properties><Property name=\"HitHighlightedSummary\"/><Property name=\"WorkId\"/><Property name=\"Rank\"/><Property name=\"Title\"/><Property name=\"Author\"/><Property name=\"Size\"/><Property name=\"Path\"/><Property name=\"Description\"/><Property name=\"Write\"/><Property name=\"SiteName\"/><Property name=\"IsDocument\"/></Properties><EnableStemming>true</EnableStemming><TrimDuplicates>true</TrimDuplicates><IgnoreAllNoiseQuery>true</IgnoreAllNoiseQuery><ImplicitAndBehavior>true</ImplicitAndBehavior><IncludeRelevanceResults>true</IncludeRelevanceResults><IncludeSpecialTermResults>true</IncludeSpecialTermResults><IncludeHighConfidenceResults>true</IncludeHighConfidenceResults></Query></QueryPacket>", keyword);
            //WSS: string postXml = String.Format("<QueryPacket xmlns=\"urn:Microsoft.Search.Query\"><Query><SupportedFormats><Format>urn:Microsoft.Search.Response.Document:Document</Format></SupportedFormats><Context><QueryText language=\"en-US\" type=\"STRING\">{0}</QueryText></Context></Query></QueryPacket>", keyword);
            string getXml = query.Query(postXml);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(getXml);

            foreach (XmlNode node in RunXPathQuery(doc, "//r:Document"))
            {
                if (Convert.ToInt64(GetSearchValue(node, "Size")) > 0/* && !GetNodeAttribute(TryGetAttribute(node["Action"].ChildNodes[0], "fileExt")).Equals("aspx")*/)
                    items.Add(new SPSearchResult(Convert.ToInt64(GetSearchValue(node, "Rank")),
                        GetSearchValue(node, "Title"),
                        GetNode(node["Action"].ChildNodes[0]),
                        Convert.ToInt64(GetSearchValue(node, "Size")),
                        GetNodeAttribute(node["Action"].ChildNodes[0].Attributes["fileExt"]),
                        GetSearchValue(node, "Description"),
                        Convert.ToDateTime(String.IsNullOrEmpty(GetSearchValue(node, "Write")) ? DateTime.MinValue.ToString() : GetSearchValue(node, "Write")),
                        GetSearchValue(node, "HitHighlightedSummary")));
            }

            return items.ToArray();
        }

        /// <summary>
        /// Queries the SharePoint Web Service.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <param name="searchfields">Fields to return.</param>
        /// <returns>Collection with results.</returns>
        public List<Dictionary<string, string>> Search(string keyword, SearchField searchfields)
        {
            List<Dictionary<string, string>> items = new List<Dictionary<string, string>>();
            StringBuilder postXml = new StringBuilder();
            XmlDocument doc = new XmlDocument();

            QueryService query = new QueryService();
            query.Credentials = Credentials;
            query.Url = Url.ToString().Replace("lists.asmx", "search.asmx");
            query.Proxy = GetProxy();

            ServicePointManager.ServerCertificateValidationCallback += ((sender, certificate, chain, sslPolicyErrors) => true);

            //Start fill postXml
            postXml.Append(String.Format("<QueryPacket xmlns=\"urn:Microsoft.Search.Query\"><Query><SupportedFormats><Format>urn:Microsoft.Search.Response.Document:Document</Format></SupportedFormats><Context><QueryText type=\"STRING\" language=\"en-us\">{0}</QueryText></Context><Range><StartAt>1</StartAt><Count>50</Count></Range><Properties>", keyword));
            foreach (string field in searchfields.ToString().Replace(" ", "").Split(','))
                postXml.Append(String.Format("<Property name=\"{0}\"/>", field));
            postXml.Append("<Property name=\"Write\"/></Properties><EnableStemming>true</EnableStemming><TrimDuplicates>true</TrimDuplicates><IgnoreAllNoiseQuery>true</IgnoreAllNoiseQuery><ImplicitAndBehavior>true</ImplicitAndBehavior><IncludeRelevanceResults>true</IncludeRelevanceResults><IncludeSpecialTermResults>true</IncludeSpecialTermResults><IncludeHighConfidenceResults>true</IncludeHighConfidenceResults></Query></QueryPacket>");
            //End fill postXml

            doc.LoadXml(query.Query(postXml.ToString()));

            foreach (XmlNode node in RunXPathQuery(doc, "//r:Document"))
            {
                Dictionary<string, string> item = new Dictionary<string, string>();

                foreach (XmlAttribute attrib in node.Attributes)
                    item.Add(attrib.Name, attrib.Value);

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// Queries the SharePoint Web Service.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <param name="metadata">Metadata to return.</param>
        /// <returns>Collection with results.</returns>
        public List<Dictionary<string, string>> Search(string keyword, params string[] metadata)
        {
            return Search(keyword, true, true, true, true, true, true, true, metadata);
        }

        /// <summary>
        /// Search for items in SharePoint.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <param name="enableStemming">Specifies whether stemming is enabled.</param>
        /// <param name="trimDuplicates">Specifies whether duplicate results collapsing is enabled.</param>
        /// <param name="ignoreAllNoiseQuery">Specifies whether the search service should ignore noise words in the search query.</param>
        /// <param name="implicitAndBehavior">Specifies whether there is a default AND between keyword terms.</param>
        /// <param name="includeRelevanceResults">Specifies whether relevant results should be included in the response returned by the Query Web service.</param>
        /// <param name="includeSpecialTermResults">Specifies whether high confidence results should be included in the response returned by the Query Web service.</param>
        /// <param name="includeHighConfidenceResults">Specifies whether high confidence results should be included in the response returned by the Query Web service.</param>
        /// <param name="metadata">Fields to get in search result.</param>
        /// <returns>Items from SharePoint based on search phrase.</returns>
        public List<Dictionary<string, string>> Search(string keyword, bool enableStemming, bool trimDuplicates, bool ignoreAllNoiseQuery, bool implicitAndBehavior, bool includeRelevanceResults, bool includeSpecialTermResults, bool includeHighConfidenceResults, params string[] metadata)
        {
            QueryService query = new QueryService();
            query.Credentials = Credentials;
            query.Url = Url.ToString().Replace("lists.asmx", "search.asmx");
            query.Proxy = GetProxy();

            ServicePointManager.ServerCertificateValidationCallback += ((sender, certificate, chain, sslPolicyErrors) => true);

            StringBuilder sb = new StringBuilder();

            sb.Append("<QueryPacket xmlns=\"urn:Microsoft.Search.Query\"><Query><SupportedFormats><Format>urn:Microsoft.Search.Response.Document:Document</Format></SupportedFormats><Context><QueryText type=\"STRING\" language=\"en-us\">test</QueryText></Context><Range><StartAt>1</StartAt><Count>10</Count></Range><Properties>");

            foreach (string property in metadata)
                sb.Append(String.Format("<Property name=\"{0}\"/>", property));

            sb.Append(String.Format("</Properties><EnableStemming>{0}</EnableStemming><TrimDuplicates>{1}</TrimDuplicates><IgnoreAllNoiseQuery>{2}</IgnoreAllNoiseQuery><ImplicitAndBehavior>{3}</ImplicitAndBehavior><IncludeRelevanceResults>{4}</IncludeRelevanceResults><IncludeSpecialTermResults>{5}</IncludeSpecialTermResults><IncludeHighConfidenceResults>{6}</IncludeHighConfidenceResults></Query></QueryPacket>", enableStemming.ToString(), trimDuplicates.ToString(), ignoreAllNoiseQuery.ToString(), implicitAndBehavior.ToString(), includeRelevanceResults.ToString(), includeSpecialTermResults.ToString(), includeHighConfidenceResults.ToString()));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(query.Query(sb.ToString()));

            XmlNodeList list = RunXPathQuery(doc, "//d:Properties");

            List<Dictionary<string, string>> items = new List<Dictionary<string, string>>();

            foreach (XmlNode node in list)
            {
                Dictionary<string, string> newItem = new Dictionary<string, string>();

                foreach (XmlNode attrib in node.ChildNodes)
                    newItem.Add(attrib.ChildNodes[0].InnerText, attrib.ChildNodes[2].InnerText);

                items.Add(newItem);
            }

            return items;
        }

        /// <summary>
        /// Returns all metadata available from SharePoint.
        /// </summary>
        /// <returns>List with metadata.</returns>
        public List<string> GetSearchMetadata()
        {
            QueryService query = new QueryService();
            query.Credentials = Credentials;
            query.Url = Url.ToString().Replace("lists.asmx", "search.asmx");
            query.Proxy = GetProxy();

            ServicePointManager.ServerCertificateValidationCallback += ((sender, certificate, chain, sslPolicyErrors) => true);

            DataSet ds = query.GetSearchMetadata();

            List<string> metadata = new List<string>();

            foreach (DataRow row in ds.Tables[0].Rows)
                metadata.Add(row[0].ToString());

            return metadata;
        }

        /// <summary>
        /// Returns a value from the XmlNode received from SharePoint.
        /// </summary>
        /// <param name="node">XmlNode from SharePoint.</param>
        /// <param name="value">Value to get.</param>
        /// <returns>String with value.</returns>
        private string GetSearchValue(XmlNode node, string value)
        {
            foreach (XmlNode n in node["Properties"].ChildNodes)
                if (n["Name"].InnerText.Equals(value)) return GetNode(n["Value"]);

            return string.Empty;
        }

        #endregion

        #region "Lists"

        /// <summary>
        /// Get a collection with all items for the specified list.
        /// </summary>
        /// <param name="listname">ID of the list.</param>
        /// <param name="filter">Field to filter by, and value to search for.</param>
        /// <returns>Collection with items.</returns>
        public SPListItem[] GetListItems(string listname, Dictionary<string, string> filter)
        {
            List<SPListItem> items = new List<SPListItem>();

            Lists lists = new Lists();
            lists.Credentials = Credentials;
            lists.Url = Url.ToString();
            lists.Proxy = GetProxy();

            ServicePointManager.ServerCertificateValidationCallback += ((sender, certificate, chain, sslPolicyErrors) => true);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(lists.GetListItems(listname, null, null, null, null, null, null).OuterXml);

            foreach (XmlNode node in RunXPathQuery(doc, "//z:row"))
                if (!String.IsNullOrEmpty(Path.GetExtension(new Uri(String.Format("{0}/{1}", Url.ToString().Replace(Url.PathAndQuery, String.Empty), GetNodeAttribute(node.Attributes["ows_FileRef"]))).Segments[(new Uri(String.Format("{0}/{1}", Url.ToString().Replace(Url.PathAndQuery, String.Empty), GetNodeAttribute(node.Attributes["ows_FileRef"]))).Segments.Length - 1)])))
                    if (filter.Count == 0 || Utils.IsTypeOfFilter(node, filter))
                        items.Add(new SPListItem(GetNodeAttribute(node.Attributes["ows_UniqueId"]),
                            Path.GetFileNameWithoutExtension(GetNodeAttribute((node.Attributes["ows_Title"] ?? node.Attributes["ows_LinkFilename"]))), //ows_LinkFileName
                            new Uri(String.Format("{0}/{1}", Url.ToString().Replace(Url.PathAndQuery, String.Empty), GetNodeAttribute(node.Attributes["ows_FileRef"]))),
                            GetNodeAttribute(node.Attributes["ows_Editor"]),
                            GetDateTime(GetNodeAttribute(node.Attributes["ows_Created_x0020_Date"])),
                            GetNodeAttribute(node.Attributes["ows_CheckoutUser"]),
                            GetDateTime(GetNodeAttribute(node.Attributes["ows_Last_x0020_Modified"])),
                            GetNodeAttribute(node.Attributes["ows_DocIcon"]),
                            GetNodeAttribute(node.Attributes["contenttypeid"]),
                            node));

            return items.ToArray();
        }

        /// <summary>
        /// Get a collection with lists from the SharePoint Web Service.
        /// </summary>
        /// <returns>Collection with lists.</returns>
        public SPList[] GetLists()
        {
            List<SPList> items = new List<SPList>();
            Lists lists = new Lists();
            lists.Credentials = Credentials;
            lists.Url = Url.ToString();
            lists.Proxy = GetProxy();
            lists.UserAgent = "Mozilla/5.0 (Windows; U; MSIE 7.0; Windows NT 6.0; en-US)";

            //TrustAllCertificatePolicy cert = new TrustAllCertificatePolicy();
            ServicePointManager.ServerCertificateValidationCallback += ((sender, certificate, chain, sslPolicyErrors) => true);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(lists.GetListCollection().OuterXml);

            foreach (XmlNode node in RunXPathQuery(doc, "//sp:List"))
                items.Add(new SPList(GetNodeAttribute(node.Attributes["Title"]), GetNodeAttribute(node.Attributes["ID"]), new Uri((GetNodeAttribute(node.Attributes["DefaultViewUrl"]) == String.Empty ? "http://moss/" : String.Format("{0}{1}", Url.ToString().Replace(Url.PathAndQuery, String.Empty), GetNodeAttribute(node.Attributes["DefaultViewUrl"])))), node));

            return items.ToArray();
        }

        /// <summary>
        /// Returns a single list
        /// </summary>
        /// <param name="listid"></param>
        /// <returns></returns>
        public SPSingleList GetList(string listid)
        {
            Lists lists = new Lists();
            lists.Credentials = Credentials;
            lists.Url = Url.ToString();
            lists.Proxy = GetProxy();

            ServicePointManager.ServerCertificateValidationCallback += ((sender, certificate, chain, sslPolicyErrors) => true);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(lists.GetList(listid).OuterXml);

            XmlNodeList listscoll = RunXPathQuery(doc, "//sp:List");

            if (listscoll.Count < 1) return null;

            XmlNode node = RunXPathQuery(doc, "//sp:List")[0];

            return new SPSingleList(GetNodeAttribute(node.Attributes["ID"]),
                GetNodeAttribute(node.Attributes["Title"]),
                GetNodeAttribute(node.Attributes["Description"]),
                Convert.ToInt32(String.IsNullOrEmpty(GetNodeAttribute(node.Attributes["ItemCount"])) ? "0" : GetNodeAttribute(node.Attributes["ItemCount"])));
        }

        #endregion

        #region "Views"

        /// <summary>
        /// Returns a collection with views for the specified list.
        /// </summary>
        /// <returns>Collection with views.</returns>
        public SPView[] GetViews(string listname)
        {
            List<SPView> items = new List<SPView>();
            Views views = new Views();
            views.Credentials = Credentials;
            views.Url = Url.ToString().Replace("lists.asmx", "views.asmx");
            views.Proxy = GetProxy();

            //string temp = views.GetView(listname, "Alla dokument").OuterXml;
            string temp2 = views.GetView(listname, "E54A6CF2-D7D2-4172-91A8-FFEBD8AC40D7").OuterXml;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(views.GetViewCollection(listname).OuterXml);

            foreach (XmlNode node in RunXPathQuery(doc, "//sp:View"))
                items.Add(new SPView(GetNodeAttribute(node.Attributes["DisplayName"]), GetNodeAttribute(node.Attributes["Name"]), node));

            return items.ToArray();
        }

        /// <summary>
        /// Returns a specified view for the list.
        /// </summary>
        /// <param name="listname">Name of the list.</param>
        /// <param name="viewid">ID of the view.</param>
        /// <returns>Properties for the view.</returns>
        public List<string> GetView(string listname, string viewid)
        {
            List<string> items = new List<string>();
            Views views = new Views();
            views.Credentials = Credentials;
            views.Url = Url.ToString().Replace("lists.asmx", "views.asmx");
            views.Proxy = GetProxy();

            ServicePointManager.ServerCertificateValidationCallback += ((sender, certificate, chain, sslPolicyErrors) => true);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(views.GetView(listname, viewid).OuterXml);

            foreach (XmlNode node in RunXPathQuery(doc, "//sp:FieldRef"))
                items.Add(GetNodeAttribute(node.Attributes["Name"]));

            return items;
        }

        #endregion

        #region "Webs"

        /// <summary>
        /// Returns a collection with webs from SharePoint. A web can contain other webs. To get all subwebs from a specified web, set the url in the Url property.
        /// </summary>
        /// <returns>Collection with webs.</returns>
        public SPWeb[] GetWebs()
        {
            Webs webs = new Webs();
            webs.Credentials = Credentials;
            webs.PreAuthenticate = true;
            webs.Url = Url.ToString().Replace("lists.asmx", "webs.asmx");
            webs.Proxy = GetProxy();

            ServicePointManager.ServerCertificateValidationCallback += ((sender, certificate, chain, sslPolicyErrors) => true);

            XmlNode webscollection = null;
            webscollection = webs.GetWebCollection();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(webscollection.OuterXml);

            List<SPWeb> list = new List<SPWeb>();

            foreach (XmlNode web in RunXPathQuery(doc, "//sp:Web"))
                list.Add(new SPWeb(GetNodeAttribute(web.Attributes["Title"]), GetNodeAttribute(web.Attributes["Url"]), web));

            return list.ToArray();
        }

        #endregion

        #region "Upload Items"
        /// <summary>
        /// Experimental, should not be used as it is now.
        /// </summary>
        /// <param name="listUrl">URL to the list.</param>
        /// <param name="sourceFileStream">The file to be uploaded.</param>
        /// <param name="fileName">Filename.</param>
        /// <param name="fields">Fields with information about the file.</param>
        /// <returns>The id for the uploaded document.</returns>
        public int UploadItem(string listUrl, Stream sourceFileStream, string fileName, FieldInformation[] fields)
        {
            Copy copy = new Copy();
            copy.Credentials = Credentials;
            copy.Url = Url.ToString().Replace("lists.asmx", "copy.asmx");
            copy.Proxy = GetProxy();

            ServicePointManager.ServerCertificateValidationCallback += ((sender, certificate, chain, sslPolicyErrors) => true);
            
            byte[] fileBytes = new byte[sourceFileStream.Length];
            sourceFileStream.Read(fileBytes, 0, (int)sourceFileStream.Length);
            string[] destinationUri = { string.Format("{0}/{1}", listUrl, fileName) };

            CopyResult[] result;
            int documentId = Convert.ToInt32(copy.CopyIntoItems("", destinationUri, fields, fileBytes, out result));

            return documentId;
        }

        #endregion

        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor
        /// </summary>
        [Obsolete("Don´t use.", true)]
        public WebServices()
        {
            //Not used.
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="credentials">Credentials for authentication.</param>
        /// <param name="url">Url to web service.</param>
        public WebServices(ICredentials credentials, Uri url)
        {
            _credentials = credentials;
            _url = url;
        }

        #endregion

        private WebProxy GetProxy()
        {
            WebProxy proxy = new WebProxy();

            return proxy;
        }
    }
}