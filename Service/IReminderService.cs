using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IReminderService
    {
        Task<Reminder> AddReminder(Reminder reminder);
        Task<bool> RemoveReminder(int reminderId);
        Task<Reminder> GetReminderByNewsId(int newsId);
    }
}
