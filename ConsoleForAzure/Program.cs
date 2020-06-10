using ConsoleForAzure.Models;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleForAzure
{
    class Program
    {
		private static string accessKey = "D0trqZg89hGElpbmEaBvL4ud/0UxiMx3C/GuBLubq1tIAaDuYnyi3gVqm2xY4mfezE2JjkUhCbaMUcf46zY3lw==";

		static async Task Main(string[] args)
		{
			await MainAsync(args);
		}

		static async Task MainAsync(string[] args)
		{
			try
			{
				var container = await BlobHelper.GetBlobContainer();
				FileInfo fi = new FileInfo(@"C:\Users\atahar2380\Pictures\Assignment\IntegrationLayer.jpg");

				string imageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(fi.Name);

				CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(imageName);
				cloudBlockBlob.Properties.ContentType = "image/jpg";

				using (var stream = fi.OpenRead())
				{
					await cloudBlockBlob.UploadFromStreamAsync(stream);
					await cloudBlockBlob.DeleteIfExistsAsync();
				}
			}
			catch (Exception ex)
			{

			}
		}
	}
}
//DeploymentDiagram.jpg
//https://productimages112233.blob.core.windows.net/images/DeploymentDiagram.jpg