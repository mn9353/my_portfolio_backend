using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Api.Models.Entities
{
    [Table("certifications")]
    public class Certifications
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("portfolio_id")]
        public long PortfolioId { get; set; }

        [Column("certificate_name")]
        public string CertificateName { get; set; } = string.Empty;

        [Column("issuing_organization")]
        public string IssuingOrganization { get; set; } = string.Empty;

        [Column("credential_id")]
        public string? CredentialId { get; set; }

        [Column("issue_date")]
        public DateTime? IssueDate { get; set; }

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }

        [Column("certificate_url")]
        public string? CertificateUrl { get; set; }

        [Column("badge_image_url")]
        public string? BadgeImageUrl { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("skills_covered")]
        public List<TechnologyItem>? SkillsCovered { get; set; }

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