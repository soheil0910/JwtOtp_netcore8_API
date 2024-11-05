using JwtOtp_netcore8_T2.Data;
using JwtOtp_netcore8_T2.Models;
using JwtOtp_netcore8_T2.Models.PCN;
using JwtOtp_netcore8_T2.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using System.Linq;
using System.Reflection.Emit;
using System.Web.Http.ModelBinding;

namespace JwtOtp_netcore8_T2.Repositories
{
    public class Repositories : IRepositories
    {
        private JwtOtpContext _DbContext;
        private readonly IpAddressHelper _ipAddressHelper;
        public Repositories(JwtOtpContext DbContext, IpAddressHelper ipAddressHelper)
        {
            _DbContext = DbContext;
            _ipAddressHelper = ipAddressHelper;
        }

        public JwtToken GetJwtToken()
        {
            throw new NotImplementedException();
        }


        public ResultApiDto serch(ResultApiDto responseModel, string Neighborh)
        {


            try
            {
                responseModel.Description = "موفق";
                responseModel.Title = "موفق";
                responseModel.Status = true;
                responseModel.StatusNum = 200;
                responseModel.value = _DbContext.Neighborhood.Where(x=> x.Name.Contains(Neighborh)).Include(c => c.city).ToList();
                return responseModel;
            }
            catch (Exception ex)
            {

                responseModel.Description = ex.Message;
                responseModel.Title = "خطا";
                responseModel.Status = false;
                responseModel.StatusNum = 400;
                return responseModel;
            }

            
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


        private static DateTime? TimeSms = null;
        public ResultApiDto SetOtpCode(ResultApiDto responseModel, PhoneNumber number, string token)
        {

            try
            {
                #region ChekTimeOtpCode

                if (TimeSms != null && TimeSms >= DateTime.Now)
                {
                    var minestime = TimeSms - DateTime.Now;

                    if (TimeSms <= DateTime.Now)
                    {
                        TimeSms = null;
                    }
                  
                    responseModel.Description = "لطفا بعد از این زمان مجدد تلاش فرمایید  ما سرور را از سر راه نیاورده ایم ";
                    responseModel.Title = "ناموفق";
                    responseModel.Status = false;
                    responseModel.StatusNum = 400;
                    responseModel.value = minestime?.ToString("m'm 's's'");
                    return responseModel;

                };
                #endregion


                Random OtpCodeCreate = new Random();
                var _OtpCode = OtpCodeCreate.Next(10000, 99999);
                var IpAddress = _ipAddressHelper.GetClientIpAddress();
                Users users = new Users()
                {
                    IP = IpAddress,
                    OtpCode = _OtpCode,
                    PhoneNumb = number.PhoneNumbers,


                };


                TimeSms = DateTime.Now.AddMinutes(2);
                if (!saveUsers(users, token))
                {
                    throw new ArgumentException(nameof(saveUsers));

                }

                responseModel.Description = "موفق";
                responseModel.Title = "موفق";
                responseModel.Status = true;
                responseModel.StatusNum = 200;
                responseModel.value = _OtpCode;
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




        public ResultApiDto GetCity(ResultApiDto responseModel, int provinceId)
        {
            try
            {
                responseModel.Description = "موفق";
                responseModel.Title = "موفق";
                responseModel.Status = true;
                responseModel.StatusNum = 200;
                responseModel.value = _DbContext.City.Where(x => x.provinceId == provinceId).ToList();
                return responseModel;
            }
            catch (Exception ex)
            {

                responseModel.Description = ex.Message;
                responseModel.Title = "خطا";
                responseModel.Status = false;
                responseModel.StatusNum = 400;
                return responseModel;
            }

            
        }

        public ResultApiDto GetNeighborhood(ResultApiDto responseModel, int CityId)
        {
            



            try
            {
                responseModel.Description = "موفق";
                responseModel.Title = "موفق";
                responseModel.Status = true;
                responseModel.StatusNum = 200;
                responseModel.value = _DbContext.Neighborhood.Where(x => x.CityId == CityId).ToList();
                return responseModel;
            }
            catch (Exception ex)
            {

                responseModel.Description = ex.Message;
                responseModel.Title = "خطا";
                responseModel.Status = false;
                responseModel.StatusNum = 400;
                return responseModel;
            }

          

        }

        public ResultApiDto GetProvince(ResultApiDto responseModel)
        {

            try
            {
                responseModel.Description = "موفق";
                responseModel.Title = "موفق";
                responseModel.Status = true;
                responseModel.StatusNum = 200;
                responseModel.value = _DbContext.Province.ToList();
                return responseModel;
            }
            catch (Exception ex)
            {

                responseModel.Description = ex.Message;
                responseModel.Title = "خطا";
                responseModel.Status = false;
                responseModel.StatusNum = 400;               
                return responseModel;
            }
           

        }

        public List<Province> GetAllProvince()
        {
          return _DbContext.Province.ToList();
        }
    }
}
