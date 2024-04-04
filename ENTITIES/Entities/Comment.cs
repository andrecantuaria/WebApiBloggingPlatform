using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        [MaxLength(50)]
        public string Author { get; set; } 

        public string Content { get; set; } 

        public DateTime CommentDate { get; set; }
 
    }
}
