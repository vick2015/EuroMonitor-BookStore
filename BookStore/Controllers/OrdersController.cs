using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookStore.Models;
using BookStore.Services;
using BookStore.Stores;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


namespace BookStore.Controllers
{
    [Route("/[controller]")]
    [Authorize]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBookService myBookService;
        private readonly IOrderService myOrderService;

        public OrdersController(IBookService bookService , IOrderService orderService)
        {
            myBookService = bookService;
            myOrderService = orderService;
        }

        [HttpPost(Name = nameof(PostUserOrder))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Order>> PostUserOrder([FromBody] OrderRequestDto orderRequestDto)
        {
            var userFound = Users.GetValidUserEntities().Where(a => a.UserId == orderRequestDto.UserId);

            if (!userFound.Any())
            {
                return NotFound();
            }

            var book = myBookService.GetBookById(orderRequestDto.BookId);
            if (book == null)
            {
                return NotFound();
            }

            var order = await myOrderService.BuyBook(orderRequestDto.BookId, orderRequestDto.UserId);

            return Ok(order);
        }

        [HttpGet(Name= nameof(GetOrdersByUser))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public ActionResult<List<Order>> GetOrdersByUser([FromQuery] string userId)
        {
            var userGuid = Guid.Parse(userId);
            var userFound = Users.GetValidUserEntities().Where(a => a.UserId == userGuid);

            if (!userFound.Any())
            {
                return NotFound();
            }

            var orderList = myOrderService.FindOrdersByUser(userGuid);

            return Ok(orderList);
        }
    }
}
