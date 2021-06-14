using System;


namespace BookStore.Models
{
    public class OrderRequestDto
    {
        public Guid BookId { get; set; }

        public Guid UserId { get; set; }
    }
}