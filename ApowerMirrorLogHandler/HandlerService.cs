using System;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Timers;

namespace ApowerMirrorLogHandler
{
    public partial class HandlerService : ServiceBase
    {
        public HandlerService()
        {
            InitializeComponent();
        }

        private void Handle(object sender, ElapsedEventArgs e)
        {
            Log($"Checking folder started on {DateTime.Now.ToShortTimeString()}");
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Apowersoft", "ApowerMirror", "log");
            if (Directory.Exists(path))
            {
                FileInfo[] fileInfos = new DirectoryInfo(path).GetFiles();
                long size = fileInfos.Select(fi => fi.Length).Sum() / (1024 * 1024); // Get Size In MB
                if(size > 500)
                {
                    Directory.Delete(path);
                    Log($"Log folder checked; All logs file deleted; the total size was {size} MB");
                }
                else
                {
                    Log($"Log folder checked; No need to delete; the total size is {size} MB");
                }
            }
            else
            {
                Log("log folder does not exist");
            }
        }

        private void Log(string logMessage)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(logMessage);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(logMessage);
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            Timer timer = new Timer()
            {
                Interval = 300_000, //300 seconds = five minutes
                AutoReset = true
            };
            timer.Elapsed += new ElapsedEventHandler(Handle);
            timer.Enabled = true;
            Log($"Service started on {DateTime.Now.ToString()}");
        }

        protected override void OnStop()
        {
            Log($"Service stoped on {DateTime.Now.ToString()}");
        }
    }
}
