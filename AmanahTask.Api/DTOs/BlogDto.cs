using System;
using System.ComponentModel.DataAnnotations;

namespace AmanahTask.Api.DTOs
{
    public class BlogDto
    {
        public BlogDto()
        {
            this.CreationDate = DateTime.Now;
        }

        public int? Id { get; set; }  // allow null for Add Method

        [Required(ErrorMessage ="Required fild."), MaxLength(250,ErrorMessage ="Max length 250 letters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required fild.")]
        public string Body { get; set; }
        public DateTime? CreationDate { get; set; } // ? to allow null
        public int? AuthorId { get; set; }  // ? to allow null

    }
}
