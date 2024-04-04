using ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DTOs
{
    public class PostDTO
    {
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        [MaxLength(50)]
        public string Author { get; set; }

        public DateTime PublishDate { get; set; }

        // One post can contain multiple comments
        // Navigation property to represent the comments associated with this post
        public ICollection<CommentDTO> Comments { get; set; }
    }
}
