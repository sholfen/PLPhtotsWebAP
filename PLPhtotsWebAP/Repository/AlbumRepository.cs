using Azure.Data.Tables;
using Azure.Storage.Blobs;
using PLPhtotsWebAP.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PLPhtotsWebAP.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly string _tableName = "AzureAlbumTable";
        private static readonly string PartitionKey = "AlbumData";
        //public static string ContainerName = string.Empty;
        //public static string BlobConnectionString = string.Empty;
        public static string TableConnectionString = string.Empty;

        public static string CDNDomain = string.Empty;

        private TableClient? _cosmosClient = null;

        //private BlobContainerClient? _blobContainerClient = null;

        public AlbumRepository()
        {
            Init();
        }

        private void Init()
        {
            TableServiceClient tableServiceClient = new TableServiceClient(TableConnectionString);
            TableClient tableClient = tableServiceClient.GetTableClient(tableName: _tableName);

            tableClient.CreateIfNotExistsAsync().Wait();
            _cosmosClient = tableClient;

            //_blobContainerClient = new BlobContainerClient(BlobConnectionString, ContainerName);
            //_blobContainerClient.CreateIfNotExists();
        }

        public async Task<AlbumData> AddAlbum(AlbumData album)
        {
            await _cosmosClient.AddEntityAsync(album);
            return album;
        }

        public async Task DeleteAlbum(int id)
        {
            await _cosmosClient.DeleteEntityAsync(PartitionKey, id.ToString());
        }

        public async Task<AlbumData> GetAlbum(string id)
        {
            var azureTestDatas = _cosmosClient.Query<AlbumData>(x => x.PartitionKey == PartitionKey);
            return azureTestDatas.FirstOrDefault();
        }

        public async Task<IEnumerable<AlbumData>> GetAlbums()
        {
            throw new NotImplementedException();
        }

        public async Task<AlbumData> UpdateAlbum(AlbumData album)
        {
            throw new NotImplementedException();
        }
    }
}
