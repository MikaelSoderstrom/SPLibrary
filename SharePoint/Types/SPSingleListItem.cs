using System;
using System.Collections.Generic;
using System.Text;

namespace SharePoint
{
    /// <summary>
    /// A single list in SharePoint.
    /// </summary>
    public class SPSingleList
    {
        private string _id;
        private string _title;
        private string _description;
        private int _itemCount;

        /// <summary>
        /// ID of the list.
        /// </summary>
        public string Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Name of the list.
        /// </summary>
        public string Title
        {
            get { return _title; }
        }

        /// <summary>
        /// Description for the list.
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        public int ItemCount
        {
            get { return _itemCount; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">ID of the list.</param>
        /// <param name="title">Title of the list.</param>
        /// <param name="description">Description for the list.</param>
        /// <param name="itemcount">Number of items in the list.</param>
        public SPSingleList(string id, string title, string description, int itemcount)
        {
            _id = id;
            _title = title;
            _description = description;
            _itemCount = itemcount;
        }
    }
}
