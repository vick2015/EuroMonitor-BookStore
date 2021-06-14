using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Models
{
    public class OrderEntity
    {
        [Key]
        public Guid OrderID { get; set; }

        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public DateTime OrderDateTime { get; set; }

    }
}
