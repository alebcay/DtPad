using System;

namespace AppLimit.CloudComputing.SharpBox.Common.Net.oAuth.Token
{
    internal class OAuthToken
    {
        public String TokenKey { get; protected set; }
        public String TokenSecret { get; protected set; }

        public OAuthToken(String tokenKey, String tokenSecret)
        {
            TokenKey = tokenKey;
            TokenSecret = tokenSecret;
        }
    }
}
