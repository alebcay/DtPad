using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using DtPad.Objects;

namespace DtPad.Utils
{
    /// <summary>
    /// Proxy initialization util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ProxyUtil
    {
        #region Internal Methods

        internal static WebClient InitWebClientProxy()
        {
            bool enableProxy = ConfigUtil.GetBoolParameter("ProxyEnabled");

            List<PasswordObject> passwordList = PasswordUtil.GetStringParameters(new[] { "ProxyUsername", "ProxyPassword", "ProxyDomain" });
            String proxyUsername = (passwordList[0]).value;
            String proxyPassword = CodingUtil.DecodeByte((passwordList[1]).value);
            String proxyDomain = (passwordList[2]).value;

            WebClient webClient = new WebClient { CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore) };

            if (!enableProxy)
            {
                return webClient;
            }

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

        internal static WebRequest InitWebRequestProxy(WebRequest webRequest, bool enable, String username, String password, String domain)
        {
            webRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            webRequest.Timeout = 15;

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

        //internal static WebProxy InitWebProxy()
        //{
        //    String proxyUsername = PasswordUtil.GetStringParameter("ProxyUsername");
        //    String proxyPassword = CodingUtil.DecodeByte(PasswordUtil.GetStringParameter("ProxyPassword"));
        //    String proxyDomain = PasswordUtil.GetStringParameter("ProxyDomain");

        //    WebProxy webProxy = new WebProxy();

        //    if (!String.IsNullOrEmpty(proxyDomain))
        //    {
        //        webProxy.Credentials = new NetworkCredential(proxyUsername, proxyPassword, proxyDomain);
        //    }
        //    else
        //    {
        //        webProxy.Credentials = new NetworkCredential(proxyUsername, proxyPassword);
        //    }

        //    return webProxy;
        //}

        internal static NetworkCredential InitNetworkCredential()
        {
            List<PasswordObject> passwordList = PasswordUtil.GetStringParameters(new[] { "ProxyUsername", "ProxyPassword", "ProxyDomain" });
            String proxyUsername = (passwordList[0]).value;
            String proxyPassword = CodingUtil.DecodeByte((passwordList[1]).value);
            String proxyDomain = (passwordList[2]).value;
            //String proxyUsername = PasswordUtil.GetStringParameter("ProxyUsername");
            //String proxyPassword = CodingUtil.DecodeByte(PasswordUtil.GetStringParameter("ProxyPassword"));
            //String proxyDomain = PasswordUtil.GetStringParameter("ProxyDomain");

            NetworkCredential networkCredentials;

            if (!String.IsNullOrEmpty(proxyDomain))
            {
                networkCredentials = new NetworkCredential(proxyUsername, proxyPassword, proxyDomain);
            }
            else
            {
                networkCredentials = new NetworkCredential(proxyUsername, proxyPassword);
            }

            return networkCredentials;
        }

        #endregion Internal Methods
    }
}
