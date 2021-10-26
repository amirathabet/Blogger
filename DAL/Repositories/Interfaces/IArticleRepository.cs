
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable<Article> GetAllArticlesData(int? categoryid);
        //IEnumerable<Article> GetAllArticlesDataByCtegory(int id);
        Article GetArticle(int id);
        void AddArticle(string name, string content, int categoryId);
        Article EditArticle(int id, Article vm);
        void AddComment(string content, int customerId, int articleId);
        Comment GetComment(int id);
        void ApproveComment(int id);
        public void DisApproveComment(int id, string? reason);
        IEnumerable<Category> GetAllCategories();
    }
}
