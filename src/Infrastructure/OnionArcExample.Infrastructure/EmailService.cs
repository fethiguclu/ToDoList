using TaskProject.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskProject.Infrastructure
{
    public class EmailService : IEmailService
    {
        public bool Send(string to, string message)
        {
            Console.WriteLine("mail sent");
            return true;
        }
    }
}
