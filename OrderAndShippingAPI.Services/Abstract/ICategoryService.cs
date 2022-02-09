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
    public interface ICategoryService
    {
        Task<IDataResult<Category>> Get(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IResult> Add(CategoryAddDto categoryAddDto);
        Task<IResult> Update(Category categoryUpdateDto);
        Task<IResult> Delete(int categoryId);
    }
}
