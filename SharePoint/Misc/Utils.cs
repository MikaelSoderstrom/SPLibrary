using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;

namespace SharePoint
{
    /// <summary>
    /// Internal utilities for SharePoint.
    /// </summary>
    internal class Utils
    {
        /// <summary>
        /// Checks if the content type id is equal to the content type choosen.
        /// </summary>
        /// <param name="contenttypeid">A Content Type id to check.</param>
        /// <param name="type">Chosen Content Type.</param>
        /// <returns>True if they equals.</returns>
        public static bool IsType(string contenttypeid, ContentType type)
        {
            return contenttypeid.Equals(String.Format("0x0{0}", type.GetHashCode().ToString("x")));
        }

        /// <summary>
        /// Checks if the string equals to, or inherits from the chosen Content Type.
        /// </summary>
        /// <param name="contenttypeid">A Content Type id to check.</param>
        /// <param name="type">Chosen Content Type.</param>
        /// <returns>True if they equals or if it inherits from the content type.</returns>
        public static bool IsTypeOf(string contenttypeid, ContentType type)
        {
            return contenttypeid.StartsWith(String.Format("0x0{0}", type.GetHashCode().ToString("x")));
        }

        /// <summary>
        /// Get all enums in the specified category.
        /// </summary>
        /// <param name="category">Category to filter by.</param>
        /// <returns>Collection with categories.</returns>
        public static string[] ContentTypeGroup(EnumGroupCategory category)
        {
            Type t = typeof(ContentType);
            List<string> fields = new List<string>();

            foreach (FieldInfo field in t.GetFields())
                if (category == EnumGroupCategory.None || (field.GetCustomAttributes(true).Length > 0 && ((EnumGroupAttribute)field.GetCustomAttributes(true)[0]).Category.ToString().Equals(category.ToString())))
                    if (!field.Name.Equals("value__") &&
                        (field.GetCustomAttributes(true).Length > 0 && ((EnumGroupAttribute)field.GetCustomAttributes(true)[0]).Category != EnumGroupCategory.None))
                    fields.Add(field.Name);

            return fields.ToArray();
        }

        public static SPFieldLookup ParseSPField(string parse)
        {
            return new SPFieldLookup(parse);
        }

        public static bool IsTypeOfFilter(XmlNode node, Dictionary<string, string> filter)
        {
            foreach (KeyValuePair<string, string> item in filter)
            {
                if (node.Attributes[String.Format("ows_{0}", item.Key)] == null)
                    return false;

                if (!Utils.ParseSPField(node.Attributes[String.Format("ows_{0}", item.Key)].Value).LookupValue.Equals(item.Value))
                    return false;
            }
            

            return true;
        }

        public static bool IsInvalidDocument(string contenttype)
        {
            if (!contenttype.StartsWith(String.Format("0x0{0}", ContentType.Document.GetHashCode().ToString("X")))) return true;
            if (contenttype.StartsWith(String.Format("0x0{0}", ContentType.MasterPage.GetHashCode().ToString("X")))) return true;
            if (contenttype.StartsWith(String.Format("0x0{0}", ContentType.XmlDocument.GetHashCode().ToString("X")))) return true;
            if (contenttype.StartsWith(String.Format("0x0{0}", ContentType.WikiDocument.GetHashCode().ToString("X")))) return true;
            if (contenttype.StartsWith(String.Format("0x0{0}", ContentType.BasicPage.GetHashCode().ToString("X")))) return true;
            if (contenttype.StartsWith(String.Format("0x0{0}", ContentType.WebPartPage.GetHashCode().ToString("X")))) return true;
            if (contenttype.StartsWith(String.Format("0x0{0}", ContentType.LinkToDocument.GetHashCode().ToString("X")))) return true;
            if (contenttype.StartsWith(String.Format("0x0{0}", ContentType.DublinCoreName.GetHashCode().ToString("X")))) return true;

            return false;
        }
    }
}