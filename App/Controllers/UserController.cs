using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Datas;
using Domain;
using Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.Services;
using Microsoft.Extensions.Options;
using App.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetLoggedUser()
        {
            try
            {
                return Ok(userService.GetLoggedUserData());
            }
            catch (Exception ex)
            {
                return Json(BadRequest(ex));
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]UserLoginData userLogin)
        {
            try
            {
                var authToken = await userService.LoginAsync(userLogin);
                var cookieOption = new CookieOptions();

                cookieOption.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Append(UserService.AUTH_COOKIE_NAME, authToken);

                return Ok(new { authToken = authToken });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(Json(new { error = "true" }));
            }
            catch (Exception ex)
            {
                return BadRequest(Json(ex));
            }
        }


        [HttpPost("create-and-login")]
        public async Task<ActionResult> SaveAndLogin(NewUserData newUser)
        {
            try
            {
                await userService.SaveAsync(newUser);
                var userData = await userService.LoginAsync(newUser.ToLoginData());

                return Ok(userData);
            }
            catch (Exception ex)
            {
                return BadRequest(Json(ex));
            }
        }
    }
}
