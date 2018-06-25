using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.Model
{
    public class BookRepo
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [Display (Name="Book Name")]
        public string Name { get; set; }

        [Required]
        public BookType Type { get; set; }
    }
}
