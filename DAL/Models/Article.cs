
using DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Article 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
