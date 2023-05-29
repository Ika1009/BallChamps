using Microsoft.Extensions.Configuration;

namespace ApiClient.Helper
{
    public class StorageSettingsApi
    {

        string BallchampsStorageConnectionString;
        string BlobUserProfileimagesContainerName;
        string BlobProductimagesContainerName;
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Storage Api
        /// </summary>
        /// <param name="courtWaitingListContext"></param>
        public StorageSettingsApi(IConfiguration configuration)
        {
            Configuration = configuration;
            
            this.BallchampsStorageConnectionString = Configuration.GetSection("StorageConnection:BallChamps_StorageConnection").Value;
            this.BlobUserProfileimagesContainerName = Configuration.GetSection("ContainerName:UserProfile").Value;
            this.BlobProductimagesContainerName = Configuration.GetConnectionString("ContainerName:Product");
        }

        /// <summary>
        /// blogStorage ConnectionString
        /// </summary>
        /// <returns></returns>
        public string blogStorageConnectionString()
        {
            string storageConnectionString = BallchampsStorageConnectionString;

            return storageConnectionString;
        }

        /// <summary>
        /// blob UserProfile Image ContainerName
        /// </summary>
        /// <returns></returns>
        public string blobUserProfileImageContainerName()
        {
            string blobContainerName = BlobUserProfileimagesContainerName;

            return blobContainerName;
        }

        /// <summary>
        /// blob Product Image ContainerName
        /// </summary>
        /// <returns></returns>
        public string blobProductImageContainerName()
        {
            string blobContainerName = BlobProductimagesContainerName;

            return blobContainerName;
        }



    }
}
