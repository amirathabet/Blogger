
using DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Comment 
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
    }
}
