using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Concrete.Dtos;
using OrderAndShippingAPI.Entities.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Services.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<Product>> Get(int productId);
        Task<IDataResult<IList<Product>>> GetAll();
        Task<IDataResult<IList<Product>>> GetAllByCategory(int categoryId);
        Task<IResult> Add(ProductAddDto productAddDto);
        Task<IResult> Update(Product productUpdateDto);
        Task<IResult> Delete(int productId);
    }
}
