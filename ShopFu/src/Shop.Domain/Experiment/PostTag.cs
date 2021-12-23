using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Experiment
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public List<PostTag> PostTags { get; set; }
    }

    public class Tag
    {
        public string TagId { get; set; }

        public ICollection<Post> Posts { get; set; }
        public List<PostTag> PostTags { get; set; }
    }

    public class PostTag
    {
        public DateTime PublicationDate { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
