using JwtOtp_netcore8_T2.Data;
using JwtOtp_netcore8_T2.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using System.Web.Http.ModelBinding;

namespace JwtOtp_netcore8_T2.Repositories
{
    public class Repositories : IRepositories
    {
        private JwtOtpContext _DbContext;
        public Repositories(JwtOtpContext DbContext)
        {
            _DbContext = DbContext;
        }

        public JwtToken GetJwtToken()
        {
            throw new NotImplementedException();
        }

        public Users GetUsers_Otp(string PhoneNumbe, int OtpCode)
        {
            return _DbContext.Users.FirstOrDefault(c => c.PhoneNumb == PhoneNumbe && c.OtpCode == OtpCode);

        }

        public bool RemoveUser_Otp(Users user)
        {
            _DbContext.Users.Remove(user);
            _DbContext.SaveChanges();
            return true;
        }

        public bool SaveToken(string token, Platform Platf)
        {
            _DbContext.JwtToken.Add(new JwtToken { Token = token, platform = Platf });
            _DbContext.SaveChanges();
            return true;
        }



        public bool saveUsers(Users user, string token)
        {
            var tok = _DbContext.JwtToken.FirstOrDefault(x => x.Token == token);
            if (tok == null)
            {
                return false;
            }
            try
            {
                _DbContext.Users.Add(new Users()
                {
                    IP = user.IP,
                    JwtToken_ID = tok.Id,
                    OtpCode = user.OtpCode,
                    PhoneNumb = user.PhoneNumb,


                });
                _DbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public ResponseModel SetOtpCode(ResponseModel responseModel)
        {

            try
            {
                responseModel.Description = "موفق";
                responseModel.Title = "موفق";
                responseModel.Status = true;
                responseModel.StatusNum = 200;
                responseModel.value = 2 + 5;
                return responseModel;

            }
            catch (Exception e)
            {
                responseModel.Description = e.Message;
                responseModel.Title = "خطا";
                responseModel.Status = false;
                responseModel.StatusNum = 500;
                return responseModel;
            }


        }
    }
}
