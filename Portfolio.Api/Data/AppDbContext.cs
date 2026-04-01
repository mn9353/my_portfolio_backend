using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio.Api.Models.Entities;
using System.Text.Json;

namespace Portfolio.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Portfolios> PortfoliosTable { get; set; }
        public DbSet<Sections> SectionsTable { get; set; }
        public DbSet<Translations> TranslationTable { get; set; }
        public DbSet<LanguageList> LanguageListTable { get; set; }
        public DbSet<Projects> ProjectTable { get; set; }
        public DbSet<Experiences> ExperiencesTable { get; set; }
        public DbSet<Education> EducationTable { get; set; }
        public DbSet<Skills> SkillsTable { get; set; }
        public DbSet<Certifications> CertificationsTable { get; set; }
        public DbSet<Achievements> AchievementsTable { get; set; }
        public DbSet<SocialLinks> SocialLinksTable { get; set; }
        public DbSet<Testimonials> TestimonialsTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TechnologyItem is stored as JSON in parent tables, not as a separate entity table.
            modelBuilder.Ignore<TechnologyItem>();

            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            var technologyListConverter = new ValueConverter<List<TechnologyItem>?, string?>(
                value => value == null ? null : JsonSerializer.Serialize(value, jsonOptions),
                value => string.IsNullOrWhiteSpace(value)
                    ? new List<TechnologyItem>()
                    : JsonSerializer.Deserialize<List<TechnologyItem>>(value, jsonOptions) ?? new List<TechnologyItem>());

            var technologyListComparer = new ValueComparer<List<TechnologyItem>?>(
                (left, right) => JsonSerializer.Serialize(left, jsonOptions) == JsonSerializer.Serialize(right, jsonOptions),
                value => value == null ? 0 : JsonSerializer.Serialize(value, jsonOptions).GetHashCode(),
                value => value == null
                    ? null
                    : JsonSerializer.Deserialize<List<TechnologyItem>>(
                        JsonSerializer.Serialize(value, jsonOptions),
                        jsonOptions));

            modelBuilder.Entity<Projects>()
                .Property(entity => entity.TechnologiesUsed)
                .HasColumnType("jsonb")
                .HasConversion(technologyListConverter)
                .Metadata.SetValueComparer(technologyListComparer);

            modelBuilder.Entity<Experiences>()
                .Property(entity => entity.TechnologiesUsed)
                .HasColumnType("jsonb")
                .HasConversion(technologyListConverter)
                .Metadata.SetValueComparer(technologyListComparer);

            modelBuilder.Entity<Certifications>()
                .Property(entity => entity.SkillsCovered)
                .HasColumnType("jsonb")
                .HasConversion(technologyListConverter)
                .Metadata.SetValueComparer(technologyListComparer);
        }
    }
}
