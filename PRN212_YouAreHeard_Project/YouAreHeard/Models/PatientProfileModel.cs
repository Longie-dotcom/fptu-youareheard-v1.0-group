namespace YouAreHeard.Models
{
    public class PatientProfileModel
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public List<string>? Conditions { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Pregnancy { get; set; }
        public string Phone {  get; set; }
        public string HIVStatus { get; set; }
    }
}
