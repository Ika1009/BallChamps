using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Reflection.Metadata;

namespace ApiClient
{
    public class StorageAPI
    {
        static CloudBlobClient _blobClient;
        static CloudBlobContainer _blobContainer;
        string BallChampsBlobConnectionString;
        string BlogContainerName;
        string UserProfileContainerName;
        string NewsFeedContainerName;
        string ProductContainerName;
        string CourtContainerName;

        public IConfiguration Configuration { get; }

        public StorageAPI (IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.BallChampsBlobConnectionString = Configuration.GetConnectionString("BallChampsBlobConnectionString");
            this.BlogContainerName = Configuration.GetSection("BlobStorage")["BlogImageContainerName"];
            this.UserProfileContainerName = Configuration.GetSection("BlobStorage")["UserProfileImageContainerName"];
            this.NewsFeedContainerName = Configuration.GetSection("BlobStorage")["NewsFeedImageContainerName"];
            this.ProductContainerName = Configuration.GetSection("BlobStorage")["ProductImageContainerName"];
            this.CourtContainerName = Configuration.GetSection("BlobStorage")["CourtImageContainerName"];
        }


        public async Task<bool> UpdateUserProfileImageInBlogStorage(string Id, Stream fileStream, string fileName)
        {
            string _blobContainerName = UserProfileContainerName;
            string _connectionString = BallChampsBlobConnectionString;
            bool isUploaded = false;
            string uniqueFileName = null;
            string fullpath = "";

            uniqueFileName = Id + ".png";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);

            _blobClient = storageAccount.CreateCloudBlobClient();
            _blobContainer = _blobClient.GetContainerReference(_blobContainerName);

            await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            // Create a blob reference
            var blob = _blobContainer.GetBlockBlobReference(uniqueFileName);

            try
            {
                // Directly upload from stream
                await blob.UploadFromStreamAsync(fileStream);

                isUploaded = true; // Set to true after successful upload
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                isUploaded = false; // Set to false if any exception occurs
            }

            fullpath = blob.Uri.AbsoluteUri; // The full path of the uploaded blob

            return isUploaded;
        }
        public async Task<bool> UpdateBlogImageInBlogStorage(string Id, IFormFile file)
        {


            string _blobContainerName = BlogContainerName;
            string _connectionString = BallChampsBlobConnectionString;
            bool isUploaded = false;
            string filePath = string.Empty;
            string uniqueFileName = null;
            string fullpath = "";
            string fileExt = "";
            string imagePath = "";
            fileExt = System.IO.Path.GetExtension(file.FileName);
            uniqueFileName = Id + ".png";

            fileExt = System.IO.Path.GetExtension(file.FileName);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);

            _blobClient = storageAccount.CreateCloudBlobClient();
            _blobContainer = _blobClient.GetContainerReference(_blobContainerName);

            await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            try
            {
                BlobContinuationToken blobContinuationToken = null;
                do
                {
                    var blob = _blobContainer.GetBlockBlobReference(uniqueFileName);

                    if (blob != null)
                    {

                        //if (blob.Metadata.Count == 0)
                        //{
                        //    blob.DeleteAsync().Wait();
                        //}


                        var blobx = _blobContainer.GetBlockBlobReference(uniqueFileName);

                        using (var stream = file.OpenReadStream())
                            blobx.UploadFromStreamAsync(stream).Wait();


                    }
                    else
                    {
                        using (var stream = file.OpenReadStream())
                            blob.UploadFromStreamAsync(stream).Wait();


                    }

                }
                while (blobContinuationToken != null);


            }
            catch (Exception ex)
            {
                var x = ex;
            }


            fullpath = filePath;

            imagePath = uniqueFileName;


            return isUploaded;
        }
        public async Task<bool> UpdateNewsFeedImageInBlogStorage(string Id, IFormFile file)
        {

            string _blobContainerName = NewsFeedContainerName;
            string _connectionString = BallChampsBlobConnectionString;
            bool isUploaded = false;
            string filePath = string.Empty;
            string uniqueFileName = null;
            string fullpath = "";
            string fileExt = "";
            string imagePath = "";
            fileExt = System.IO.Path.GetExtension(file.FileName);
            uniqueFileName = Id + ".png";

            fileExt = System.IO.Path.GetExtension(file.FileName);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);

            _blobClient = storageAccount.CreateCloudBlobClient();
            _blobContainer = _blobClient.GetContainerReference(_blobContainerName);

            await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            try
            {
                BlobContinuationToken blobContinuationToken = null;
                do
                {
                    var blob = _blobContainer.GetBlockBlobReference(uniqueFileName);

                    if (blob != null)
                    {

                        //if (blob.Metadata.Count == 0)
                        //{
                        //    blob.DeleteAsync().Wait();
                        //}


                        var blobx = _blobContainer.GetBlockBlobReference(uniqueFileName);

                        using (var stream = file.OpenReadStream())
                            blobx.UploadFromStreamAsync(stream).Wait();


                    }
                    else
                    {
                        using (var stream = file.OpenReadStream())
                            blob.UploadFromStreamAsync(stream).Wait();


                    }

                }
                while (blobContinuationToken != null);


            }
            catch (Exception ex)
            {
                var x = ex;
            }


            fullpath = filePath;

            imagePath = uniqueFileName;


            return isUploaded;
        }
        public async Task<bool> UpdateProductImageInBlogStorage(string Id, IFormFile file)
        {


            string _blobContainerName = ProductContainerName;
            string _connectionString = BallChampsBlobConnectionString;
            bool isUploaded = false;
            string filePath = string.Empty;
            string uniqueFileName = null;
            string fullpath = "";
            string fileExt = "";
            string imagePath = "";
            fileExt = System.IO.Path.GetExtension(file.FileName);
            uniqueFileName = Id + ".png";

            fileExt = System.IO.Path.GetExtension(file.FileName);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);

            _blobClient = storageAccount.CreateCloudBlobClient();
            _blobContainer = _blobClient.GetContainerReference(_blobContainerName);

            await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            try
            {
                BlobContinuationToken blobContinuationToken = null;
                do
                {
                    var blob = _blobContainer.GetBlockBlobReference(uniqueFileName);

                    if (blob != null)
                    {

                        //if (blob.Metadata.Count == 0)
                        //{
                        //    blob.DeleteAsync().Wait();
                        //}


                        var blobx = _blobContainer.GetBlockBlobReference(uniqueFileName);

                        using (var stream = file.OpenReadStream())
                            blobx.UploadFromStreamAsync(stream).Wait();


                    }
                    else
                    {
                        using (var stream = file.OpenReadStream())
                            blob.UploadFromStreamAsync(stream).Wait();


                    }

                }
                while (blobContinuationToken != null);


            }
            catch (Exception ex)
            {
                var x = ex;
            }


            fullpath = filePath;

            imagePath = uniqueFileName;


            return isUploaded;
        }
        public async Task<bool> UpdateCourtImageInBlogStorage(string Id, IFormFile file)
        {



            string _blobContainerName = CourtContainerName;
            string _connectionString = BallChampsBlobConnectionString;
            bool isUploaded = false;
            string filePath = string.Empty;
            string uniqueFileName = null;
            string fullpath = "";
            string fileExt = "";
            string imagePath = "";
            fileExt = System.IO.Path.GetExtension(file.FileName);
            uniqueFileName = Id + ".png";

            fileExt = System.IO.Path.GetExtension(file.FileName);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);

            _blobClient = storageAccount.CreateCloudBlobClient();
            _blobContainer = _blobClient.GetContainerReference(_blobContainerName);

            await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            try
            {
                BlobContinuationToken blobContinuationToken = null;
                do
                {
                    var blob = _blobContainer.GetBlockBlobReference(uniqueFileName);

                    if (blob != null)
                    {

                        //if (blob.Metadata.Count == 0)
                        //{
                        //    blob.DeleteAsync().Wait();
                        //}


                        var blobx = _blobContainer.GetBlockBlobReference(uniqueFileName);

                        using (var stream = file.OpenReadStream())
                            blobx.UploadFromStreamAsync(stream).Wait();


                    }
                    else
                    {
                        using (var stream = file.OpenReadStream())
                            blob.UploadFromStreamAsync(stream).Wait();


                    }

                }
                while (blobContinuationToken != null);


            }
            catch (Exception ex)
            {
                var x = ex;
            }


            fullpath = filePath;

            imagePath = uniqueFileName;


            return isUploaded;
        }

    }
}
