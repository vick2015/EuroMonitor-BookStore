using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BookStore.Models;


namespace BookStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly BookDBContext myDbContext;
        private readonly IConfigurationProvider myConfigurationProvider;

        public OrderService(BookDBContext dbContext , IConfigurationProvider configurationProvider)
        {
            myDbContext = dbContext;
            myConfigurationProvider = configurationProvider;
        }

        public async Task<Order> BuyBook(Guid bookId, Guid userId)
        {
            var orderId = Guid.NewGuid();
            var orderEntity = new OrderEntity() {BookId = bookId, OrderDateTime = DateTime.Now, OrderID = orderId, UserId = userId};
            myDbContext.OrderEntity.Add(orderEntity);
            await myDbContext.SaveChangesAsync();

            var mapper = myConfigurationProvider.CreateMapper();
            return mapper.Map<Order>(orderEntity);
        }

        public List<Order> FindOrdersByUser(Guid userId)
        {
            var orderEntities = myDbContext.OrderEntity.Where(a => a.UserId == userId);
            return orderEntities.ProjectTo<Order>(myConfigurationProvider).ToList();
        }
    }

    public interface IOrderService
    {
        Task<Order> BuyBook(Guid bookId, Guid userId);

        List<Order> FindOrdersByUser(Guid userId);
    }
}
