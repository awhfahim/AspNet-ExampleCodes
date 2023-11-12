using Open_Close_Principle;

EmailNotificationSender email = new();
SmsNotificationSender sms = new();

List<INotificationSender> notificationSenders = new List<INotificationSender> { email, sms };    
NotificationService notificationService = new(notificationSenders);
notificationService.SendNotification(Notification.Email);