using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BLL.Services
{
    public class BlobService
    {
        private string _connectionString;
        private string _photoContainerName;

        public BlobService(string connectionString)
        {
            _connectionString = connectionString;
            _photoContainerName = "catphoto";
        }

        public byte[] DownloadPicture(string filename)
        {
            var blob = new BlobClient(_connectionString, _photoContainerName, filename);
            var download = blob.DownloadContent();
            
            return download.Value.Content.ToArray();
        }

        public void UploadPicture(string filename, Stream stream)
        {
            var containerClient = new BlobContainerClient(_connectionString, _photoContainerName);
            var blob = containerClient.GetBlobClient(filename);
            blob.Upload(stream);
        }

        public void DeletePicture(string filename)
        {
            var containerClient = new BlobContainerClient(_connectionString, _photoContainerName);
            var blob = containerClient.GetBlobClient(filename);
            blob.DeleteIfExists();
        }
    }
}
