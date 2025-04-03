using Azure.Data.Tables;
using Azure;

namespace UploadLib.Models
{
    public record AlbumData : ITableEntity
    {
        public string RowKey { get; set; } = Guid.NewGuid().ToString();

        public string PartitionKey { get; set; } = "AlbumData";

        public ETag ETag { get; set; } = default!;

        public DateTimeOffset? Timestamp { get; set; } = default!;

        public string Title { get; init; } = string.Empty;

        public string Desc { get; init; } = string.Empty;

        /// <summary>
        /// PictureData's RowKey list
        /// </summary>
        public List<string> PictureIDList { get; set; } = new List<string>();
    }
}
