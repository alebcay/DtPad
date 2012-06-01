using System;
using AppLimit.CloudComputing.SharpBox.Common.Net.oAuth.Impl;
using AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox.Logic;
using AppLimit.CloudComputing.SharpBox.Common.Net.oAuth.Token;
using AppLimit.CloudComputing.SharpBox.Common.Net.oAuth;
using AppLimit.CloudComputing.SharpBox.Common.Net.oAuth.Context;
using AppLimit.CloudComputing.SharpBox.StorageProvider.API;

namespace AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
{
    /// <summary>
    /// This class contains a couple a tools which will be helpful
    /// when working with dropbox only
    /// </summary>
    static public class DropBoxStorageProviderTools
    {
        /// <summary>
        /// This method retrieves a new request token from the dropbox server
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="ConsumerKey"></param>
        /// <param name="ConsumerSecret"></param>
        /// <returns></returns>
        static public Object GetDropBoxRequestToken(DropBoxConfiguration configuration, String ConsumerKey, String ConsumerSecret)
        {
            // build the consumer context
            var consumerContext = new OAuthConsumerContext(ConsumerKey, ConsumerSecret);

            // build up the oauth session
            var serviceContext = new OAuthServiceContext(DropBoxConfiguration.RequestTokenUrl.ToString(),
                                                            DropBoxConfiguration.AuthorizationTokenUrl.ToString(), configuration.AuthorizationCallBack.ToString(),
                                                            DropBoxConfiguration.AccessTokenUrl.ToString());

            // get a request token from the provider      
            OAuthService svc = new OAuthService();
            return svc.GetRequestToken(serviceContext, consumerContext);            
        }

        /// <summary>
        /// This method builds derived from the request token a valid authorization url which can be used
        /// for web applications
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="DropBoxRequestToken"></param>
        /// <returns></returns>
        static public String GetDropBoxAuthorizationUrl(DropBoxConfiguration configuration, Object DropBoxRequestToken)
        {                   
            // build the auth url
            return OAuthUrlGenerator.GenerateAuthorizationUrl(  DropBoxConfiguration.AuthorizationTokenUrl.ToString(), 
                                                                configuration.AuthorizationCallBack.ToString(),
                                                                DropBoxRequestToken as OAuthToken);
        }

        /// <summary>
        /// This method is able to exchange the request token into an access token which can be used in 
        /// sharpbox. It is necessary that the user validated the request via authorization url otherwise 
        /// this call wil results in an unauthorized exception!
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="ConsumerKey"></param>
        /// <param name="ConsumerSecret"></param>
        /// <param name="DropBoxRequestToken"></param>
        /// <returns></returns>
        static public ICloudStorageAccessToken ExchangeDropBoxRequestTokenIntoAccessToken(DropBoxConfiguration configuration, String ConsumerKey, String ConsumerSecret, Object DropBoxRequestToken)
        {
            // build the consumer context
            var consumerContext = new OAuthConsumerContext(ConsumerKey, ConsumerSecret);

            // build up the oauth session
            var serviceContext = new OAuthServiceContext(DropBoxConfiguration.RequestTokenUrl.ToString(),
                                                            DropBoxConfiguration.AuthorizationTokenUrl.ToString(), configuration.AuthorizationCallBack.ToString(),
                                                            DropBoxConfiguration.AccessTokenUrl.ToString());
            
            // build the access token
            OAuthService svc = new OAuthService();
            OAuthToken accessToken = svc.GetAccessToken(serviceContext, consumerContext, DropBoxRequestToken as OAuthToken);
            if (accessToken == null)
                throw new UnauthorizedAccessException();

            // create the access token 
            return new DropBoxToken(    accessToken, 
                                        new DropBoxBaseCredentials() 
                                        { 
                                            ConsumerKey = ConsumerKey, 
                                            ConsumerSecret = ConsumerSecret 
                                        });            
        }

        /// <summary>
        /// This method returns the account information of a dropbox account
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        static public DropBoxAccountInfo GetAccountInformation(ICloudStorageAccessToken token)
        {
            // generate the dropbox service
            DropBoxStorageProviderService service = new DropBoxStorageProviderService();

            // generate a session
            IStorageProviderSession session =  service.CreateSession(token, DropBoxConfiguration.GetStandardConfiguration());
            if (session == null)
                return null;

            // receive acc info
            DropBoxAccountInfo accInfo = service.GetAccountInfo(session);
            
            // close the session
            service.CloseSession(session);

            // go ahead
            return accInfo;
        }

        /// <summary>
        /// This method returns the public URL of a DropBox file or folder
        /// </summary>
        /// <param name="token"></param>
        /// <param name="fsEntry"></param>
        /// <returns></returns>
        static public Uri GetPublicObjectUrl(ICloudStorageAccessToken token, ICloudFileSystemEntry fsEntry)
        {
            // check parameters
            if (fsEntry == null)
                throw new SharpBox.Exceptions.SharpBoxException(AppLimit.CloudComputing.SharpBox.Exceptions.SharpBoxErrorCodes.ErrorInvalidParameters);

            // get the resource path
            String resourcePath = GenericHelper.GetResourcePath(fsEntry);

            // check if it is a public dir
            if (!resourcePath.ToLower().Contains("/public/"))
                throw new SharpBox.Exceptions.SharpBoxException(AppLimit.CloudComputing.SharpBox.Exceptions.SharpBoxErrorCodes.ErrorInvalidParameters);
            
            // get accoutn inf
            DropBoxAccountInfo accInfo = GetAccountInformation(token);
                
            // http;//dl.dropbox.com/u/" + userid / + folder + filename
            String uri = "http://dl.dropbox.com/u/"+ accInfo.UserId.ToString() + resourcePath.Replace("/Public", "");

            // go ahead
            return new Uri(uri);
        }
    }
}
