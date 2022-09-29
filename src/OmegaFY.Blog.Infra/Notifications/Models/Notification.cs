using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Infra.Notifications.Models;

public readonly record struct Notification
{
    public string Username { get; }

    public string Email { get; }

    public string Cellphone { get; }

    public string Subject { get; }

    public string Message { get; }

    public Notification(string username, string email, string cellphone, string subject, string message)
    {
        Username = username;
        Email = email;
        Cellphone = cellphone;
        Subject = subject;
        Message = message;
    }
}