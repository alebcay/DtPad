using AppLimit.CloudComputing.SharpBox.StorageProvider.WebDav.Logic;

namespace AppLimit.CloudComputing.SharpBox.StorageProvider.WebDav
{
	internal class WebDavStorageProvider : GenericStorageProvider
	{
        public WebDavStorageProvider()
            : base( new WebDavStorageProviderService())
        {
        }		
    }
}
