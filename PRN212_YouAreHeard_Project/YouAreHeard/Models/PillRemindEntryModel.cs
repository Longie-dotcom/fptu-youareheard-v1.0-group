namespace YouAreHeard.Models
{
    public class PillRemindEntryModel
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Dosage { get; set; }
        public TimeOnly Time
        {
            get => new TimeOnly(Hour, Minute);
            set
            {
                Hour = value.Hour;
                Minute = value.Minute;
            }
        }
    }
}
