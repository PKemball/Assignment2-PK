using Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BlogType : BaseType
    {
        public BlogType(Status status, string name, string description)
            : base(status, name, description)
        {
            Blogs = new List<Blog>();
        }

        public List<Blog> Blogs { get; set; }
    }
}
