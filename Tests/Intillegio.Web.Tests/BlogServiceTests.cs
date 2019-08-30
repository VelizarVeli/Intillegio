using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Data.Data;
using Intillegio.Models;
using Intillegio.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Intillegio.Web.Tests
{
   public class BlogServiceTests
    {
        [Fact]
        public void GetAllCategoriesShouldReturnCategories()
        {
            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Categories_Db")
                .Options;

            var dbContext = new IntillegioContext(options);

            var categoriesCount = 4;
            var compareCategories = new List<Category>();
            for (int i = 0; i < categoriesCount; i++)
            {
                var category = new Category();
                dbContext.Categories.Add(category);
                compareCategories.Add(category);
            }

            dbContext.SaveChanges();

            var service = new BlogService(dbContext, null);

            var categories = service.GetAllCategories();

            Assert.Equal(compareCategories, categories.Result);
        }

        [Fact]
        public async Task<IEnumerable<ArticleViewModel>>GetAllArticlesShouldGetArticlesCorrecly()
        {
            var mockList = new List<ArticleViewModel>
            {
                new ArticleViewModel
                {
                    Content = "There’s a lot that goes into becoming a truly great designer. It can’t be done by simply reading a book or watching a YouTube video.",
                    Name = "Advices for young designers",
                    CategoryName = "Marketing Strategy",
                    Image65X65 = "http://specthemes.com/redbiz/redbiz-5/img/thumbs/t-1.jpg",
                    Image350X220 = "http://specthemes.com/redbiz/redbiz-5/img/blog/blog-4.jpg",
                    Image390X245 = "http://specthemes.com/redbiz/redbiz-5/img/blog/blog-5.jpg",
                    Image825X530 = "http://specthemes.com/redbiz/redbiz-5/img/blog/blog-post.jpg"
                },
                new ArticleViewModel
                {
                    Content = "Youth of an organization or its members is not the primary determinant of whether an organization successfully utilizes super stretch goals. ",
                    Name = "Are Super Stretch Goals Only for the Very Young?",
                    CategoryName = "Marketing Strategy",
                    Image65X65 = "http://specthemes.com/redbiz/redbiz-5/img/thumbs/t-2.jpg",
                    Image350X220 = "https://i.postimg.cc/kGtQBqnR/487963.jpg",
                    Image390X245 = "http://specthemes.com/redbiz/redbiz-5/img/blog/blog-4.jpg",
                    Image825X530 = "https://i.postimg.cc/kGtQBqnR/487963.jpg"
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Articles_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<ArticleViewModel>>(
                    dbContext.Articles))
                .Returns(mockList);

            var articlesCount = 5;

            for (int i = 0; i < articlesCount; i++)
            {
                dbContext.Articles.Add(new Article());
            }

            dbContext.SaveChanges();
            var service = new BlogService(dbContext, mapper.Object);

            var allArticles = await service.GetAllArticles();
            
            Assert.NotNull(allArticles);
            return allArticles;
        }
    }
}
