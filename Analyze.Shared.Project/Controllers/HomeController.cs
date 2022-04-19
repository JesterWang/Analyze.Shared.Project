using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.Report;
using Analyze.Shared.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Controllers
{
    public class HomeController : Controller
    {
        private IParMeService _IParMeService = null;
        private IParFileService _IParFileService = null;

        public HomeController(IParMeService iParMeService, IParFileService iParFileService) 
        {
            _IParMeService = iParMeService;
            _IParFileService = iParFileService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        #region ME分析报告
        [HttpPost]//基础信息查询
        public ActionResult PaertViewIndexParMe(int tracking_id)
        {
            ParList parlist = new ParList();

            List<ParMe> listParMe = new List<ParMe>();
            ParMe parMe = _IParMeService.GetQueryReport(tracking_id);
            listParMe.Add(parMe);
            parlist.ParMe = listParMe;

            List<ParFileUpload> listParFileUpload = _IParFileService.GetQuery(tracking_id, 2);
            parlist.ParFileUpload = listParFileUpload;

            return base.PartialView("PaertViewIndexParMe", parlist);
        }

        [HttpPost]//基础信息保存
        public JsonResult PaertViewIndexParMeUpload(int tracking_id, string analysis_conclusion, string analysis_steps)
        {
            ParList parlist = new ParList();
            List<ParMe> listParMe = new List<ParMe>();
            ParMe parMe = _IParMeService.GetQueryReport(tracking_id);
            if (parMe != null)
            {
                listParMe.Add(parMe);
                parlist.ParMe = listParMe;
            }
            return Json(parlist);
        } 
        #endregion






        #region 文件操作
        [HttpPost]//文件删除-服务器接收&&数据库更新
        public ActionResult DeleteFile(int id, int tracking_id, string filePath, int category_id)
        {
            try
            {
                // Get details of File to be Delete.

                // Delete file from Server Path.
                if (System.IO.File.Exists((Server.MapPath("~") + filePath).Replace("/", "\\")))
                {
                    System.IO.File.Delete(Server.MapPath("~") + filePath.Replace("/", "\\"));
                }
                // Delete record from Database.
                bool b = _IParFileService.GetDelete(id);
                return JavaScript("showFile('" + category_id + "')");
            }
            catch (Exception exp)
            {
                return JavaScript("Error:" + exp);
            }
        }

        [HttpPost]//文件上传-数据库更新
        public ActionResult InsertFile(int tracking_id, string user_detailed, string file_url, byte category_id)
        {
            ParFileUpload parFileUpload = new ParFileUpload()
            {
                tracking_id = tracking_id,
                file_url = file_url,
                file_name = Path.GetFileName(file_url),
                user_detailed = user_detailed,
                category_id = category_id
            };
            bool b = _IParFileService.GetInsert(parFileUpload);
            if (b == true)
            {
                return Json(category_id.ToString());//文件类型
            }
            else
            {
                return Json("0");
            }
        }

        [HttpPost]//文件上传-服务器接收
        public ActionResult UploadFile()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            HttpPostedFile imgFile = request.Files[0];
            string fileName = imgFile.FileName;
            string path = "";//文件的完整路径
            //文件保存目录路径
            string filePathName = DateTime.Now.ToString("yyyyMMdd");//以日期为文件存放的上层文件夹名
            string savePath = "/UploadedFiles/" + filePathName + "/";//文件存放的完整路径
            //如果文件路径不存在则创建文件夹
            if (!Directory.Exists(Server.MapPath(savePath)))
            {
                Directory.CreateDirectory(Server.MapPath(savePath));
            }
            string imgName = DateTime.Now.ToString("yyyyMMddhhmmss");//文件别名
            string imgPath = savePath + imgName + "-" + imgFile.FileName;//构造文件保存路径 
            string AbsolutePath = Server.MapPath(imgPath);
            imgFile.SaveAs(AbsolutePath);//将上传的东西保存 
            path = imgPath;//获得文件完整路径并返回到前台页面
            if (path != "")
            {
                return Json(path);
            }
            else
            {
                return Json("0");
            }
        }

        [HttpGet]//文件下载
        public FileResult DownloadFile(string filePath)
        {
            //Build the File Path.
            string fileName = Path.GetFileName(filePath);
            string path = Server.MapPath("~" + filePath);
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        } 
        #endregion

        
    }
}