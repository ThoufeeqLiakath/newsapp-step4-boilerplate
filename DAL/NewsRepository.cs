using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DAL
{
    //Inherit the respective interface and implement the methods in
    // this class i.e NewsRepository by inheriting INewsRepository
    public class NewsRepository:INewsRepository
    {
        private readonly NewsDbContext _dbContext;
        public NewsRepository(NewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<News> AddNews(News news)
        {
            //if (news.NewsId == 0)
            //{
            //    for (int x = 101; x < 10000; x++)
            //    {
            //        var find = _dbContext.NewsList.Where(c => c.NewsId == x).FirstOrDefault();
            //        if (find == null)
            //        {
            //            news.NewsId = x;
            //            break;
            //        }
            //    }
            //}
            //throw new System.NotImplementedException();
            _dbContext.NewsList.Add(news);
            if(_dbContext.SaveChanges()>0)
            {
                return Task.FromResult(news);
            }
            return Task.FromResult(new News());
        }

        public Task<List<News>> GetAllNews(string userId)
        {
         
            var result=_dbContext.NewsList.Where(x => x.CreatedBy == userId).ToList();
            return Task.FromResult(result);            
        }

        public Task<News> GetNewsById(int newsId)
        {            
            var result = _dbContext.NewsList.Where(x => x.NewsId == newsId).FirstOrDefault();
            //if (newsId == 0)
            //{
            //    result = _dbContext.NewsList.FirstOrDefault();
            //}
            return Task.FromResult(result);
        }

        public Task<bool> IsNewsExist(News news)
        {
            var result = _dbContext.NewsList.Where(x=>x.Title==news.Title).FirstOrDefault();
            
            if(result!=null)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> RemoveNews(News news)
        {
            var result = GetNewsById(news.NewsId).Result;
            if(result!=null)
            {
                _dbContext.NewsList.Remove(result);
                return Task.FromResult(_dbContext.SaveChanges()>0);
            }
            return Task.FromResult(false);
        }
        /* Implement all the methods of respective interface asynchronously*/
        /* Implement AddNews method to add the new news details*/
        /* Implement GetAllNews method to get the news details of perticular userid*/
        /* Implement GetNewsById method to get the existing news by news id*/
        /* Implement IsNewsExist method to check the news deatils exist or not*/
        /* Implement RemoveNews method to remove the existing news*/
    }
}
