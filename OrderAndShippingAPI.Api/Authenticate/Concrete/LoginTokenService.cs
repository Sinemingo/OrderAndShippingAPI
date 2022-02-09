using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OrderAndShippingAPI.Api.Authenticate.Abstract;
using OrderAndShippingAPI.Data.Abstract;
using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Concrete.Dtos;
using OrderAndShippingAPI.Entities.Utilities.Results.Concrete;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Api.Authenticate.Concrete
{
    public class LoginTokenService : ILoginTokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        public LoginTokenService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }
        public async Task<DataResult<User>> Authenticate(string email, string password)
        {
            try
            {
            var user = await _unitOfWork.Users.GetAsync(u=>u.Email==email & u.Password==password);
                if (user != null)
                {
                    string token = GetToken(user);
                    return new DataResult<User>(Entities.Abstract.Enums.EResultStatu.Success, user, token);
                }
                return new DataResult<User>(Entities.Abstract.Enums.EResultStatu.Error, null, "Kullanıcı Giriş Bilgileri Hatalı");
            }
            catch (System.Exception ex)
            {
                return new DataResult<User>(Entities.Abstract.Enums.EResultStatu.Error, null, ex.Message);
            }
        }
        private string GetToken(User user)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_appSettings.TokenPasswordKey);
                SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.UserId.ToString())
                    }),
                    Expires=System.DateTime.Now.AddDays(1),
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
                };
                SecurityToken token=tokenHandler.CreateToken(securityTokenDescriptor);
                string returnToken=tokenHandler.WriteToken(token);
                return returnToken;
            }
            catch (System.Exception)
            {
                return "Token Hatası";
            }
        }
    }
}
