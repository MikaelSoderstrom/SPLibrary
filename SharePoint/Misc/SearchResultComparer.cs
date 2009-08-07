using System;
using System.Collections.Generic;
using System.Text;

namespace SharePoint
{
    /// <summary>
    /// Comparare for searchresults
    /// </summary>
    public class SearchResultComparer : IComparer<SPSearchResult>
    {
        #region IComparer<SPSearchResult> Members

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// Value Condition Less than zero<paramref name="x"/> is less than <paramref name="y"/>.Zero<paramref name="x"/> equals <paramref name="y"/>.Greater than zero<paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        public int Compare(SPSearchResult x, SPSearchResult y)
        {
            return y.Relevance.CompareTo(x.Relevance);
        }

        #endregion
    }
}
