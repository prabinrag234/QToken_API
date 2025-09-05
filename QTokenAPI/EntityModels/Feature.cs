using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QTokenAPI.EntityModels
{
    public class Feature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("user_name")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(80)]
        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        [Column("speciality")]
        public string Speciality { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        [Column("role")]
        public string Role { get; set; } = "user";
    }
}
