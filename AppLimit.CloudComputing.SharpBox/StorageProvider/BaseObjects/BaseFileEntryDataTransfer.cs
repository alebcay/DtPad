using System.IO;
using AppLimit.CloudComputing.SharpBox.StorageProvider.API;

namespace AppLimit.CloudComputing.SharpBox.StorageProvider.BaseObjects
{
    internal class BaseFileEntryDataTransfer : ICloudFileDataTransfer
    {
        private ICloudFileSystemEntry _fsEntry;        
        private IStorageProviderService _service;
        private IStorageProviderSession _session;        

        public BaseFileEntryDataTransfer(ICloudFileSystemEntry fileSystemEntry, IStorageProviderService service, IStorageProviderSession session)
        {
            _fsEntry = fileSystemEntry;            
            _session = session;
            _service = service;            
        }

        #region ICloudFileDataTransfer Members

        public void Transfer(Stream targetDataStream, nTransferDirection direction, FileOperationProgressChanged progressCallback, object progressContext)
        {
            // call the transfer interface in the service provider
            if (direction == nTransferDirection.nUpload)
            {
                if (_session.ServiceConfiguration.Limits.MaxUploadFileSize != -1 && targetDataStream.Length > _session.ServiceConfiguration.Limits.MaxUploadFileSize)
                    throw new SharpBox.Exceptions.SharpBoxException(AppLimit.CloudComputing.SharpBox.Exceptions.SharpBoxErrorCodes.ErrorLimitExceeded);
                else
                    _service.UploadResourceContent(_session, _fsEntry, targetDataStream, progressCallback, progressContext);
            }
            else
            {
                if (_session.ServiceConfiguration.Limits.MaxDownloadFileSize != -1 && _fsEntry.Length > _session.ServiceConfiguration.Limits.MaxDownloadFileSize)
                    throw new SharpBox.Exceptions.SharpBoxException(AppLimit.CloudComputing.SharpBox.Exceptions.SharpBoxErrorCodes.ErrorLimitExceeded);
                else
                    _service.DownloadResourceContent(_session, _fsEntry, targetDataStream, progressCallback, progressContext);
            }
        }       

        public Stream GetDownloadStream()
        {
            return _service.CreateDownloadStream(_session, _fsEntry);                        
        }

        public Stream GetUploadStream(long uploadSize)
        {
            return _service.CreateUploadStream(_session, _fsEntry, uploadSize);
        }

#if !WINDOWS_PHONE
        void ICloudFileDataTransfer.Serialize(System.Runtime.Serialization.IFormatter dataFormatter, object objectGraph)
        {
            using (MemoryStream cache = new MemoryStream())
            {
                // serialize into the cache
                dataFormatter.Serialize(cache, objectGraph);

                // go to start
                cache.Position = 0;

                // transfer the cache
                _fsEntry.GetDataTransferAccessor().Transfer(cache, nTransferDirection.nUpload, null, null);
            }
        }

        object ICloudFileDataTransfer.Deserialize(System.Runtime.Serialization.IFormatter dataFormatter)
        {
            using (MemoryStream cache = new MemoryStream())
            {
                // get the data
                _fsEntry.GetDataTransferAccessor().Transfer(cache, nTransferDirection.nDownload, null, null);

                // go to the start
                cache.Position = 0;

                // go ahead
                return dataFormatter.Deserialize(cache);
            }
        }
#endif                        

        #endregion               
    }
}
