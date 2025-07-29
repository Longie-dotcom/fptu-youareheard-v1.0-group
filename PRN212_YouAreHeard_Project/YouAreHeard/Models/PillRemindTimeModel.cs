namespace YouAreHeard.Models
{
    public class PillRemindTimeModel
    {
        public int? MedicationId { get; set; }
        public string MedicationName { get; set; }
        public string DosageMetric { get; set; }
        public int? Frequency { get; set; }
        public string Notes { get; set; }
        public List<PillRemindEntryModel> RemindEntries { get; set; } = new();
    }
}
