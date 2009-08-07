using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net;

namespace SharePoint
{
    public partial class SPLibrary
    {
        #region "Content Types"

        /// <summary>
        /// Get all enums in the specified category.
        /// </summary>
        /// <param name="category">Category to filter by.</param>
        /// <returns>Collection with categories.</returns>
        public string[] ContentTypeGroups(EnumGroupCategory category)
        {
            return Utils.ContentTypeGroup(category);
        }

        #endregion
    }
}
