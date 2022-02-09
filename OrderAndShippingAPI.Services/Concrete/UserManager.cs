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
    public class UserManager : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> Add(UserAddDto userAddDto)
        {
            var user = _mapper.Map<User>(userAddDto);
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();
            return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{userAddDto} adlı kullanıcı eklenmiştir.");

        }

        public async Task<IResult> Delete(int userId)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.UserId == userId);
            if (user != null)
            {
                await _unitOfWork.Users.DeleteAsync(user);
                await _unitOfWork.SaveAsync();
                return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{user.UserName} adlı kullanıcı silinmiştir.");
            }
            return new Result(Entities.Abstract.Enums.EResultStatu.Error, $"{user.UserName} adlı kullanıcı bulanamamıştır.");

        }

        public async Task<IDataResult<UserDto>> Get(int userId)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.UserId == userId, u => u.Role);
            if (user != null)
            {
                return new DataResult<UserDto>(Entities.Abstract.Enums.EResultStatu.Success, new UserDto
                {
                    User = user,
                    ResultStatus = Entities.Abstract.Enums.EResultStatu.Success
                });
            }
            return new DataResult<UserDto>(Entities.Abstract.Enums.EResultStatu.Error, null, "Kullanıcı Bulunamadı!");
        }

        public async Task<IDataResult<UserDto>> Get(string email,string password)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.Email == email, u => u.Password==password);
            if (user != null)
            {
                return new DataResult<UserDto>(Entities.Abstract.Enums.EResultStatu.Success, new UserDto
                {
                    User = user,
                    ResultStatus = Entities.Abstract.Enums.EResultStatu.Success
                });
            }
            return new DataResult<UserDto>(Entities.Abstract.Enums.EResultStatu.Error, null, "Kullanıcı Bulunamadı!");
        }

        public async Task<IDataResult<UserListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(User userUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
