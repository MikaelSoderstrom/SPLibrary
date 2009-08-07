using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/*
 WARNING: JUST EXPERIMENTAL!!!
 */

namespace SharePoint
{
    public partial class SPLibrary
    {
        #region "List items"

        /// <summary>
        /// Upload a file to a SharePoint library.
        /// </summary>
        /// <param name="listUrl">URL to the list.</param>
        /// <param name="sourceFileStream">A Stream with the file.</param>
        /// <param name="fileName">Filename.</param>
        /// <param name="fields">Fields with meta data.</param>
        /// <returns></returns>
        public int UploadItem(string listUrl, Stream sourceFileStream, string fileName, WSCopy.FieldInformation[] fields)
        {
            WebServices ws = new WebServices(Credentials, Url);
            return ws.UploadItem(listUrl, sourceFileStream, fileName, fields);
        }

        #endregion
    }
}
