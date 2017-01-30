using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Diagnostics;
using System.Net.Mail;

namespace Ehealth
{
    public class Logger
    {
        public static void Log(Exception exception) 
        {
            StringBuilder sbExceptionMessage = new StringBuilder();
            do
            {
                sbExceptionMessage.Append("Exception Type:" + Environment.NewLine);
                sbExceptionMessage.Append(exception.GetType().Name + Environment.NewLine + Environment.NewLine);

                sbExceptionMessage.Append("Message:" + Environment.NewLine);
                sbExceptionMessage.Append(exception.Message + Environment.NewLine + Environment.NewLine);

                sbExceptionMessage.Append("Stack Trace:" + Environment.NewLine);
                sbExceptionMessage.Append(exception.StackTrace + Environment.NewLine + Environment.NewLine);

                exception = exception.InnerException;
            } while (exception != null);

            LogToEventviewer(sbExceptionMessage.ToString());
           // SendEmail(sbExceptionMessage.ToString());
        }

        private static void LogToEventviewer(string log)
        {
             if(EventLog.SourceExists("Ehealth.com"))
            {
                EventLog eventlog = new EventLog("Ehealth");
                eventlog.Source = "Ehealth.com";
                eventlog.WriteEntry(log.ToString(),EventLogEntryType.Error);
            }
        }

        public static void SendEmail(MailMessage emailBody)
        {
            MailMessage mailMessage = new MailMessage("iftekhar.rasul7@gmail.com", "iftekhar.rasul7@gmail.com");
            mailMessage.Subject = "exception";
            mailMessage.Body = emailBody.ToString();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
        }
    }

}