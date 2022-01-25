using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanahTask.Core.Domain
{
    public class Blog : BaseEntity
    {

        [Required,MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public int? AuthorId { get; set; } //foregin key ? operator to allow null 

        // Navigation Properties 'Relations'
        public Author Author { get; set; } 
    }
}
