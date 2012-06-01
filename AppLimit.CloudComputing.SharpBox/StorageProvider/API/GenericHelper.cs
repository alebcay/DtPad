using System;

namespace AppLimit.CloudComputing.SharpBox.StorageProvider.API
{
    internal class GenericHelper
    {        
        public static String GetResourcePath(ICloudFileSystemEntry entry)
        {
            ICloudFileSystemEntry current = entry;
            String path = "";

            while (current != null)
            {
                if (current.Name != "/")
                    path = current.Name + "/" + path;
                else
                    path = "/" + path;

                current = current.Parent;
            }
                      
            return path;
        }        
    }
}
