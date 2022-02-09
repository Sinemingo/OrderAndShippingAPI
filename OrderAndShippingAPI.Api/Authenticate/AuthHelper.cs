using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace OrderAndShippingAPI.Api.Authenticate
{
    public static class AuthHelper
    {
        private static string UserId(ControllerBase controller)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                string authHeader = "" + controller.Request.Headers["Authorization"];

                authHeader = authHeader.Replace("Bearer ", "");
                //var jsonToken=handler.ReadToken(authHeader);

                var decodeValue = handler.ReadJwtToken(authHeader);
                string unique_name = "";
                foreach (var item in decodeValue.Claims)
                {
                    if (item.Type=="unique_name")
                    {
                        unique_name = item.Value;
                        break;
                    }
                }
                return unique_name;
            }
            catch (System.Exception)
            {
                return "";
            }
        }

        public static string AuthValid(ControllerBase controller)
        {
            string userId=UserId(controller);
            if (string.IsNullOrEmpty(userId))
            {
               throw new UnauthorizedAccessException("TokenKey could not be resolved");
               
            }
            return userId;
        }
    }
}
