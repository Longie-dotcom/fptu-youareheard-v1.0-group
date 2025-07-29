namespace YouAreHeard.Models
{
    public class DoctorProfileModel
    {
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Specialization { get; set; }
        public bool IsActive { get; set; }
    }
}