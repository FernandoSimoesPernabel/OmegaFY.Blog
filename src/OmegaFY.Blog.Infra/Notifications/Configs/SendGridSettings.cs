namespace OmegaFY.Blog.Infra.Notifications.Configs;

public class SendGridSettings
{
    public string ApiKey { get; set; }

    public string FromEmail { get; set; }

    public string FromEmailDisplayName { get; set; }
}