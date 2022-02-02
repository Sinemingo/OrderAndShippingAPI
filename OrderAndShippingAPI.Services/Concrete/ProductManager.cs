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
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper= mapper;
        }
        public async Task<IResult> Add(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{productAddDto.ProductName} adlı ürün eklenmiştir.");

        }

        public async Task<IResult> Delete(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(c => c.ProductId == productId);
            if (product != null)
            {
                await _unitOfWork.Products.DeleteAsync(product);
                await _unitOfWork.SaveAsync();
                return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{product.ProductName} adlı ürün silinmiştir.");
            }
            return new Result(Entities.Abstract.Enums.EResultStatu.Error, $"{product.ProductName} adlı ürün bulanamamıştır.");

        }

        public async Task<IDataResult<ProductDto>> Get(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync( p=> p.ProductId == productId, p => p.Category);
            if (product != null)
            {
                return new DataResult<ProductDto>(Entities.Abstract.Enums.EResultStatu.Success, new ProductDto
                {
                    Product=product,
                    ResultStatus= Entities.Abstract.Enums.EResultStatu.Success
                });
            }
            return new DataResult<ProductDto>(Entities.Abstract.Enums.EResultStatu.Error,null, "Ürün Bulunamadı!");
        }

        public async Task<IDataResult<ProductListDto>> GetAll()
        {
            var products =await _unitOfWork.Products.GetAllAsync(null,p=>p.Category);
            if (products.Count>-1)
            {
                return new DataResult<ProductListDto>(Entities.Abstract.Enums.EResultStatu.Success, new ProductListDto
                {
                 Products=products,
                 ResultStatus= Entities.Abstract.Enums.EResultStatu.Success
                });
            }
            return new DataResult<ProductListDto>(Entities.Abstract.Enums.EResultStatu.Error, null, "Ürünler Bulunamadı!");
        }

        public async Task<IDataResult<ProductListDto>> GetAllByCategory(int categoryId)
        {
            var result=await _unitOfWork.Products.AnyAsync(p=>p.CategoryId== categoryId);
            if (result)
            {
                var products = await _unitOfWork.Products.GetAllAsync(p => p.CategoryId == categoryId, p => p.Category);
                if (products.Count > -1)
                {
                    return new DataResult<ProductListDto>(Entities.Abstract.Enums.EResultStatu.Success, new ProductListDto
                    {
                        Products = products,
                        ResultStatus = Entities.Abstract.Enums.EResultStatu.Success
                    });
                }
                return new DataResult<ProductListDto>(Entities.Abstract.Enums.EResultStatu.Error, null, "Ürünler Bulunamadı!");
            }
            return new DataResult<ProductListDto>(Entities.Abstract.Enums.EResultStatu.Error, null, "Böyle Bir Kategori Bulunamadı!");
        }

        public async Task<IResult> Update(ProductUpdateDto productUpdateDto)
        {
            
            var product = await _unitOfWork.Products.GetAsync(p => p.ProductId == productUpdateDto.ProductId);
            if (product != null)
            {
                product = _mapper.Map<Product>(productUpdateDto);
                await _unitOfWork.Products.UpdateAsync(product);
                await _unitOfWork.SaveAsync();
                return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{productUpdateDto.ProductName} adlı ürün güncellenmiştir.");
            }
            return new Result(Entities.Abstract.Enums.EResultStatu.Error, $"{productUpdateDto.ProductName} adlı ürün bulanamamıştır.");

        }
    }
}
