namespace QTokenAPI.EntityModels
{
    public class User
    {
        public int UserID { get; set; }                     // Primary key
        public string ?Name { get; set; }            // Full name of the user
        public string ?UserName { get; set; }            // Unique username
        public string ?Password { get; set; }        // Hashed password
        public string ?Speciality { get; set; }               // Optional email
        public string ?Role { get; set; }    // Specialty field
    }
}