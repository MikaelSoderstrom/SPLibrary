using System;
using System.Collections.Generic;
using System.Text;

namespace SharePoint
{
    /// <summary>
    /// Fields to use with search.
    /// </summary>
    [Flags()]
    public enum SearchField : long
    {
        /// <summary>
        /// AboutMe
        /// </summary>
        AboutMe = 1,

        /// <summary>
        /// Account
        /// </summary>
        Account = 2,

        /// <summary>
        /// AccountName
        /// </summary>
        AccountName = 4,

        /// <summary>
        /// AssignedTo
        /// </summary>
        AssignedTo = 8,

        /// <summary>
        /// Assistant
        /// </summary>
        Assistant = 16,

        /// <summary>
        /// Author
        /// </summary>
        Author = 32,

        /// <summary>
        /// Authority
        /// </summary>
        Authority = 64,

        /// <summary>
        /// BestBetKeywords
        /// </summary>
        BestBetKeywords = 128,

        /// <summary>
        /// Birthday
        /// </summary>
        Birthday = 256,

        /// <summary>
        /// CachedPath
        /// </summary>
        CachedPath = 512,

        /// <summary>
        /// CategoryNavigationUrl
        /// </summary>
        CategoryNavigationUrl = 1024,

        /// <summary>
        /// CollapsingStatus
        /// </summary>
        CollapsingStatus = 2048,

        /// <summary>
        /// Company
        /// </summary>
        Company = 4096,

        /// <summary>
        /// contentclass
        /// </summary>
        contentclass = 8192,

        /// <summary>
        /// ContentSource
        /// </summary>
        ContentSource = 16384,

        /// <summary>
        /// ContentType
        /// </summary>
        ContentType = 32768,

        /// <summary>
        /// Created
        /// </summary>
        Created = 65536,

        /// <summary>
        /// CreatedBy
        /// </summary>
        CreatedBy = 131072,

        /// <summary>
        /// DataSource
        /// </summary>
        DataSource = 262144,

        /// <summary>
        /// DatePictureTaken
        /// </summary>
        DatePictureTaken = 524288,

        /// <summary>
        /// Department
        /// </summary>
        Department = 1048576,

        /// <summary>
        /// Description
        /// </summary>
        Description = 2097152,

        /// <summary>
        /// DisplayTitle
        /// </summary>
        DisplayTitle = 4194304,

        /// <summary>
        /// DocComments
        /// </summary>
        DocComments = 8388608,

        /// <summary>
        /// DocKeywords
        /// </summary>
        DocKeywords = 16777216,

        /// <summary>
        /// DocSignature
        /// </summary>
        DocSignature = 33554432,

        /// <summary>
        /// DocSubject
        /// </summary>
        DocSubject = 67108864,

        /// <summary>
        /// DottedLine
        /// </summary>
        DottedLine = 134217728,

        /// <summary>
        /// EMail
        /// </summary>
        EMail = 268435456,

        /// <summary>
        /// EndDate
        /// </summary>
        EndDate = 536870912,

        /// <summary>
        /// Fax
        /// </summary>
        Fax = 1073741824,

        /// <summary>
        /// FileExtension
        /// </summary>
        FileExtension = 2147483648,

        /// <summary>
        /// Filename
        /// </summary>
        Filename = 4294967296,

        /// <summary>
        /// FirstName
        /// </summary>
        FirstName = 8589934592,

        /// <summary>
        /// FollowAllAnchor
        /// </summary>
        FollowAllAnchor = 17179869184,

        /// <summary>
        /// HighConfidenceDisplayProperty1
        /// </summary>
        HighConfidenceDisplayProperty1 = 34359738368,

        /// <summary>
        /// HighConfidenceDisplayProperty10
        /// </summary>
        HighConfidenceDisplayProperty10 = 68719476736,

        /// <summary>
        /// HighConfidenceDisplayProperty11
        /// </summary>
        HighConfidenceDisplayProperty11 = 137438953472,

        /// <summary>
        /// HighConfidenceDisplayProperty12
        /// </summary>
        HighConfidenceDisplayProperty12 = 274877906944,

        /// <summary>
        /// HighConfidenceDisplayProperty13
        /// </summary>
        HighConfidenceDisplayProperty13 = 549755813888,

        /// <summary>
        /// HighConfidenceDisplayProperty14
        /// </summary>
        HighConfidenceDisplayProperty14 = 1099511627776,

        /// <summary>
        /// HighConfidenceDisplayProperty15
        /// </summary>
        HighConfidenceDisplayProperty15 = 2199023255552,

        /// <summary>
        /// HighConfidenceDisplayProperty2
        /// </summary>
        HighConfidenceDisplayProperty2 = 4398046511104,

        /// <summary>
        /// HighConfidenceDisplayProperty3
        /// </summary>
        HighConfidenceDisplayProperty3 = 8796093022208,

        /// <summary>
        /// HighConfidenceDisplayProperty4
        /// </summary>
        HighConfidenceDisplayProperty4 = 17592186044416,

        /// <summary>
        /// HighConfidenceDisplayProperty5
        /// </summary>
        HighConfidenceDisplayProperty5 = 35184372088832,

        /// <summary>
        /// HighConfidenceDisplayProperty6
        /// </summary>
        HighConfidenceDisplayProperty6 = 70368744177664,

        /// <summary>
        /// HighConfidenceDisplayProperty7
        /// </summary>
        HighConfidenceDisplayProperty7 = 140737488355328,

        /// <summary>
        /// HighConfidenceDisplayProperty8
        /// </summary>
        HighConfidenceDisplayProperty8 = 281474976710656,

        /// <summary>
        /// HighConfidenceDisplayProperty9
        /// </summary>
        HighConfidenceDisplayProperty9 = 562949953421312,

        /// <summary>
        /// HighConfidenceImageURL
        /// </summary>
        HighConfidenceImageURL = 1125899906842624,

        /// <summary>
        /// HighConfidenceMatching
        /// </summary>
        HighConfidenceMatching = 2251799813685248,

        /// <summary>
        /// HighConfidenceResultType
        /// </summary>
        HighConfidenceResultType = 4503599627370496,

        /// <summary>
        /// HireDate
        /// </summary>
        HireDate = 9007199254740992,

        /// <summary>
        /// HitHighlightedProperties
        /// </summary>
        HitHighlightedProperties = 18014398509481984,

        /// <summary>
        /// HitHighlightedSummary
        /// </summary>
        HitHighlightedSummary = 36028797018963968,

        /// <summary>
        /// HomePhone
        /// </summary>
        HomePhone = 72057594037927936,

        /// <summary>
        /// Interests
        /// </summary>
        Interests = 144115188075855872,

        /// <summary>
        /// IsDocument
        /// </summary>
        IsDocument = 288230376151711744,

        /// <summary>
        /// JobTitle
        /// </summary>
        JobTitle = 576460752303423488,

        /// <summary>
        /// Keywords
        /// </summary>
        Keywords = 1152921504606846976,

        /// <summary>
        /// LastModifiedTime
        /// </summary>
        LastModifiedTime = 2305843009213693952,

        /// <summary>
        /// LastName
        /// </summary>
        LastName = 4611686018427387904,

        /// <summary>
        /// Location
        /// </summary>
        Location = -9223372036854775808,

        /// <summary>
        /// Manager
        /// </summary>
        Manager = 0,

        /// <summary>
        /// MemberOf
        /// </summary>
        MemberOf = 1,

        /// <summary>
        /// Memberships
        /// </summary>
        Memberships = 2,

        /// <summary>
        /// MobilePhone
        /// </summary>
        MobilePhone = 4,

        /// <summary>
        /// ModifiedBy
        /// </summary>
        ModifiedBy = 8,

        /// <summary>
        /// MySiteWizard
        /// </summary>
        MySiteWizard = 16,

        /// <summary>
        /// NLCodePage
        /// </summary>
        NLCodePage = 32,

        /// <summary>
        /// Notes
        /// </summary>
        Notes = 64,

        /// <summary>
        /// objectid
        /// </summary>
        objectid = 128,

        /// <summary>
        /// OfficeNumber
        /// </summary>
        OfficeNumber = 256,

        /// <summary>
        /// OWS_URL
        /// </summary>
        OWS_URL = 512,

        /// <summary>
        /// PastProjects
        /// </summary>
        PastProjects = 1024,

        /// <summary>
        /// Path
        /// </summary>
        Path = 2048,

        /// <summary>
        /// Peers
        /// </summary>
        Peers = 4096,

        /// <summary>
        /// PersonalSpace
        /// </summary>
        PersonalSpace = 8192,

        /// <summary>
        /// PictureHeight
        /// </summary>
        PictureHeight = 16384,

        /// <summary>
        /// PictureSize
        /// </summary>
        PictureSize = 32768,

        /// <summary>
        /// PictureThumbnailURL
        /// </summary>
        PictureThumbnailURL = 65536,

        /// <summary>
        /// PictureURL
        /// </summary>
        PictureURL = 131072,

        /// <summary>
        /// PictureWidth
        /// </summary>
        PictureWidth = 262144,

        /// <summary>
        /// PreferredName
        /// </summary>
        PreferredName = 524288,

        /// <summary>
        /// Priority
        /// </summary>
        Priority = 1048576,

        /// <summary>
        /// ProxyAddresses
        /// </summary>
        ProxyAddresses = 2097152,

        /// <summary>
        /// PublicSiteRedirect
        /// </summary>
        PublicSiteRedirect = 4194304,

        /// <summary>
        /// Purpose
        /// </summary>
        Purpose = 8388608,

        /// <summary>
        /// Rank
        /// </summary>
        Rank = 16777216,

        /// <summary>
        /// Responsibilities
        /// </summary>
        Responsibilities = 33554432,

        /// <summary>
        /// Schools
        /// </summary>
        Schools = 67108864,

        /// <summary>
        /// SID
        /// </summary>
        SID = 134217728,

        /// <summary>
        /// SipAddress
        /// </summary>
        SipAddress = 268435456,

        /// <summary>
        /// Site
        /// </summary>
        Site = 536870912,

        /// <summary>
        /// SiteName
        /// </summary>
        SiteName = 1073741824,

        /// <summary>
        /// SiteTitle
        /// </summary>
        SiteTitle = 2147483648,

        /// <summary>
        /// Size
        /// </summary>
        Size = 4294967296,

        /// <summary>
        /// Skills
        /// </summary>
        Skills = 8589934592,

        /// <summary>
        /// StartDate
        /// </summary>
        StartDate = 17179869184,

        /// <summary>
        /// Status
        /// </summary>
        Status = 34359738368,

        /// <summary>
        /// Title
        /// </summary>
        Title = 68719476736,

        /// <summary>
        /// UrlDepth
        /// </summary>
        UrlDepth = 137438953472,

        /// <summary>
        /// UserName
        /// </summary>
        UserName = 274877906944,

        /// <summary>
        /// UserProfile_GUID
        /// </summary>
        UserProfile_GUID = 549755813888,

        /// <summary>
        /// WebId
        /// </summary>
        WebId = 1099511627776,

        /// <summary>
        /// WebSite
        /// </summary>
        WebSite = 2199023255552,

        /// <summary>
        /// WorkAddress
        /// </summary>
        WorkAddress = 4398046511104,

        /// <summary>
        /// WorkCity
        /// </summary>
        WorkCity = 8796093022208,

        /// <summary>
        /// WorkCountry
        /// </summary>
        WorkCountry = 17592186044416,

        /// <summary>
        /// WorkEmail
        /// </summary>
        WorkEmail = 35184372088832,

        /// <summary>
        /// WorkId
        /// </summary>
        WorkId = 70368744177664,

        /// <summary>
        /// WorkPhone
        /// </summary>
        WorkPhone = 140737488355328,

        /// <summary>
        /// WorkState
        /// </summary>
        WorkState = 281474976710656,

        /// <summary>
        /// WorkZip
        /// </summary>
        WorkZip = 562949953421312
    }
}