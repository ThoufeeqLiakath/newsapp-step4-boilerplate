using DAL;
using Entities;
using Service.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository repository;
        public NewsService(INewsRepository newsRepository)
        {
            repository = newsRepository;
        }
        public async Task<News> AddNews(News news)
        {
            var _news =await repository.IsNewsExist(news);
            if (_news)
            {
                throw new NewsAlreadyExistsException($"This news is already added");
            }
            else
            {
                return await repository.AddNews(news);
            }
        }

        public async Task<List<News>> GetAllNews(string userId)
        {
            var news = await repository.GetAllNews(userId);
            if (news.Count>0)
            {
                return news;
            }
            else
            {
                throw new NewsNotFoundException($"No news found for user: {userId}");
            }
        }

        public async Task<News> GetNewsById(int newsId)
        {
            var news =await repository.GetNewsById(newsId);
            if (news != null)
            {
                return news;
            }
            else
            {
                throw new NewsNotFoundException($"No news found with Id: {newsId}");
            }
        }

        public async Task<bool> RemoveNews(int newsId)
        {
            var news = await repository.GetNewsById(newsId);
            if (news != null)
            {
               return await repository.RemoveNews(news);
            }
            else
            {
                throw new NewsNotFoundException($"No news found with Id: {newsId}");
            }
        }
    }
}
