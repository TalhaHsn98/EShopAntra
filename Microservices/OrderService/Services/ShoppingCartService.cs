using AutoMapper;
using OrderService.DTO;
using OrderService.Models;
using OrderService.RepositoryContracts;
using OrderService.ServiceContracts;

namespace OrderService.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _carts;
        private readonly IRepository<ShoppingCartItem> _items;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ShoppingCartService(IShoppingCartRepository carts, IRepository<ShoppingCartItem> items, IUnitOfWork uow, IMapper mapper)
        {
            _carts = carts; _items = items; _uow = uow; _mapper = mapper;
        }

        public Task<ShoppingCart?> GetByCustomerIdAsync(int customerId) => _carts.GetByCustomerIdAsync(customerId);

        public async Task<int> SaveAsync(ShoppingCart cart)
        {
            var existing = await _carts.GetByCustomerIdAsync(cart.CustomerId);
            if (existing is null) await _carts.AddAsync(cart);
            else
            {
                existing.CustomerName = cart.CustomerName;
                await _items.DeleteRangeAsync(existing.Items);
                existing.Items = cart.Items ?? new List<ShoppingCartItem>();
                await _carts.UpdateAsync(existing);
            }
            return await _uow.SaveChangesAsync();
        }

        public async Task<int> SaveAsync(ShoppingCartCreateRequest dto)
        {
            var cart = _mapper.Map<ShoppingCart>(dto);
            return await SaveAsync(cart);
        }

        public async Task<bool> DeleteAsync(int cartId)
        {
            var cart = await _carts.GetByIdAsync(cartId);
            if (cart is null) return false;
            await _carts.DeleteAsync(cart);
            await _uow.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            var item = await _items.GetByIdAsync(itemId);
            if (item is null) return false;
            await _items.DeleteAsync(item);
            await _uow.SaveChangesAsync();
            return true;
        }
    }

}
