using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sikuli4Net.sikuli_REST;
using System.Net.Mail;
using System.Diagnostics;
using Sikuli4Net.sikuli_UTIL;
using System.IO;

namespace OldISSikuliTest
{
    [TestClass]
    public class UnitTest1
    {
        private static APILauncher launcher = new APILauncher(true);

        [ClassInitialize]
        public static void RunBeforeAnyTests(TestContext testContext)
        {

            launcher.Start();
        }

        [ClassCleanup]
        public static void RunAfterAnyTests()
        {
            launcher.Stop();
        }

        [TestMethod]
        public void TestMethod1()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            Page page = new Page();
            Screen scr = new Screen();

            try
            {
                System.Diagnostics.Process.Start(page.ISExe);

                scr.Wait(page.DB, 5);
                scr.Type(page.Username, "Invalid");
                scr.Type(page.Password, "Invalid");
                scr.Click(page.Login);
                scr.Wait(page.TabProfireal, 30);
                scr.Click(page.LoanButton);
                scr.Click(page.TabLoanButton);

                Stopwatch swt = new Stopwatch();
                swt.Start();

                scr.Type(page.Search, "5006010315" + Key.ENTER);
                scr.Wait(page.Paid, 50);
                scr.Click(page.Redaction);
                scr.Wait(page.Request, 50);

                swt.Stop();

                scr.Click(page.RequestExit);
                scr.Click(page.LoanExit);
                scr.Click(page.ISExit);
                scr.Wait(page.WaitQuit, 30);
                scr.Click(page.Quit);

                var time = swt.Elapsed;
                string count = Connecton.GetTop1FromDBBySql("select count(*) from CityAreas;");
                string message = string.Format("{0};{1};{2}", DateTime.Now.ToString(), time.ToString(), count);

                if (File.Exists(page.LogPath))
                {
                    SaveLog(page.LogPath, message);
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(page.LogPath))
                    {
                        sw.WriteLine(string.Format("Date;Time;Count\n{0}", message));
                    }
                }

                throw new ArgumentException();

                if ((int)(time.TotalSeconds) > 10)
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
            //mail.To.Add("Invalid@abv.bg");
            mail.To.Add("Invalid@abv.bg");
            mail.Subject = path;
            mail.Body = body;
            using (Attachment attachment = new Attachment(path))
            {
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("Invalid", "Invalid);
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
                    if (sw.ElapsedMilliseconds > 10000) // check if desired period of time has elapsed
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
