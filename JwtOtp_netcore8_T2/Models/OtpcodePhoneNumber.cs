using System.ComponentModel.DataAnnotations;

namespace JwtOtp_netcore8_T2.Models
{
    public class OtpcodePhoneNumber
    {
        [Required]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تلفن نامعتبر است")]
        [Phone]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"\d{5}$")]
        public int OtpCode { get; set; }



    }
}
