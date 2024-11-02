using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtOtp_netcore8_T2.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PhoneNumb { get; set; }
        [Required]
        public int OtpCode { get; set; }
        [Required]
        public string IP { get; set; }
        [Required]
        public int JwtToken_ID { get; set; }
        [ForeignKey("JwtToken_ID")]
        public JwtToken JwtToken { get; set; }
    }
}
