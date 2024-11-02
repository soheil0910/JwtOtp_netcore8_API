using JwtOtp_netcore8_T2.Models;

namespace JwtOtp_netcore8_T2.Repositories
{
    public interface IRepositories
    {
        public JwtToken GetJwtToken();
        public bool RemoveUser_Otp(Users user);
        public Users GetUsers_Otp(string PhoneNumbe, int OtpCode);
        public bool SaveToken(string token, Platform Platf);

        public ResponseModel SetOtpCode(ResponseModel responseModel); 
        public bool saveUsers(Users user, string token);
    }
}
