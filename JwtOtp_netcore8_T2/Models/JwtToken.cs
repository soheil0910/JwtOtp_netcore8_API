namespace JwtOtp_netcore8_T2.Models
{
    public class JwtToken
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public Platform platform { get; set; }

        //public int UsersId { get; set; }
        //public Users user { get; set; }
    }
}
