using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickApp.ViewModels
{

    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
