using Azure;
using Azure.Data.Tables;

namespace UploadLib.Models
{
    public record PictureData : ITableEntity
    {
        public string RowKey { get; set; } = Guid.NewGuid().ToString();

        public string PartitionKey { get; set; } = "PictureData";

        public string ThumbGuid { get; set; } = string.Empty;

        public bool IsThumb { get; set; } = false;

        public ETag ETag { get; set; } = default!;

        public DateTimeOffset? Timestamp { get; set; } = default!;

        public string Title { get; init; } = string.Empty;

        public string Desc { get; init; } = string.Empty;

        public string ImageUrl { get; init; } = string.Empty;

        public string ThumbUrl { get; init; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public string AlbumID { get; set; } = string.Empty;
    }
}
