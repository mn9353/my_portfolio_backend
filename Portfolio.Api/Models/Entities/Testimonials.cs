using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("testimonials")]
    public class Testimonials
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("portfolio_id")]
        public long PortfolioId { get; set; }

        [Column("client_name")]
        public string ClientName { get; set; } = string.Empty;

        [Column("designation")]
        public string? Designation { get; set; }

        [Column("company_name")]
        public string? CompanyName { get; set; }

        [Column("testimonial_text")]
        public string TestimonialText { get; set; } = string.Empty;

        [Column("profile_image_url")]
        public string? ProfileImageUrl { get; set; }

        [Column("rating")]
        public int? Rating { get; set; }

        [Column("is_visible")]
        public bool IsVisible { get; set; }

        [Column("display_order")]
        public int DisplayOrder { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}