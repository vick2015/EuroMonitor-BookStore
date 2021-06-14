using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace BookStore.Models
{
    public class BookEntity
    {
        [Key]
        public Guid BookId { get; set; }

        public string BookName { get; set; }

        //public string ImageUrl { get; set; }

        public string BookDescription { get; set; }

        public string AuthorName { get; set; }

        public double Cost { get; set; }
    }
}
