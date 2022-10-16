using OmegaFY.Blog.Infra.Notifications.Models;
using OmegaFY.Blog.Infra.Notifiers.Sms;

namespace OmegaFY.Blog.Infra.Notifications.Sms;

internal class SmsNotificationProvider : ISmsNotificationProvider
{
    public Task<bool> SendNotificationAsync(Notification notification, CancellationToken cancellationToken) => Task.FromResult(true);
}