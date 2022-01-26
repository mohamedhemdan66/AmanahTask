using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanahTask.Core.Domain
{
    public class Category : BaseEntity
    {
        [Required,MaxLength(180)]
        public string Name { get; set; } 
    }
}
