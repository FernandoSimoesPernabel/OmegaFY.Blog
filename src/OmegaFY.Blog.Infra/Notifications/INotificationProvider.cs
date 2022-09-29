using OmegaFY.Blog.Infra.Notifications.Models;

namespace OmegaFY.Blog.Infra.Notifications;

public interface INotificationProvider
{
    public Task<bool> SendNotificationAsync(Notification notification, CancellationToken cancellationToken);
}