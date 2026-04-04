using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("project_detail_points")]
    public class ProjectDetailPoints
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("project_id")]
        public long ProjectId { get; set; }

        [Column("point_type")]
        public string PointType { get; set; } = string.Empty;

        [Column("content")]
        public string Content { get; set; } = string.Empty;

        [Column("display_order")]
        public int DisplayOrder { get; set; }
    }
}
