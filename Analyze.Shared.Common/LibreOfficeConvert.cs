using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common
{
    public class LibreOfficeConvert
    {
        static string getLibreOfficePath()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    return "/usr/bin/soffice";
                case PlatformID.Win32NT:
                    string binaryDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    return binaryDirectory + "\\Windows\\program\\soffice.exe";
                default:
                    throw new PlatformNotSupportedException("你的系统暂不支持！");
            }
        }

        public static void ToPdf(string officePath,string outPutPath)
        {
            ////获取libreoffice命令的路径
            //string libreOfficePath = getLibreOfficePath();

            ProcessStartInfo procStartInfo = new ProcessStartInfo("C:\\Program Files\\LibreOffice\\program\\soffice.exe", string.Format("--convert-to pdf --outdir {0} --nologo {1}", outPutPath, officePath));
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            procStartInfo.WorkingDirectory = Environment.CurrentDirectory;

            //开启线程
            Process process = new Process() { StartInfo = procStartInfo, };
            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new LibreOfficeFailedException(process.ExitCode);
            }

            //Process process = new Process();
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "/C \"C:\\Program Files\\LibreOffice\\program\\soffice.exe\" --headless --convert-to pdf:writer_pdf_Export " + officePath + "--outdir" + outPutPath;
            //process.StartInfo = startInfo;
            //process.Start();
            //process.WaitForExit();
            //if (process.ExitCode != 0)
            //{
            //    throw new LibreOfficeFailedException(process.ExitCode);
            //}
        }

        public class LibreOfficeFailedException : Exception
        {
            public LibreOfficeFailedException(int exitCode)
                : base(string.Format("LibreOffice错误 {0}", exitCode)) 
            { }
        }
    }
}
