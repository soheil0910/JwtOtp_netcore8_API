using System.ComponentModel.DataAnnotations;

namespace JwtOtp_netcore8_T2.Models
{
    public class PhoneNumber
    {
        [Required]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تلفن نامعتبر است")]
        [Phone]
        public string PhoneNumbers { get; set; }


    }
}
