using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Close_Principle
{
    public enum Notification
    {
        Email,
        Sms,
        Push
    }
    public interface INotificationSender
    {
        bool CanSend(Notification notification);
        void SendNotification(Notification notification);
    }

    public class EmailNotificationSender : INotificationSender
    {
        public bool CanSend(Notification notification)
        {
            return notification == Notification.Email;
        }

        public void SendNotification(Notification notification)
        {
            // Send email notification
        }
    }

    public class SmsNotificationSender : INotificationSender
    {
        public bool CanSend(Notification notification)
        {
            return notification == Notification.Sms;
        }

        public void SendNotification(Notification notification)
        {
            // Send SMS notification
        }
    }

    public class PushNotificationSender : INotificationSender
    {
        public bool CanSend(Notification notification)
        {
            return notification == Notification.Push;
        }

        public void SendNotification(Notification notification)
        {
            // Send push notification
        }
    }

    

    public class NotificationService
    {
        private readonly List<INotificationSender> _senders;

        public NotificationService(List<INotificationSender> senders)
        {
            _senders = senders;
        }

        public void SendNotification(Notification notification)
        {
            foreach (var sender in _senders)
            {
                if (sender.CanSend(notification))
                {
                    sender.SendNotification(notification);
                }
            }
        }
    }
}
