using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project5.Models
{
    //Create the class movielists where we can hold all of the variables
    public class MovieLists
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
