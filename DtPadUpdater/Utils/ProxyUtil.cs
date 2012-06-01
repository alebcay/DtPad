using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using DtPadUpdater.Objects;

namespace DtPadUpdater.Utils
{
    /// <summary>
    /// Proxy initialization util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ProxyUtil
    {
        #region Internal Methods

        internal static WebClient InitWebClientProxy(String executablePath, String culture)
        {
            bool enableProxy = ConfigUtil.GetBoolParameter("ProxyEnabled", "False", executablePath);

            WebClient webClient = new WebClient { CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore) };
            if (!enableProxy)
            {
                return webClient;
            }

            List<PasswordObject> passwordList = PasswordUtil.GetStringParameters(new[] { "ProxyUsername", "ProxyPassword", "ProxyDomain" }, culture);
            String proxyUsername = (passwordList[0]).value;
            String proxyPassword = CodingUtil.DecodeByte((passwordList[1]).value);
            String proxyDomain = (passwordList[2]).value;

            if (!String.IsNullOrEmpty(proxyDomain))
            {
                webClient.Proxy.Credentials = new NetworkCredential(proxyUsername, proxyPassword, proxyDomain);
            }
            else
            {
                webClient.Proxy.Credentials = new NetworkCredential(proxyUsername, proxyPassword);
            }

            return webClient;
        }

        //internal static WebClient InitWebClientProxy(WebClient webClient, bool enable, String username, String password, String domain)
        //{
        //    webClient.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

        //    if (!enable)
        //    {
        //        return webClient;
        //    }

        //    if (!String.IsNullOrEmpty(domain))
        //    {
        //        webClient.Proxy.Credentials = new NetworkCredential(username, password, domain);
        //    }
        //    else
        //    {
        //        webClient.Proxy.Credentials = new NetworkCredential(username, password);
        //    }

        //    return webClient;
        //}

        #endregion Internal Methods
    }
}
