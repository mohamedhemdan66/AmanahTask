using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanahTask.Core.Domain
{
     
    public class Author : BaseEntity
    {

        [Required,MaxLength(150)]
        public string Name { get; set; }

    }
}
