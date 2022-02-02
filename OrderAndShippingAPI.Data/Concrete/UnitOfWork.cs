using OrderAndShippingAPI.Data.Abstract;
using OrderAndShippingAPI.Data.Concrete.EFCore.Contexts;
using OrderAndShippingAPI.Data.Concrete.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderAndShippingContext _context;
        private EFCategoryRepository _categoryRepository;
        private EFProductRepository _productRepository;
        private EFOrderRepository _orderRepository;
        private EFOrderLineRepository _orderLineRepository;
        private EFUserRepository _userRepository;
        private EFRoleRepository _roleRepository;
        private EFShippingCompanyRepository _shippingCompanyRepository;
        public ICategoryRepository Categories => _categoryRepository ?? new EFCategoryRepository(_context);

        public IOrderRepository Orders => _orderRepository ?? new EFOrderRepository(_context);

        public IProductRepository Products => _productRepository ?? new EFProductRepository(_context);

        public IUserRepository Users => _userRepository ?? new EFUserRepository(_context);

        public IRoleRepository Roles => _roleRepository ?? new EFRoleRepository(_context);

        public IShippingCompanyRepository ShippingCompanies => _shippingCompanyRepository ?? new EFShippingCompanyRepository(_context);

        public IOrderLineRepository OrderLines => _orderLineRepository ?? new EFOrderLineRepository(_context);

        public UnitOfWork(OrderAndShippingContext context)
        {
            _context = context;
            _context.MigrationUpdate();
        }
      

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

       public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
