using EasyPDV.BackEnd.Domain.Entities.Notifications.Model;

namespace EasyPDV.BackEnd.Domain.Interfaces
{
    public interface INotificationContext
    {
        IReadOnlyCollection<Notification> Notifications();
        bool HasNotifications();
        void AddNotification(string key, string message);
        void AddNotification(Notification notification);
        void AddNotifications(IReadOnlyCollection<Notification> notifications);
        void AddNotifications(IList<Notification> notifications);
    }
}
