using AutoMapper;
using OrderAndShippingAPI.Data.Abstract;
using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Concrete.Dtos;
using OrderAndShippingAPI.Entities.Utilities.Results.Abstract;
using OrderAndShippingAPI.Entities.Utilities.Results.Concrete;
using OrderAndShippingAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        public async Task<IResult> Add(CategoryAddDto categoryAddDto)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{categoryAddDto.CategoryName} adlı kategori eklenmiştir.");
        }

        public async Task<IResult> Delete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.CategoryId == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{category.CategoryName} adlı kategori silinmiştir.");
            }
            return new Result(Entities.Abstract.Enums.EResultStatu.Error, $"{category.CategoryName} adlı kategori bulanamamıştır.");

        }

        public async Task<IDataResult<Category>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.CategoryId == categoryId, c => c.Products);
            if (category != null)
            {
                return new DataResult<Category>(Entities.Abstract.Enums.EResultStatu.Success, category);
            }
            return new DataResult<Category>(Entities.Abstract.Enums.EResultStatu.Error, null, "Kategori Bulunamadı!");
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Products);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(Entities.Abstract.Enums.EResultStatu.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = Entities.Abstract.Enums.EResultStatu.Success
                });
            }
            return new DataResult<CategoryListDto>(Entities.Abstract.Enums.EResultStatu.Error, null, "Kategorilere Ulaşılamadı!");
        }

        public Task<IResult> Update(Category categoryUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
