using JwtOtp_netcore8_T2.Models;
using JwtOtp_netcore8_T2.Models.PCN;

namespace JwtOtp_netcore8_T2.Repositories
{
    public interface IRepositories
    {
        public JwtToken GetJwtToken();
        public bool RemoveUser_Otp(Users user);
        public Users GetUsers_Otp(string PhoneNumbe, int OtpCode);
        public bool SaveToken(string token, Platform Platf);

        public ResultApiDto SetOtpCode(ResultApiDto responseModel, PhoneNumber number, string token); 
        public bool saveUsers(Users user, string token);


        public ResultApiDto serch(ResultApiDto responseModel, string Neighborh);
        public ResultApiDto GetCity(ResultApiDto responseModel,int provinceId);
        public ResultApiDto GetNeighborhood(ResultApiDto responseModel,int CityId);
        public ResultApiDto GetProvince(ResultApiDto responseModel);
        public List<Province> GetAllProvince();


    }
}
