using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace DAL
{
    //Inherit the respective interface and implement the methods in 
    // this class i.e ReminderRepository by inheriting IReminderRepository
    //ReminderRepository class is used to implement all Data access operations
    public class ReminderRepository:IReminderRepository
    {
        private readonly NewsDbContext _dbContext;
        public ReminderRepository(NewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Reminder> AddReminder(Reminder reminder)
        { 
            //if (reminder.ReminderId == 0)
            //{
            //    for (int x = 1; x < 10000; x++)
            //    {
            //        var find = _dbContext.Reminders.Where(c => c.ReminderId== x).FirstOrDefault();
            //        if (find == null)
            //        {
            //            reminder.ReminderId = x;
            //            break;
            //        }
            //    }
            //}
            var added=_dbContext.Reminders.Add(reminder);            
            if(_dbContext.SaveChanges()>0)
            {
                return Task.FromResult(reminder); 
            }
            return Task.FromResult(new Reminder());
        }

        public Task<Reminder> GetReminder(int reminderId)
        {
            var result = _dbContext.Reminders.Where(x => x.ReminderId == reminderId).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<Reminder> GetReminderByNewsId(int newsId)
        {
            var result = _dbContext.Reminders.Where(x => x.NewsId==newsId).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<bool> RemoveReminder(Reminder reminder)
        {
            _dbContext.Reminders.Remove(reminder);
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }
        // Implement CreateReminder method which should be used to save a new reminder.    
        // Implement DeletReminder method which method should be used to delete an existing reminder.
        // Implement GetAllRemindersByUserId method which should be used to get all reminder by userId.
        // Implement GetReminderById method which should be used to get a reminder by reminderId
        // Implement UpdateReminder method which should be used to update an existing reminder

    }
}
