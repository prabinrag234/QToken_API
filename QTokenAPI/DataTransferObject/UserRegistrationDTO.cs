using System.ComponentModel.DataAnnotations;

namespace QTokenAPI.DataTransferObject
{
    public class UserRegistrationDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(80)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string Speciality { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Role { get; set; } = "user";
    }
}
