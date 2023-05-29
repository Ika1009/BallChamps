

namespace DataLayer.Helper
{
    public class WebAPISettings
    {

        public string userProfileImageStorageConnectionString()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=swishstorage;AccountKey=soqrL2GmNetFUnP2V2wYWUS4/ti3EMoROv8ZaKmqAcnvBNX0HmuCoVWpJpuXCFO9MZ+2iqW65MVBww3huNJePg==;EndpointSuffix=core.windows.net";

            return storageConnectionString;
        }

        public string userProfileImageblobContainerName()
        {
            string blobContainerName = "userpofileimage";

            return blobContainerName;
        }

        public string blobCourtsImageContainerName()
        {
            string blobContainerName = "courtsimages";

            return blobContainerName;
        }
    }
}
