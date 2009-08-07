using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace SharePoint
{
    /// <summary>
    /// Accept certificates-
    /// </summary>
    public class TrustAllCertificatePolicy : ICertificatePolicy
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public TrustAllCertificatePolicy()
        {
            
        }

        /// <summary>
        /// Fake the certificate lookup.
        /// </summary>
        /// <param name="sp">ServicePoint</param>
        /// <param name="cert">Certificate</param>
        /// <param name="req">WebRequest.</param>
        /// <param name="problem">Problems</param>
        /// <returns>True</returns>
        public bool CheckValidationResult(ServicePoint sp, X509Certificate cert, WebRequest req, int problem)
        {
            return true;
        }
    }

}
