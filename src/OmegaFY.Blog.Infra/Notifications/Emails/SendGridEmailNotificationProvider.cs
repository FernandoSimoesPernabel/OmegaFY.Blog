using Microsoft.Extensions.DependencyInjection;
using SendGrid.Helpers.Mail;
using SendGrid;
using OmegaFY.Blog.Infra.Notifications.Configs;
using Microsoft.Extensions.Options;

namespace OmegaFY.Blog.Infra.Notifications.Emails;

internal class SendGridEmailNotificationProvider : IEmailNotificationProvider
{
    private readonly ISendGridClient _sendGridClient;

    private readonly SendGridSettings _sendGridSettings;

    public SendGridEmailNotificationProvider(ISendGridClient sendGridClient, IOptions<SendGridSettings> optionsSendGridSettings)
    {
        _sendGridClient = sendGridClient;
        _sendGridSettings = optionsSendGridSettings.Value;
    }

    //public async Task SendEmailAsync()
    //{
    //    SendGridMessage msg = new SendGridMessage()
    //    {
    //        From = new EmailAddress(_sendGridSettings.FromEmail, _sendGridSettings.FromEmailDisplayName),
    //        Subject = "Sending with Twilio SendGrid is Fun"
    //    };

    //    msg.AddContent(MimeType.Text, "and easy to do anywhere, even with C#");
    //    msg.AddTo(new EmailAddress("test@example.com", "Example User"));
    //    Response response = await _sendGridClient.SendEmailAsync(msg);
    //}
}