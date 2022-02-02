using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Concrete.Dtos;
using OrderAndShippingAPI.Entities.Utilities.Results.Concrete;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Api.Authenticate.Abstract
{
    public interface ILoginTokenService
    {
        Task<DataResult<User>> Authenticate(string email, string password);
    }
}
