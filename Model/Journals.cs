using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.Model
{
    public class Journals
    {
        [Key]
        public int JournalId { get; set; }

        [Display(Name = "Journal Name")]
        [Required, MaxLength(45)]
        public string JName { get; set; }

        [Display(Name = "Journal Subject")]
        [Required]
        public string JSubject { get; set; }

        [Display(Name="Journal Type")]
        public JournalType Jtype { get; set; }
    }
}
