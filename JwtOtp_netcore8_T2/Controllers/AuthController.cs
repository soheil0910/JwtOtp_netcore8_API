using JwtOtp_netcore8_T2.Repositories;
using JwtOtp_netcore8_T2.Models;
using JwtOtp_netcore8_T2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Emit;

namespace JwtOtp_netcore8_T2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        #region ForClass




        private IRepositories _repositoriy;
        //private static string _Token;
        private readonly IConfiguration _config;
        private readonly TokenService _tokService;
        private readonly IpAddressHelper _ipAddressHelper;
        private ResponseModel _responseModel;

        public AuthController(IConfiguration config, TokenService tokenService, IpAddressHelper ipAddressHelper, IRepositories repositori, ResponseModel responseModel)
        {
            _config = config;
            _tokService = tokenService;
            _ipAddressHelper = ipAddressHelper;
            _repositoriy = repositori;
            _responseModel = responseModel;
        }
        #endregion

        #region GetToken

        [HttpGet("GetToken")]
        public ActionResult GetToken(Platform Platforms)
        {

            string TypePlatform = Platforms.ToString();
            var token = _tokService.GenerateToken(TypePlatform);
            _repositoriy.SaveToken(token, Platforms);
            var resalt = new JsonResult
                (new ResponseModel
                {
                    Status = true,
                    StatusNum = 200,
                    Title = "موفق",
                    Description = "توکن کاربری شما ساخته شده و به مدت یک هفته معتبر  است ",
                    value = token

                });
            return resalt;

        }
        #endregion




        #region SendOTP
        private static DateTime? TimeSms = null;
        [Authorize]
        [HttpPost("SendOTP")]
        public IActionResult SendOTP([FromBody] PhoneNumber number)
        {

            _responseModel = _repositoriy.SetOtpCode(_responseModel);


            return StatusCode(_responseModel.StatusNum, _responseModel);


            #region ChekTimeOtpCode

            if (TimeSms != null && TimeSms >= DateTime.Now)
            {
                var minestime = DateTime.Now - TimeSms;

                if (TimeSms <= DateTime.Now)
                {
                    TimeSms = null;
                }
                var resaltt = new JsonResult
                    (new ResponseModel
                    {
                        Status = false,
                        StatusNum = 400,
                        Title = "ناموفق",
                        Description = "لطفا بعد از این زمان مجدد تلاش فرمایید  ما سرور را از سر راه نیاورده ایم ",
                        value = minestime?.ToString("'m'm 's's'")

                    });

                return resaltt;
            }
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); ;
            #endregion



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.ErrorCount);
            }
            Random OtpCodeCreate = new Random();
            var _OtpCode = OtpCodeCreate.Next(10000, 99999);
            var IpAddress = _ipAddressHelper.GetClientIpAddress();

            Users users = new Users()
            {
                IP = IpAddress,
                OtpCode = _OtpCode,
                PhoneNumb = number.PhoneNumbers,


            };


            if (!_repositoriy.saveUsers(users, token))
            {
                return StatusCode(500, "مشکل ای از سمت سرور رخ داده");

            }





            TimeSms = DateTime.Now.AddMinutes(2);
            //return Ok(TimeSms.Value);






            _responseModel.StatusNum = 200;
            _responseModel.Status = true;
            _responseModel.Title = "موفق";
            _responseModel.Description = "کد برای شما ارسال شد اعتبار 2 دقیقه! ";
            _responseModel.value = _OtpCode;
            return Ok(_responseModel);





            //return Ok("Your Ip:" + IpAddress + "\nCode Sms:" + _OtpCode);
            //return Ok(_OtpCode);
        }
        #endregion


        #region ChekOtp

        [HttpPost("ChekOtp")]
        public ActionResult ChekOtp([FromBody] OtpcodePhoneNumber OtpPhonUser)
        {
            var user = _repositoriy.GetUsers_Otp(OtpPhonUser.PhoneNumber, OtpPhonUser.OtpCode);


            if (null != user)
            {
                _repositoriy.RemoveUser_Otp(user);
                var resaltok = new JsonResult
                    (new ResponseModel
                    {
                        Status = true,
                        StatusNum = 200,
                        Title = "موفق ",
                        Description = "کد وارد شده درست است "

                    });
                return resaltok;
            }
            var resalt = new JsonResult
    (new ResponseModel
    {
        Status = false,
        StatusNum = 500,
        Title = "ناموفق ",
        Description = "کد وارد شده درست نیست "

    });



            return resalt;


        }

        #endregion






    }
}
