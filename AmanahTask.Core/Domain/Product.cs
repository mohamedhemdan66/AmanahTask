using AmanahTask.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanahTask.Core.Domain
{
    public class Product : BaseEntity
    {
        [Required,MaxLength(180)]
        public string Name {get;set;}
        public DateTime  Date {get;set;}
        public Color  Color {get;set;}
        public double  Price {get;set;}
        public string  Comment {get;set;} 
        public int  CategoryId {get;set;}

        public Category Category { get; set; }
    }
}
