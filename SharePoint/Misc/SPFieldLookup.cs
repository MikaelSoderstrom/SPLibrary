using System;
using System.Collections.Generic;
using System.Text;

namespace SharePoint
{
    /// <summary>
    /// Custom implementation of SPFieldLookup.
    /// </summary>
    public class SPFieldLookup
    {
        private int _lookupId = 0;
        private string _lookupValue = String.Empty;

        /// <summary>
        /// ID of the field.
        /// </summary>
        public int LookupId
        {
            get { return _lookupId; }
        }

        /// <summary>
        /// Value of the field.
        /// </summary>
        public string LookupValue
        {
            get { return _lookupValue; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">Value to lookup.</param>
        public SPFieldLookup(string value)
        {
            if (!value.Contains(";#"))
            {
                _lookupValue = value;
            }
            else
            {
                string[] values = value.Split(new string[] { ";#" }, 2, StringSplitOptions.RemoveEmptyEntries);

                Int32.TryParse(values[0], out _lookupId);
                _lookupValue = values[1];
            }
        }
    }
}
