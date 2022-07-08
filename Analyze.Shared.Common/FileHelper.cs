using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Analyze.Shared.Common
{
    public static class FileHelper
    {
        /// <summary>
        ///  Response分块下载，输出硬盘文件，提供下载 支持大文件、续传、速度限制、资源占用小
        /// </summary>
        /// <param name="fileName">客户端保存的文件名</param>
        /// <param name="filePath">客户端保存的文件路径（包括文件名）</param>
        /// <returns></returns>
        public static bool ResponseDownLoad(string fileName, string filePath)
        {
           System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
           if (fileInfo.Exists == true)
           {
               const long ChunkSize = 2048000;//2048Kb 每次读取文件，只读取2Mb，这样可以缓解服务器的压力
               byte[] buffer = new byte[ChunkSize];

               HttpContext.Current.Response.Clear();
               System.IO.FileStream iStream = System.IO.File.OpenRead(filePath);
               long dataLengthToRead = iStream.Length;//获取下载的文件总大小
               HttpContext.Current.Response.ContentType = "application/octet-stream";
               HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
               while (dataLengthToRead > 0 && HttpContext.Current.Response.IsClientConnected)
               {
                   int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
                   HttpContext.Current.Response.OutputStream.Write(buffer, 0, lengthRead);
                   HttpContext.Current.Response.Flush();
                   dataLengthToRead = dataLengthToRead - lengthRead;
               }
               HttpContext.Current.Response.Close();
               return true;
           }
           else
               return false;
        }

        public static bool RequestUpload(HttpPostedFileBase imgFile, string AbsolutePath)
        {
            Stream uploadStream = null;
            FileStream fs = null;
            if (imgFile != null) 
            {
                uploadStream = imgFile.InputStream;
                int bufferLen = 2048;//2Mb
                byte[] buffer = new byte[bufferLen];
                int contentLen = 0;
                fs = new FileStream(AbsolutePath, FileMode.Create, FileAccess.ReadWrite);
                while ((contentLen = uploadStream.Read(buffer, 0, bufferLen)) != 0)
                {
                    fs.Write(buffer, 0, bufferLen);
                    fs.Flush();
                }
                if (null != fs)
                {
                    fs.Close();
                }
                if (null != uploadStream)
                {
                    uploadStream.Close();
                }
                return true;
            }
            else
                return false;
        }
    }
}
