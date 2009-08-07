using System;
using System.Collections.Generic;
using System.Text;

namespace SharePoint
{
    /// <summary>
    /// Sort by enum
    /// </summary>
    public enum SPListSortBy
    {
        /// <summary>
        /// By modified
        /// </summary>
        Modified = 0,
        /// <summary>
        /// By created
        /// </summary>
        Created = 1,
        /// <summary>
        /// 
        /// </summary>
        DocumentCategory = 2,
        /// <summary>
        /// 
        /// </summary>
        FileType = 3,
    }

    /// <summary>
    /// Direction enum
    /// </summary>
    public enum SPListSortDirection
    {
        /// <summary>
        /// Asc
        /// </summary>
        Ascending = 0,
        /// <summary>
        /// Desc
        /// </summary>
        Descending = 1
    }

    /// <summary>
    /// Comparer for SPListItem
    /// </summary>
    public class SPListItemComparer : IComparer<SPListItem>
    {
        private SPListSortBy sortBy;
        private SPListSortDirection sortDirection;
        private string categoryMetaDataFieldName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPListItemComparer"/> class.
        /// </summary>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="direction">The direction.</param>
        public SPListItemComparer(SPListSortBy sortBy, SPListSortDirection direction)
        {
            this.sortBy = sortBy;
            this.sortDirection = direction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SPListItemComparer"/> class.
        /// </summary>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="categoryMetaDataFieldName">Name of the category meta data field.</param>
        public SPListItemComparer(SPListSortBy sortBy, SPListSortDirection direction, string categoryMetaDataFieldName)
        {
            this.sortBy = sortBy;
            this.sortDirection = direction;
            this.categoryMetaDataFieldName = categoryMetaDataFieldName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SPListItemComparer"/> class.
        /// </summary>
        public SPListItemComparer()
        {
            this.sortBy = SPListSortBy.Modified;
            this.sortDirection = SPListSortDirection.Descending;
        }

        #region IComparer<SPListItem> Members

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// Value Condition Less than zero<paramref name="x"/> is less than <paramref name="y"/>.Zero<paramref name="x"/> equals <paramref name="y"/>.Greater than zero<paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        public int Compare(SPListItem x, SPListItem y)
        {
            if (this.sortBy == SPListSortBy.Modified) {
                if (this.sortDirection == SPListSortDirection.Descending) {
                    return y.Modified.CompareTo(x.Modified);
                }
                return x.Modified.CompareTo(y.Modified);
            }
            else if (this.sortBy == SPListSortBy.Created) {
                if (this.sortDirection == SPListSortDirection.Descending){
                    return y.Created.CompareTo(x.Created);
                }
                return x.Created.CompareTo(y.Created);
            }
            else if (this.sortBy == SPListSortBy.DocumentCategory)
            {
                string xCategory, yCategory = string.Empty;
           
                x.MetaData.TryGetValue(categoryMetaDataFieldName, out xCategory);
                y.MetaData.TryGetValue(categoryMetaDataFieldName, out yCategory);
                if (this.sortDirection == SPListSortDirection.Descending)
                {
                    return yCategory.CompareTo(xCategory);
                }
                return xCategory.CompareTo(yCategory);
            }
            else
            {
                if (this.sortDirection == SPListSortDirection.Descending)
                {
                    y.ItemType.CompareTo(x.ItemType);
                }
                return x.ItemType.CompareTo(y.ItemType);
            }
        }

        #endregion
    }
}
