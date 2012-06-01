using System;
using AppLimit.CloudComputing.SharpBox.Common.Net.oAuth.Token;
using AppLimit.CloudComputing.SharpBox.Common.Net.Json;

namespace AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
{
	internal class DropBoxToken : OAuthToken, ICloudStorageAccessToken
	{
        public DropBoxBaseCredentials BaseCredentials;

		public DropBoxToken(String jsonString)
			: base("", "")
		{
			var jh = new JsonHelper();
			if (jh.ParseJsonMessage(jsonString))
			{
				TokenSecret = jh.GetProperty("secret");
				TokenKey = jh.GetProperty("token");
			}
		}

		public DropBoxToken(OAuthToken token, DropBoxBaseCredentials baseCreds)
			: base(token.TokenKey, token.TokenSecret)
		{
            BaseCredentials = baseCreds;
		}

		public DropBoxToken(string tokenKey, string tokenSecret, DropBoxBaseCredentials baseCreds)
			: base(tokenKey, tokenSecret)
		{
            BaseCredentials = baseCreds;
		}

        public ICloudStorageConfiguration ServiceConfiguration
        {
            get { return DropBoxConfiguration.GetStandardConfiguration(); }
        }
    }
}

