using JwtOtp_netcore8_T2.Repositories;
using JwtOtp_netcore8_T2.Models;
using JwtOtp_netcore8_T2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Emit;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using JwtOtp_netcore8_T2.Models.PCN;
using System.Text.Json;

namespace JwtOtp_netcore8_T2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        #region ForClass



        //IServiceProvider _serviceProvider;

        private IRepositories _repositoriy;
        
        //private readonly IConfiguration _config;
        private readonly TokenService _tokService;

        private ResultApiDto _responseModel;

        public AuthController(
             TokenService tokenService,
             IRepositories repositori,
            ResultApiDto responseModel
            //IConfiguration config,
           //, IServiceProvider serviceProvider
            )
        {
            //_serviceProvider = serviceProvider;
            //_config = config;
            //_ipAddressHelper = ipAddressHelper;
            _tokService = tokenService;
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
                (new ResultApiDto
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
        [Authorize]
        [HttpPost("SendOTP")]
        public IActionResult SendOTP([FromBody] PhoneNumber number)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); ;
            _responseModel = _repositoriy.SetOtpCode(_responseModel, number, token);
            return StatusCode(_responseModel.StatusNum, _responseModel);

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
                    (new ResultApiDto
                    {
                        Status = true,
                        StatusNum = 200,
                        Title = "موفق ",
                        Description = "کد وارد شده درست است "

                    });
                return resaltok;
            }
            var resalt = new JsonResult
    (new ResultApiDto
    {
        Status = false,
        StatusNum = 500,
        Title = "ناموفق ",
        Description = "کد وارد شده درست نیست "

    });



            return resalt;


        }

        #endregion


        #region serch

        [HttpPost("serch")]
        public ActionResult serch([FromBody] string Neighborh)
        {
            _responseModel = _repositoriy.serch(_responseModel, Neighborh);
            return StatusCode(_responseModel.StatusNum, _responseModel);

        }


        #endregion

        #region Get DataShahr 

        [HttpGet("GetProvince")]
        public IActionResult GetProvince()
        {

            _responseModel = _repositoriy.GetProvince(_responseModel);
            return StatusCode(_responseModel.StatusNum, _responseModel);

           
        }

        [HttpGet("GetGetCity")]
        public IActionResult GetGetCity(int provinceId)
        {

            _responseModel = _repositoriy.GetCity(_responseModel, provinceId);
            return StatusCode(_responseModel.StatusNum, _responseModel);

           
        }

        [HttpGet("GetNeighborhood")]
        public IActionResult GetNeighborhood(int CityId)
        {
            _responseModel = _repositoriy.GetNeighborhood(_responseModel, CityId);
            return StatusCode(_responseModel.StatusNum, _responseModel);


        }


        #endregion




       
    }
}
