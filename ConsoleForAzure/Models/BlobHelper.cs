using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System.Threading.Tasks;

namespace ConsoleForAzure.Models
{
    public static class BlobHelper
    {
        private static string accessKey = "D0trqZg89hGElpbmEaBvL4ud/0UxiMx3C/GuBLubq1tIAaDuYnyi3gVqm2xY4mfezE2JjkUhCbaMUcf46zY3lw==";

        public static async Task<CloudBlobContainer> GetBlobContainer()
        {
            var storageCredentials = new StorageCredentials("productimages112233", accessKey);
            var cloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            var container = cloudBlobClient.GetContainerReference("jpgimages");
            if (await container.CreateIfNotExistsAsync())
            {
                await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            return container;
        }
    }
}
