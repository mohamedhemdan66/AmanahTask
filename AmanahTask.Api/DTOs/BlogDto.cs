using System;
using System.ComponentModel.DataAnnotations;

namespace AmanahTask.Api.DTOs
{
    public class BlogDto
    {
        public int Id { get; set; }  

        [Required(ErrorMessage ="Required fild."), MaxLength(250,ErrorMessage ="Max length 250 letters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required fild.")]
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }

        //public BlogDto()
        //{
        //    this.CreationDate = DateTime.Now;
        //}

    }
}
