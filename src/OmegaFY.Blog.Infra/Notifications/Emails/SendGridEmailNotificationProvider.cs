using Microsoft.Extensions.DependencyInjection;
using SendGrid.Helpers.Mail;
using SendGrid;
using OmegaFY.Blog.Infra.Notifications.Configs;
using Microsoft.Extensions.Options;
using OmegaFY.Blog.Infra.Notifications.Models;

namespace OmegaFY.Blog.Infra.Notifications.Emails;

internal class SendGridEmailNotificationProvider : IEmailNotificationProvider
{
    private readonly ISendGridClient _sendGridClient;

    private readonly EmailAddress _fromEmailAddress;

    public SendGridEmailNotificationProvider(ISendGridClient sendGridClient, IOptions<SendGridSettings> optionsSendGridSettings)
    {
        _sendGridClient = sendGridClient;
        _fromEmailAddress = new EmailAddress(optionsSendGridSettings.Value.FromEmail, optionsSendGridSettings.Value.FromEmailDisplayName);
    }

    public async Task<bool> SendNotificationAsync(Notification notification, CancellationToken cancellationToken)
    {
        SendGridMessage emailMessage = new SendGridMessage()
        {
            From = _fromEmailAddress,
            Subject = notification.Subject,
            PlainTextContent = notification.Message
        };
        
        emailMessage.AddTo(new EmailAddress(notification.Email, notification.Username));

        Response response = await _sendGridClient.SendEmailAsync(emailMessage, cancellationToken);

        return response.IsSuccessStatusCode;
    }
}