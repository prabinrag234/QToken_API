using System.ComponentModel.DataAnnotations;

namespace QTokenAPI.DataTransferObject
{
    public class UserLoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
