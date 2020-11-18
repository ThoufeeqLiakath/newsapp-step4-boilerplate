using DAL;
using Entities;
using Service.Exceptions;
using System.Threading.Tasks;

namespace Service
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository repository;
        public ReminderService(IReminderRepository reminderRepository)
        {
            repository = reminderRepository;
        }
        public async Task<Reminder> AddReminder(Reminder reminder)
        {
            var _reminder = await repository.GetReminderByNewsId(reminder.NewsId);
            if (_reminder == null)
                return await repository.AddReminder(reminder);
            else
                throw new ReminderAlreadyExistsException($"This news: {reminder.NewsId} already have a reminder");
        }

        public async Task<Reminder> GetReminderByNewsId(int newsId)
        {
            var reminder = await repository.GetReminderByNewsId(newsId);
            if (reminder != null)
                return reminder;
            else
                throw new ReminderNotFoundException($"No reminder found for news: {newsId}");
        }

        public async Task<bool> RemoveReminder(int reminderId)
        {
            var reminder = await repository.GetReminder(reminderId);
            if (reminder != null)
                return await repository.RemoveReminder(reminder);
            else
                throw new ReminderNotFoundException($"No reminder found with id: {reminderId}");
        }
    }
}
