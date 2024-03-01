using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Azure;
using JsonStorageManager.BlobManager.Models;

namespace JsonStorageManager.BlobManager
{
    internal class BlobManager
    {
        public async Task<List<BlobListItem>> ListBlobsInContainerAsync()
        {
            var blobContainerClient = new BlobContainerClient(
                Environment.GetEnvironmentVariable("queueConnectionString"),
                Environment.GetEnvironmentVariable("blobContainerName"));

            var segmentSizeDefined = int.TryParse(Environment.GetEnvironmentVariable("segmentSize"), out int segmentSize);
            if(!segmentSizeDefined)
            {
                segmentSize = 10;
            }

            return await ListBlobsFlatListingAsync(blobContainerClient, segmentSize);
        }

        private static async Task<List<BlobListItem>> ListBlobsFlatListingAsync(
            BlobContainerClient blobContainerClient,
            int segmentSize)
        {
            var blobItemResultList = new List<BlobListItem>();

            var resultSegments = blobContainerClient
                .GetBlobsAsync()
                .AsPages(default, segmentSize);

            await foreach (Page<BlobItem> segment in resultSegments)
            {
                foreach (BlobItem blobItem in segment.Values)
                {
                    blobItemResultList.Add(new BlobListItem(Name: blobItem.Name));
                }
            }

            return blobItemResultList;
        }
    }
}
