namespace Portfolio.Api.Models.DTOs
{
    public class TranslationBulkUpsertResponseDto
    {
        public int TotalReceived { get; set; }
        public int InsertedCount { get; set; }
        public int UpdatedCount { get; set; }
        public List<string> AffectedLanguageCodes { get; set; } = new();
    }
}
