using System;
using System.Collections.Generic;
using System.Text;

namespace SharePoint
{
    /// <summary>
    /// Used to group enums.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumGroupAttribute : Attribute
    {
        private EnumGroupCategory _category;

        /// <summary>
        /// Category to group by.
        /// </summary>
        public EnumGroupCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }
    }
}
