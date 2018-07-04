using Sikuli4Net.sikuli_REST;
using System;
using System.IO;

namespace OldISSikuliTest
{
    public class Page
    {
        private string directory = System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString();

        public string ISExe
        {
            get
            {
                return "C:\\MyIS\\Profireal.exe ";
            }
        }

        public Pattern DB
        {
            get
            {
                return new Pattern( Path.GetFullPath(Path.Combine(directory, @"..\Images\DB.png")));
            }
        }

        public Pattern Username
        {
            get
            {
                return new Pattern( Path.GetFullPath(Path.Combine(directory, @"..\Images\Username.png")));
            }
        }

        public Pattern Password
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\Password.png")));
            }
        }

        public Pattern Login
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\Login.png")));
            }
        }

        public Pattern TabProfireal
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\ProfirealTab.png")));
            }
        }

        public Pattern LoanButton
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\Loan.png")));
            }
        }

        public Pattern TabLoanButton
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\TabLoan.png")));
            }
        }

        public Pattern Search
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\Search.png")));
            }
        }

        public Pattern Paid
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\Paid.png")));
            }
        }

        public Pattern Redaction
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\Redaction.png")));
            }
        }

        public Pattern Request
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\Request.png")));
            }
        }

        public Pattern RequestExit
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\RequestExit.png")));
            }
        }

        public Pattern LoanExit
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\LoanExit.png")));
            }
        }

        public Pattern ISExit
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\ISExit.png")));
            }
        }

        public Pattern WaitQuit
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\WaitQuit.png")));
            }
        }

        public Pattern Quit
        {
            get
            {
                return new Pattern(Path.GetFullPath(Path.Combine(directory, @"..\Images\Quit.png")));
            }
        }

        public string LogPath
        {
            get
            {
                return Path.GetFullPath(Path.Combine(directory, "..\\Log\\" + DateTime.Now.ToString("ddMMyyyy") + ".csv"));
            }
        }
    }
}
