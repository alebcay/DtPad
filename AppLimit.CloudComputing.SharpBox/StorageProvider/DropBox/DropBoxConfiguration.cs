using System;
using AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox.Logic;

namespace AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
{
	/// <summary>
	/// DropBoxConfiguration conains the default access information for the DropBox
	/// storage and synchronization services. This class implements from the 
	/// ICloudStorageConfiguration interface and can be used with an instance of CloudStorage    
	/// </summary>
	public class DropBoxConfiguration : ICloudStorageConfiguration
	{
		/// <summary>
		/// This method creates and returns the url which has to be used to get a access token 
		/// during the OAuth based authorization process
		/// </summary>
		public static readonly Uri RequestTokenUrl;

		/// <summary>
		/// This method creates and returns the url which has to be used to get a access token 
		/// during the OAuth based authorization process
		/// </summary>
		public static readonly Uri AccessTokenUrl;

		/// <summary>
		/// This method creates and returns the url which can be used in the browser
		/// to authorize the end user
		/// </summary>
		public static readonly Uri AuthorizationTokenUrl;

        /// <summary>
        /// This field contains the callback URL which will be used in the oAuth 
        /// request. Default will be sharpbox.codeplex.com 
        /// </summary>
        public Uri AuthorizationCallBack = new Uri("http://sharpox.codeplex.com");


		static DropBoxConfiguration()
		{
            RequestTokenUrl = new Uri(DropBoxStorageProviderService.DropBoxBaseUrl + "/0/oauth/request_token");
            AccessTokenUrl = new Uri(DropBoxStorageProviderService.DropBoxBaseUrl + "/0/oauth/access_token");
            AuthorizationTokenUrl = new Uri(DropBoxStorageProviderService.DropBoxBaseUrlEndUser + "/0/oauth/authorize");
		}

		/// <summary>
		/// Constructor of a dropbox configuration
		/// </summary>
		public DropBoxConfiguration()
            : this(new Uri(DropBoxStorageProviderService.DropBoxBaseUrl))
		{
            
		}

        /// <summary>
        /// Allows to create the dopbox configuration with a special 
        /// service provider location
        /// </summary>
        /// <param name="ServiceLocator"></param>
        public DropBoxConfiguration(Uri ServiceLocator)
        {
            this.ServiceLocator =  ServiceLocator;
        }

		/// <summary>
		/// This method generates an instance of the default dropbox configuration
		/// </summary>
		/// <returns>Instance of the DropBoxConfiguration-Class with default settings</returns>
		static public DropBoxConfiguration GetStandardConfiguration()
		{
			return new DropBoxConfiguration();
		}
	
        /// <summary>
        /// If true this value indicates the all ssl connection are valid. This means also ssl connection
        /// with an invalid certificate will be accepted.
        /// </summary>
        public bool TrustUnsecureSSLConnections
        {
            get { return false; }
        }

        /// <summary>
        /// The limits of dropbox
        /// </summary>
        public CloudStorageLimits Limits
        {
            get 
            {
                return new CloudStorageLimits() { MaxDownloadFileSize = -1, MaxUploadFileSize = 200 * 1024 * 1024 };
            }
        }        

        /// <summary>
        /// Gets the currently used dropbox url
        /// </summary>
        public Uri ServiceLocator
        {
            get; private set;
        }        
    }
}
