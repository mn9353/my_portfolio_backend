using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("project_links")]
    public class ProjectLinks
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("project_id")]
        public long ProjectId { get; set; }

        [Column("label")]
        public string Label { get; set; } = string.Empty;

        [Column("url")]
        public string Url { get; set; } = string.Empty;

        [Column("display_order")]
        public int DisplayOrder { get; set; }
    }
}
