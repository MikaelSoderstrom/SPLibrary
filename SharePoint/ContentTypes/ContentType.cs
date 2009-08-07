using System;
using System.Collections.Generic;
using System.Text;

namespace SharePoint
{
    /// <summary>
    /// Content Types to use with filtering.
    /// </summary>
    public enum ContentType
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.None)]
        None = 0,

        /// <summary>
        /// System
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Hidden)]
        System = 0x02,

        /// <summary>
        /// Item
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        Item = 0x01,

        /// <summary>
        /// Document
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        Document = 0x0101,

        /// <summary>
        /// XMLDocument
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        XmlDocument = 0x010101,

        /// <summary>
        /// Picture
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        Picture = 0x010102,

        /// <summary>
        /// UntypedDocument
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        UntypedDocument = 0x010104,

        /// <summary>
        /// MasterPage
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        MasterPage = 0x010105,

        /// <summary>
        /// WikiDocument
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        WikiDocument = 0x010108,

        /// <summary>
        /// BasicPage
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        BasicPage = 0x010109,

        /// <summary>
        /// WebPartPage
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        WebPartPage = 0x01010901,

        /// <summary>
        /// LinkToDocument
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        LinkToDocument = 0x01010A,

        /// <summary>
        /// DublinCoreName
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Document)]
        DublinCoreName = 0x01010B,

        /// <summary>
        /// Event
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.List)]
        Event = 0x0102,

        /// <summary>
        /// Issue
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.List)]
        Issue = 0x0103,

        /// <summary>
        /// Announcement
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.List)]
        Announcement = 0x0104,

        /// <summary>
        /// Link
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.List)]
        Link = 0x0105,

        /// <summary>
        /// Contact
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.List)]
        Contact = 0x0106,

        /// <summary>
        /// Message
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.List)]
        Message = 0x0107,

        /// <summary>
        /// Task
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.List)]
        Task = 0x0108,

        /// <summary>
        /// WorkflowTask
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Hidden)]
        WorkflowTask = 0x010801,

        /// <summary>
        /// AdminTask
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Hidden)]
        AdminTask = 0x010802,

        /// <summary>
        /// WorkflowHistory
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Hidden)]
        WorkflowHistory = 0x0109,

        /// <summary>
        /// BlogPost
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Hidden)]
        BlogPost = 0x0110,

        /// <summary>
        /// BlogComment
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Hidden)]
        BlogComment = 0x0111,

        /// <summary>
        /// FarEastContact
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.List)]
        FarEastContact = 0x0116,

        /// <summary>
        /// Folder
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Folder)]
        Folder = 0x0120,

        /// <summary>
        /// RootOfList
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Folder)]
        RootOfList = 0x012001,

        /// <summary>
        /// Discussion
        /// </summary>
        [EnumGroupAttribute(Category = EnumGroupCategory.Folder)]
        Discussion = 0x012002
    }
}