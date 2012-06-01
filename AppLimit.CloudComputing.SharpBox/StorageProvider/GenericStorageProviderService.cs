﻿using System;
using System.Collections.Generic;
using System.IO;
using AppLimit.CloudComputing.SharpBox.Common.IO;
using AppLimit.CloudComputing.SharpBox.StorageProvider.API;
using AppLimit.CloudComputing.SharpBox.Exceptions;

namespace AppLimit.CloudComputing.SharpBox.StorageProvider
{
    /// <summary>
    /// This class has to be used in combination with the GenericStorageProvider class
    /// and supports all generic logic on the service level
    /// </summary>
    public abstract class GenericStorageProviderService : IStorageProviderService
    {                
        internal const String TokenGenericCredUsername = "TokenCredGenericUsername";
        internal const String TokenGenericCredPassword = "TokenCredGenericPassword";

        /// <summary>
        /// This method verifies if the given configuration is compatible to the implemented
        /// service provider.
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public abstract bool VerifyCredentialType(ICloudStorageCredentials credentials);        

        /// <summary>
        /// This method creates an authenticated session between the calling application
        /// and the targeted service provider.
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public abstract IStorageProviderSession CreateSession(ICloudStorageCredentials credentials, ICloudStorageConfiguration configuration);

        /// <summary>
        /// This method generates a session to a webdav share via access token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public virtual IStorageProviderSession CreateSession(ICloudStorageAccessToken token, ICloudStorageConfiguration configuration)
        {
            return CreateSession((token as ICloudStorageCredentials), configuration);
        }

        /// <summary>
        /// This method closes the session
        /// </summary>
        /// <param name="session"></param>        
        public virtual void CloseSession(IStorageProviderSession session)
        {
            // nothing to do here
        }

        /// <summary>
        /// This method request a directory entry from the storage provider service
        /// </summary>
        /// <param name="session"></param>
        /// <param name="Name"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public abstract ICloudFileSystemEntry RequestResource(IStorageProviderSession session, string Name, ICloudDirectoryEntry parent);

        /// <summary>
        /// This method updates the locally cache resource metadata from the storage service
        /// </summary>
        /// <param name="session"></param>
        /// <param name="resource"></param>
        public abstract void RefreshResource(IStorageProviderSession session, ICloudFileSystemEntry resource);

        /// <summary>
        /// This method removes a resource in the storage provider service
        /// </summary>
        /// <param name="session"></param>
        /// <param name="entry"></param>
        /// <returns></returns>
        public abstract bool DeleteResource(IStorageProviderSession session, ICloudFileSystemEntry entry);

        /// <summary>
        /// This method deletes a resource in the storage provider service
        /// </summary>
        /// <param name="session"></param>
        /// <param name="fsentry"></param>
        /// <param name="newParent"></param>
        /// <returns></returns>
        public abstract bool MoveResource(IStorageProviderSession session, ICloudFileSystemEntry fsentry, ICloudDirectoryEntry newParent);

        /// <summary>
        /// Writes a generic token onto the storage collection
        /// </summary>
        /// <param name="session"></param>
        /// <param name="tokendata"></param>
        /// <param name="token"></param>        
        public virtual void StoreToken(IStorageProviderSession session, Dictionary<String, String> tokendata, ICloudStorageAccessToken token)
        {
            if (token is GenericNetworkCredentials)
            {
                GenericNetworkCredentials creds = token as GenericNetworkCredentials;                
                tokendata.Add(TokenGenericCredUsername, creds.UserName);
                tokendata.Add(TokenGenericCredPassword, creds.Password);
            }             
        }

        /// <summary>
        /// Reads the token information
        /// </summary>        
        /// <param name="tokendata"></param>
        /// <returns></returns>       
        public virtual ICloudStorageAccessToken LoadToken(Dictionary<String, String> tokendata)
        {
            ICloudStorageAccessToken at = null;

            String type = tokendata[CloudStorage.TokenCredentialType];

            if (type.Equals(typeof(GenericNetworkCredentials).ToString()))
            {
                var username = tokendata[TokenGenericCredUsername];
                var password = tokendata[TokenGenericCredPassword];

                GenericNetworkCredentials bc = new GenericNetworkCredentials();
                bc.UserName = username;
                bc.Password = password;

                at = bc;
            }
#if !WINDOWS_PHONE
            else if (type.Equals(typeof(GenericCurrentCredentials).ToString()))
            {
                at = new GenericCurrentCredentials();
            }
#endif

            return at;         
        }

        /// <summary>
        /// This method build up a valid resource url
        /// </summary>
        /// <param name="session"></param>
        /// <param name="fileSystemEntry"></param>
        /// <param name="additionalPath"></param>
        /// <returns></returns>       
        public virtual string GetResourceUrl(IStorageProviderSession session, ICloudFileSystemEntry fileSystemEntry, string additionalPath)
        {            
            // build the url            
            String targeturl = PathHelper.Combine(session.ServiceConfiguration.ServiceLocator.ToString(), GenericHelper.GetResourcePath(fileSystemEntry));

            // finalize the url 
            if (!(fileSystemEntry is ICloudDirectoryEntry))
                targeturl = targeturl.TrimEnd('/');

            // add the additional Path 
            if (additionalPath != null)
                targeturl = PathHelper.Combine(targeturl, additionalPath);            

            // go ahead
            return targeturl;
        }        

        /// <summary>
        /// This methid download the content of a file resource into a target download stream 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="fileSystemEntry"></param>
        /// <param name="targetDataStream"></param>
        /// <param name="progressCallback"></param>
        /// <param name="progressContext"></param>
        public virtual void DownloadResourceContent(IStorageProviderSession session, ICloudFileSystemEntry fileSystemEntry, Stream targetDataStream, FileOperationProgressChanged progressCallback, Object progressContext)
        {            
            // build the download stream
            using (Stream data = CreateDownloadStream(session, fileSystemEntry))
            {                
                // copy the data                
                StreamHelperResult res = StreamHelper.CopyStreamData(this, data, targetDataStream, CloudStorage.FileStreamCopyCallback, progressCallback, fileSystemEntry, progressContext);
                if (res.ResultCode == StreamHelperResultCodes.Aborted)
                    throw new SharpBoxException(SharpBoxErrorCodes.ErrorTransferAbortedManually);

                // commit everything
                CommitStreamOperation(session, fileSystemEntry, nTransferDirection.nDownload, data);
            }
        }

        /// <summary>
        /// This method establishes a download stream with the storage service
        /// </summary>
        /// <param name="session"></param>
        /// <param name="fileSystemEntry"></param>
        /// <returns></returns>
        public abstract Stream CreateDownloadStream(IStorageProviderSession session, ICloudFileSystemEntry fileSystemEntry);

        /// <summary>
        /// This method establishes an upload stream with the storage service
        /// </summary>
        /// <param name="session"></param>
        /// <param name="fileSystemEntry"></param>
        /// <param name="uploadSize"></param>
        /// <returns></returns>
        public abstract Stream CreateUploadStream(IStorageProviderSession session, ICloudFileSystemEntry fileSystemEntry, long uploadSize);

        /// <summary>
        /// This method commits a stream operation before the disposabl method of the stream will be called 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="fileSystemEntry"></param>
        /// <param name="Direction"></param>
        /// <param name="NotDisposedStream"></param>
        public abstract void CommitStreamOperation(IStorageProviderSession session, ICloudFileSystemEntry fileSystemEntry, nTransferDirection Direction, Stream NotDisposedStream);

        /// <summary>
        /// This method uploads data into a file resource 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="fileSystemEntry"></param>
        /// <param name="targetDataStream"></param>
        /// <param name="progressCallback"></param>
        /// <param name="progressContext"></param>
        public virtual void UploadResourceContent(IStorageProviderSession session, ICloudFileSystemEntry fileSystemEntry, Stream targetDataStream, FileOperationProgressChanged progressCallback, object progressContext)
        {
            // build the stream stream
            using (Stream data = CreateUploadStream(session, fileSystemEntry, targetDataStream.Length))
            {
                // copy the data                
                StreamHelperResult res = StreamHelper.CopyStreamData(this, targetDataStream, data, CloudStorage.FileStreamCopyCallback, progressCallback, fileSystemEntry, progressContext);
                if (res.ResultCode == StreamHelperResultCodes.Aborted)
                    throw new SharpBoxException(SharpBoxErrorCodes.ErrorTransferAbortedManually);

                // flush the upload stream to clean the caches
                data.Flush();                

                // commit everything
                CommitStreamOperation(session, fileSystemEntry, nTransferDirection.nUpload, data);
            }
        }
                
        /// <summary>
        /// This methid creates a directory object in the storage service 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="Name"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public abstract ICloudFileSystemEntry CreateResource(IStorageProviderSession session, string Name, ICloudDirectoryEntry parent);
        
        /// <summary>
        /// This method renames a resource in the storage service
        /// </summary>
        /// <param name="session"></param>
        /// <param name="fsentry"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public abstract bool RenameResource(IStorageProviderSession session, ICloudFileSystemEntry fsentry, string newName);        
    }
}
