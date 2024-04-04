using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DTOs
{
    public class CommentDTO
    {
        [MaxLength(50)]
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
