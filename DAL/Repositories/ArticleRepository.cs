// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context) : base(context)
        { }


        //get all articles
        public IEnumerable<Article> GetAllArticlesData(int? categoryid)
        {
            if (categoryid == null)
            {
                return _appContext.Articles
                    .Include(c => c.category)
                    .Include(c => c.Comments)
                    .OrderBy(c => c.Name)
                    .ToList();
            }
            else 
            {
                return _appContext.Articles
                  .Include(c => c.category)
                  .Include(c => c.Comments)
                  .Where(a => a.CategoryId == categoryid)
                  .OrderBy(c => c.Name)
                  .ToList();
            }
        }
        //get all articles by category
        //public IEnumerable<Article> GetAllArticlesDataByCtegory(int id) 
        //{
        //    return _appContext.Articles
        //       .Include(c => c.category)
        //       .Include(c => c.Customer)
        //       .Include(c => c.Comments)
        //       .Where(a=>a.CategoryId==id)
        //       .OrderBy(c => c.Name)
        //       .ToList();
        //}
        //get article 
        public Article GetArticle(int id) 
        {
            return _appContext.Articles
                .Include(c => c.category)
                .Include(c => c.Comments)
                .Where(a=>a.Id==id).
                FirstOrDefault();
        }

        //add article
        public void AddArticle(string name ,string content ,int categoryId)
        {
            var article = new Article 
            { 
                Name=name,
                Content=content,
                CategoryId=categoryId
            };
            _appContext.Articles.Add(article);
            _appContext.SaveChanges();
        }

        //edit article
        public Article EditArticle(int id ,Article vm)
        {
            var article = GetArticle( id);
            article.Name = vm.Name;
            article.Content = vm.Content;
            article.CategoryId = vm.CategoryId;
            _appContext.Articles.Update(article);
            _appContext.SaveChanges();

            return article;
        }
        //add comment 
        public void AddComment(string content , int customerId, int articleId ) 
        {
            var comment = new Comment
            { 
                Content=content,
                CustomerId=customerId,
                ArticleId=articleId,
                IsApproved=false
            };
            _appContext.Comments.Add(comment);
            _appContext.SaveChanges();

        }
        //get comment
        public Comment GetComment( int id )
        {
            return _appContext.Comments
                .Include(a=>a.Article)
                .Include(a=>a.Customer)
                .FirstOrDefault(a=>a.Id==id);
        }
        //approve comment 
        public void ApproveComment(int id)
        {
            var comment = GetComment(id);
            comment.IsApproved = true;
            _appContext.Comments.Update(comment);
            _appContext.SaveChanges();
        }

        //disapprove comment
        public void DisApproveComment(int id, string? reason)
        {
            var comment = GetComment(id);

            if ( !string.IsNullOrEmpty(reason))
            {
                comment.IsApproved = false;
                comment.Reason = reason;
                _appContext.Comments.Update(comment);
                _appContext.SaveChanges();
            }
          
        }
        //get all category
        public IEnumerable<Category> GetAllCategories()
        {
            return _appContext.Categories
                .OrderBy(c => c.Name)
                .ToList();
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
