using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sikuli4Net.sikuli_REST;
using System.Net.Mail;
using System.Diagnostics;
using Sikuli4Net.sikuli_UTIL;
using System.IO;

namespace OldISSikuliTest
{
    public class StartTest
    {
        public static void Main()
        {
            APILauncher launcher = new APILauncher(true);
            launcher.Start();

            System.Net.ServicePointManager.Expect100Continue = false;
            Page page = new Page();
            Screen scr = new Screen();

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                Connecton.DeleteUser("delete from Invalid where ID_User=Invalid;");

                try
                {
                    System.Diagnostics.Process.Start(page.ISExe);

                    scr.Wait(page.DB, 100);
                    scr.Type(page.Username, "Invalid");
                    scr.Type(page.Password, "Invalid");
                    scr.Click(page.Login);
                    scr.Wait(page.TabProfireal, 100);
                    scr.Click(page.LoanButton);
                    scr.Click(page.TabLoanButton);

                    Stopwatch swt = new Stopwatch();
                    swt.Start();

                    scr.Type(page.Search, "5006010315" + Key.ENTER);
                    scr.Wait(page.Paid, 100);
                    scr.Click(page.Redaction);
                    scr.Wait(page.Request, 100);

                    swt.Stop();

                    scr.Click(page.RequestExit);
                    scr.Click(page.LoanExit);
                    scr.Click(page.ISExit);
                    scr.Wait(page.WaitQuit, 100);
                    scr.Click(page.Quit);

                    var time = swt.Elapsed;
                    string count = Connecton.GetCountBySql("SELECT COUNT(*) FROM Invalid;");
                    string message = string.Format("{0};{1};{2}", DateTime.Now.ToString(), time.ToString(), count);

                    if (File.Exists(page.LogPath))
                    {
                        SaveLog(page.LogPath, message);
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(page.LogPath))
                        {
                            sw.WriteLine(string.Format("Date;Time;Sessions\n{0}", message));
                        }
                    }

                    if ((int)(time.TotalSeconds) > 45)
                    {
                        string body = string.Format("IS report:{0}", time.ToString());
                        EmailSend(page.LogPath, body);
                    }

                    Wait();
                }
                catch (Exception ex)
                {
                    string body = "Error:" + "\t" + ex.ToString() + "\t" + ex.StackTrace;
                    EmailSend(page.LogPath, body);
                }
            }

            launcher.Stop();
        }

        private static void SaveLog(string path, string log)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(log);
            }
        }

        private static void EmailSend(string path, string body)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("Invalid@gmail.com");
            //mail.To.Add("Invalid@proficredit.bg");
            mail.To.Add("Invalid@proficredit.bg");
            mail.Subject = "Sikuli time test IS";
            mail.Body = body;
            using (Attachment attachment = new Attachment(path))
            {
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("Invalid@gmail.com", "Invalid");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
        }

        private static void Wait()
        {
            Stopwatch sw = new Stopwatch(); // sw cotructor
            sw.Start(); // starts the stopwatch
            for (int i = 0; ; i++)
            {
                if (i % 100000 == 0) // if in 100000th iteration (could be any other large number
                                     // depending on how often you want the time to be checked) 
                {
                    sw.Stop(); // stop the time measurement
                    if (sw.ElapsedMilliseconds > 15000) // check if desired period of time has elapsed
                    {
                        break; // if more than 5000 milliseconds have passed, stop looping and return
                               // to the existing code
                    }
                    else
                    {
                        sw.Start(); // if less than 5000 milliseconds have elapsed, continue looping
                                    // and resume time measurement
                    }
                }
            }
        }
    }
}
