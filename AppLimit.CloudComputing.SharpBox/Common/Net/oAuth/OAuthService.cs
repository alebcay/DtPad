using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using AppLimit.CloudComputing.SharpBox.Common.Net.oAuth.Context;
using AppLimit.CloudComputing.SharpBox.Common.Net.oAuth.Impl;
using AppLimit.CloudComputing.SharpBox.Common.Net.oAuth.Token;
using AppLimit.CloudComputing.SharpBox.Common.Net.Web;

namespace AppLimit.CloudComputing.SharpBox.Common.Net.oAuth
{
    internal class OAuthService : WebRequestService
    {
        #region Get Token Method

        private OAuthToken GetToken(String requestTokenUrl)
        {
            // get the token data 
            MemoryStream tokenData = PerformWebRequest2(requestTokenUrl, ValidRequestMethod.Get, null, null);

            // generate the token as self                       
            return tokenData != null ? OAuthStreamParser.ParseTokenInformation(tokenData) : null;
        }

        public OAuthToken GetRequestToken(OAuthServiceContext svcContext, OAuthConsumerContext conContext)
        {
            // generate the url
            String requestTokenUrl = OAuthUrlGenerator.GenerateRequestTokenUrl(svcContext.RequestTokenUrl, conContext);

            // get the token
            return GetToken(requestTokenUrl);                       
        }

        public OAuthToken GetAccessToken(OAuthServiceContext svcContext, OAuthConsumerContext conContext, OAuthToken requestToken)
        {
            String url = OAuthUrlGenerator.GenerateAccessTokenUrl(svcContext.AccessTokenUrl, conContext, requestToken);

            return GetToken(url);
        }

        #endregion

        #region Special oAuth WebRequest routines

        public virtual WebRequest CreateWebRequest(String url, ValidRequestMethod method, ICredentials credentials, Object context, OAuthConsumerContext conContext, OAuthToken accessToken, Dictionary<String, String> parameter)
        {
            // generate the signed url
            String signedUrl = GetProtectedResourceUrl(url, conContext, accessToken, parameter, ValidRequestMethod.Get);

            // generate the web request as self
            return CreateWebRequest(signedUrl, method, credentials, false, context);
        }

        #endregion
       
        #region Signed URL helpers
        
        public String GetProtectedResourceUrl(String resourceUrl, OAuthConsumerContext conContext, OAuthToken accessToken, Dictionary<String, String> parameter, ValidRequestMethod webMethod)
        {
            // build url
            return OAuthUrlGenerator.GenerateSignedUrl(resourceUrl, webMethod, conContext, accessToken, parameter);            
        }

        public String GetSignedUrl(String resourceUrl, OAuthConsumerContext conContext, OAuthToken accessToken, Dictionary<String, String> parameter)
        {
            return OAuthUrlGenerator.GenerateSignedUrl(resourceUrl, ValidRequestMethod.Post, conContext, accessToken, parameter);
        }

        #endregion
    }
}
