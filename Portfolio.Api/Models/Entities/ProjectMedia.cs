using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("project_media")]
    public class ProjectMedia
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("project_id")]
        public long ProjectId { get; set; }

        [Column("media_type")]
        public string MediaType { get; set; } = string.Empty;

        [Column("media_url")]
        public string MediaUrl { get; set; } = string.Empty;

        [Column("caption")]
        public string? Caption { get; set; }

        [Column("is_cover")]
        public bool IsCover { get; set; }

        [Column("display_order")]
        public int DisplayOrder { get; set; }
    }
}
