using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intillegio.Common.ViewModels;
using Intillegio.Common.ViewModels.Admin;
using Intillegio.Data.Data;
using Intillegio.DTOs.BindingModels.Admin;
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
        public async Task<IEnumerable<ArticleViewModel>> GetAllArticlesShouldGetArticlesCorrectly()
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

        [Fact]
        public void GetAllCategoriesShouldReturnCategoriesCorrectly()
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
        public async Task<IEnumerable<AdminArticleViewModel>> GetAllArticlesForAdminShouldGetArticlesCorrectly()
        {
            var mockList = new List<AdminArticleViewModel>
            {
                new AdminArticleViewModel
                {
                    Name = "Advices for young designers",
                    CategoryName = "Marketing Strategy",
                    Id = 1,
                    Date =  DateTime.ParseExact("2019-05-12 0:00", "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                },
                new AdminArticleViewModel
                {
                    Name = "Advices for young designers",
                    CategoryName = "Marketing Strategy",
                    Id = 1,
                    Date =  DateTime.ParseExact("2019-06-06 0:00", "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                }
            };

            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Get_All_Articles_for_Admin_Db")
                .Options;
            var dbContext = new IntillegioContext(options);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<AdminArticleViewModel>>(
                    dbContext.Articles))
                .Returns(mockList);

            var articlesCount = 5;

            for (int i = 0; i < articlesCount; i++)
            {
                dbContext.Articles.Add(new Article());
            }

            dbContext.SaveChanges();
            var service = new BlogService(dbContext, mapper.Object);

            var allArticles = await service.GetAllArticlesForAdmin();
            
            Assert.NotNull(allArticles);
            return allArticles;
        }

        [Fact]
        public void AddArticleAsyncShouldReturnTeamMemberCorrectly()
        {
            var options = new DbContextOptionsBuilder<IntillegioContext>()
                .UseInMemoryDatabase(databaseName: "Add_Article_Db")
                .Options;

            var dbContext = new IntillegioContext(options);

            var articleBindingModel = new AdminArticleBindingModel
            {
                Image350X220 = "http://specthemes.com/redbiz/redbiz-5/img/thumbs/t-1.jpg",
                Name = "Advices for young designers",
                Image825X530 = "http://specthemes.com/redbiz/redbiz-5/img/blog/blog-post.jpg",
                Image390X245 = "http://specthemes.com/redbiz/redbiz-5/img/blog/blog-4.jpg",
                Image65X65 = "http://specthemes.com/redbiz/redbiz-5/img/thumbs/t-1.jpg",
                Content = "There’s a lot that goes into becoming a truly great designer. It can’t be done by simply reading a book or watching a YouTube video."
            };

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<Article>(articleBindingModel))
                .Returns(new Article
                {
                    Image350X220 = "http://specthemes.com/redbiz/redbiz-5/img/thumbs/t-1.jpg",
                    Name = "Advices for young designers",
                    Image825X530 = "http://specthemes.com/redbiz/redbiz-5/img/blog/blog-post.jpg",
                    Image390X245 = "http://specthemes.com/redbiz/redbiz-5/img/blog/blog-4.jpg",
                    Image65X65 = "http://specthemes.com/redbiz/redbiz-5/img/thumbs/t-1.jpg",
                    Content = "There’s a lot that goes into becoming a truly great designer. It can’t be done by simply reading a book or watching a YouTube video."
                });

            var service = new BlogService(dbContext, mapper.Object);
            service.AddArticleAsync(articleBindingModel);
            Assert.True(dbContext.Articles.Any(n => n.Name == articleBindingModel.Name));
            Assert.True(dbContext.Articles.Any(a => a.Image350X220 == articleBindingModel.Image350X220));
        }
    }
}
