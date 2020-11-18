using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface INewsService
    {
        Task<News> AddNews(News news);
        Task<News> GetNewsById(int newsId);
        Task<List<News>> GetAllNews(string userId);
        Task<bool> RemoveNews(int newsId);
    }
}
