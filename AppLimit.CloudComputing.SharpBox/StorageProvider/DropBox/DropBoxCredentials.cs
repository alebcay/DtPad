using System;

namespace AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
{   
    /// <summary>
    /// This class contains the needed access credentials for a specific dropbox
    /// application sandbox and a specific end user
    /// </summary>
    public class DropBoxCredentials : DropBoxBaseCredentials, ICloudStorageCredentials
    {        
        /// <summary>
        /// Useraccount of the end user with access to DropBox and the 
        /// defined application
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// Password of the end user with access to DropBox and the 
        /// defined application
        /// </summary>
		public String Password { get; set; }
    }
}
