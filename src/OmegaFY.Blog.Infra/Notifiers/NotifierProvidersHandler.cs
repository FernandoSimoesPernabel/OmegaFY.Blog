namespace OmegaFY.Blog.Infra.Notifiers;

internal class NotifierProvidersHandler : INotifierProvidersHandler
{
    private readonly IEnumerable<INotifierProvider> _providers;

    public NotifierProvidersHandler(IEnumerable<INotifierProvider> providers)
    {
        _providers = providers;
    }
}