using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using App.Services;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace App.Helpers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            this.userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // if (!Request.Headers.ContainsKey(UserService.AUTH_COOKIE_NAME))
            //     return AuthenticateResult.Fail("Missing Authorization Header");
            if (!Request.Cookies.ContainsKey(UserService.AUTH_COOKIE_NAME))
                return AuthenticateResult.Fail("Missing Authorization Header");

            User user = null;

            try
            {
                // TODO: try to use Request.Cookies.Keys
                // var authHeader = AuthenticationHeaderValue.Parse(Request.Headers[UserService.AUTH_COOKIE_NAME]);
                // var credentialBytes = Convert.FromBase64String(authHeader.Parameter);

                // user = userService.GetUserByAuthToken(Encoding.UTF8.GetString(credentialBytes));
                var authCookie = Request.Cookies[UserService.AUTH_COOKIE_NAME];

                user = userService.GetUserByAuthToken(authCookie);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null)
                return AuthenticateResult.Fail("Invalid Username or Password");

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}