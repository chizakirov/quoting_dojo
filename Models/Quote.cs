using System;
using System.ComponentModel.DataAnnotations;

namespace quoting_dojo.Models
{
    public class Quote
    {
        // public int Id { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Author name must be at least 2 characters long")]
        public string Author { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Quote must be at least 10 characters long")]
        public string Content { get; set; }
        public Quote(){
          
        }
        public Quote(string name, string content){
          Author = name;
          Content = content;
        }

    }
}