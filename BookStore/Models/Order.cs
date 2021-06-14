using System;


namespace BookStore.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }

        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public string OrderDateTime { get; set; }
    }
}