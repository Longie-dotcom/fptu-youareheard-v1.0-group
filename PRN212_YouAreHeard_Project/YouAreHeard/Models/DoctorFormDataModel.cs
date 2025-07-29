using System;

namespace YouAreHeard.Models
{
    public class DoctorFormDataModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Phone { get; set; }

        public int RoleId { get; set; }
        public string Specialties { get; set; }
        public int YearsOfExperience { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string LanguagesSpoken { get; set; }
    }
}
