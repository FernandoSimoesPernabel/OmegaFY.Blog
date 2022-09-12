namespace OmegaFY.Blog.Infra.Notifications;

internal class MultipleNotificationProvidersHandler : IMultipleNotificationProvidersHandler
{
    private readonly IEnumerable<INotificationProvider> _providers;

    public MultipleNotificationProvidersHandler(IEnumerable<INotificationProvider> providers)
    {
        _providers = providers;
    }
}