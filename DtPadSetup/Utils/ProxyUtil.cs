using System;
using System.Net;
using System.Net.Cache;

namespace DtPadSetup.Utils
{
    /// <summary>
    /// Proxy initialization util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ProxyUtil
    {
        #region Internal Methods

        internal static WebRequest InitWebRequestProxy(WebRequest webRequest, bool enable, String username, String password, String domain)
        {
            webRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

            if (!enable)
            {
                return webRequest;
            }

            if (!String.IsNullOrEmpty(domain))
            {
                webRequest.Proxy.Credentials = new NetworkCredential(username, password, domain);
            }
            else
            {
                webRequest.Proxy.Credentials = new NetworkCredential(username, password);
            }

            return webRequest;
        }

        #endregion Internal Methods
    }
}
