using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Xml;

namespace SharePoint
{
    public partial class SPLibrary
    {
        #region "Search"

        /// <summary>
        /// Search in SharePoint for the specified keyword.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <returns>Collection with list items based on the keyword.</returns>
        public SPSearchResult[] Search(string keyword)
        {
            WebServices ws = new WebServices(Credentials, Url);
            return ws.Search(keyword);
        }

        /// <summary>
        /// Search in SharePoint for the specified keyword.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <param name="starturl">Url to start with.</param>
        /// <returns>Collection with list items based on the keyword.</returns>
        public SPSearchResult[] Search(string keyword, Uri[] starturl)
        {
            return Search(keyword, starturl, null);
        }


        /// <summary>
        /// Search in SharePoint for the specified keyword.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <param name="starturl">Url to start with.</param>
        /// <param name="excludeurl">Urls to exclude.</param>
        /// <returns>Collection with list items based on the keyword.</returns>
        public SPSearchResult[] Search(string keyword, Uri[] starturl, Uri[] excludeurl)
        {
            WebServices ws = new WebServices(Credentials, Url);
            List<SPSearchResult> newresults = new List<SPSearchResult>();

            foreach (SPSearchResult result in ws.Search(keyword))
            {
                foreach (Uri uri in starturl)
                {
                    if (result.Url.StartsWith(uri.ToString()))
                    {
                        if (excludeurl != null)
                        {
                            bool foundInExclude = false;
                            foreach (Uri excludeUri in excludeurl)
                            {
                                if (result.Url.StartsWith(excludeUri.ToString()))
                                {
                                    foundInExclude = true;
                                    break;
                                }
                            }
                            if (!foundInExclude)
                            {
                                newresults.Add(result);
                            }
                        }
                        else
                        {
                            newresults.Add(result);
                        }
                    }
                }
            }

            return newresults.ToArray();
        }

        /// <summary>
        /// Search for documents i SharePoint.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <returns>Documents found.</returns>
        public SPSearchResult[] SearchDocuments(string keyword)
        {
            WebServices ws = new WebServices(Credentials, Url);

            List<SPSearchResult> list = new List<SPSearchResult>();

            foreach (SPSearchResult result in ws.Search(keyword))
                if (result.FileSize > 0 &&
                    !String.IsNullOrEmpty(result.FileExtension) &&
                    result.Date != DateTime.MinValue &&
                    !result.FileExtension.StartsWith("htm") &&
                    !result.FileExtension.StartsWith("asp"))
                    list.Add(result);

            return list.ToArray();
        }

        /// <summary>
        /// Search for documents i SharePoint.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <param name="starturl">Url to start with.</param>
        /// <returns>Documents found.</returns>
        public SPSearchResult[] SearchDocuments(string keyword, Uri[] starturl)
        {
            WebServices ws = new WebServices(Credentials, Url);

            List<SPSearchResult> list = new List<SPSearchResult>();

            foreach (SPSearchResult result in ws.Search(keyword))
                foreach (Uri uri in starturl)
                    if (result.FileSize > 0 &&
                        !String.IsNullOrEmpty(result.FileExtension) &&
                        result.Date != DateTime.MinValue &&
                        !result.FileExtension.StartsWith("htm") &&
                        !result.FileExtension.StartsWith("asp") &&
                        result.Url.ToLower().StartsWith(uri.ToString().ToLower()))
                        list.Add(result);

            return list.ToArray();
        }

        /// <summary>
        /// Search for items in SharePoint.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <param name="metadata">Fields to get in search result.</param>
        /// <returns>Items from SharePoint based on search phrase.</returns>
        public List<Dictionary<string, string>> Search(string keyword, params string[] metadata)
        {
            WebServices ws = new WebServices(Credentials, Url);
            return ws.Search(keyword, metadata);
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
            WebServices ws = new WebServices(Credentials, Url);
            return ws.Search(keyword, enableStemming, trimDuplicates, ignoreAllNoiseQuery, implicitAndBehavior, includeRelevanceResults, includeSpecialTermResults, includeHighConfidenceResults, metadata);
        }

        /// <summary>
        /// Search for items in SharePoint.
        /// </summary>
        /// <param name="keyword">Keyword to search for.</param>
        /// <param name="searchfields">Fields to get in search result.</param>
        /// <returns>Items found.</returns>
        public List<Dictionary<string, string>> Search(string keyword, SearchField searchfields)
        {
            if (String.IsNullOrEmpty(keyword))
                throw new ArgumentNullException(keyword);

            WebServices ws = new WebServices(Credentials, Url);
            return ws.Search(keyword, searchfields);
        }

        /// <summary>
        /// Get metadata fields that can be used with the advanced search.
        /// </summary>
        /// <returns>List with metadata fields.</returns>
        public List<string> GetSearchMetadata()
        {
            WebServices ws = new WebServices(Credentials, Url);
            return ws.GetSearchMetadata();
        }

        #endregion
    }
}
