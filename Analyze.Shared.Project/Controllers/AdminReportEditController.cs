using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common;
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
    public class AdminReportEditController : BaseController
    {
        private IParFaeService _IParFaeService = null;
        private IParMeService _IParMeService = null;
        private IParEeService _IParEeService = null;
        private IParFileService _IParFileService = null;

        public AdminReportEditController(IParFaeService iParFaeService,IParMeService iParMeService, IParFileService iParFileService,
            IParEeService iParEeService)
        {
            _IParFaeService = iParFaeService;
            _IParMeService = iParMeService;
            _IParEeService = iParEeService;
            _IParFileService = iParFileService;
        }

        // GET: Home
        public ActionResult Index()
        {
            // 获取路由数据
            if (Request.QueryString["tracking_id"] != null)
            {
                string _id = Request.QueryString["tracking_id"].ToString();
                ViewData["tracking_id"] = _id;
                string _user = GetUserName() + GetUserEmplyeeName();
                ViewData["user_detailed"] = _user;
            }
            return View();
        }

        

        #region FAE分析报告
        [HttpPost]//基础信息查询
        public ActionResult PaertViewIndexParFae(int tracking_id, byte category_id)
        {
            int s = tracking_id;
            ParList parlist = new ParList();
            List<ParFae> listParFae = new List<ParFae>();
            ParFae parFae = _IParFaeService.GetQueryReport(tracking_id);
            listParFae.Add(parFae);
            parlist.ParFae = listParFae;

            List<ParFileUpload> listParFileUpload = _IParFileService.GetQuery(tracking_id, category_id);
            parlist.ParFileUpload = listParFileUpload;

            return base.PartialView("PaertViewIndexParFae", parlist);
        }

        [HttpPost]//基础信息修改
        public ActionResult PaertViewIndexParFaeUpdate(int tracking_id, string analysis_conclusion, string analysis_steps, string log_result, string user)
        {
            string _log_result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " by " + user + " update;" + "\r\n" + log_result;
            ParFae parFae = new ParFae()
            {
                tracking_id = tracking_id,
                analysis_conclusion = analysis_conclusion,
                analysis_steps = analysis_steps,
                log_result = _log_result
            };
            bool b = _IParFaeService.GetUpdateReport(parFae);
            return Json(_log_result);
        }
        #endregion

        #region ME分析报告
        [HttpPost]//基础信息查询
        public ActionResult PaertViewIndexParMe(int tracking_id, byte category_id)
        {
            int s = tracking_id;
            ParList parlist = new ParList();
            List<ParMe> listParMe = new List<ParMe>();
            ParMe parMe = _IParMeService.GetQueryReport(tracking_id);
            listParMe.Add(parMe);
            parlist.ParMe = listParMe;

            List<ParFileUpload> listParFileUpload = _IParFileService.GetQuery(tracking_id, category_id);
            parlist.ParFileUpload = listParFileUpload;

            return base.PartialView("PaertViewIndexParMe", parlist);
        }

        [HttpPost]//基础信息修改
        public ActionResult PaertViewIndexParMeUpdate(int tracking_id, string analysis_conclusion, string analysis_steps, string log_result, string user)
        {
            string _log_result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " by " + user + " update;" + "\r\n" + log_result;
            ParMe parMe = new ParMe()
            {
                tracking_id = tracking_id,
                analysis_conclusion = analysis_conclusion,
                analysis_steps = analysis_steps,
                log_result = _log_result
            };
            bool b = _IParMeService.GetUpdateReport(parMe);
            return Json(_log_result);
        }
        #endregion

        #region EE分析报告
        [HttpPost]//基础信息查询
        public ActionResult PaertViewIndexParEe(int tracking_id, byte category_id)
        {
            int s = tracking_id;
            ParList parlist = new ParList();
            List<ParEe> listParEe = new List<ParEe>();
            ParEe parEe = _IParEeService.GetQueryReport(tracking_id);
            listParEe.Add(parEe);
            parlist.ParEe = listParEe;

            List<ParFileUpload> listParFileUpload = _IParFileService.GetQuery(tracking_id, category_id);
            parlist.ParFileUpload = listParFileUpload;

            return base.PartialView("PaertViewIndexParEe", parlist);
        }

        [HttpPost]//基础信息修改
        public ActionResult PaertViewIndexParEeUpdate(int tracking_id, string analysis_conclusion, string analysis_steps, string log_result, string user)
        {
            string _log_result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " by " + user + " update;" + "\r\n" + log_result;
            ParEe parEe = new ParEe()
            {
                tracking_id = tracking_id,
                analysis_conclusion = analysis_conclusion,
                analysis_steps = analysis_steps,
                log_result = _log_result
            };
            bool b = _IParEeService.GetUpdateReport(parEe);
            return Json(_log_result);
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
                return JavaScript("showFile(" + category_id + ")");
            }
            catch (Exception exp)
            {
                return JavaScript("Error:" + exp);
            }
        }

        [HttpPost]//文件上传-数据库更新
        public ActionResult InsertFile(int tracking_id, string file_url, byte category_id)
        {
            string user_detailed = GetUserName() + GetUserEmplyeeName();
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
                return Json(category_id);//文件类型
            }
            else
            {
                return Json("0");
            }
        }

        [HttpPost]//文件上传-服务器接收
        public ActionResult UploadFile()
        {
            try
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
                FileHelper.RequestUpload(imgFile, AbsolutePath);
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
            catch (Exception)
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