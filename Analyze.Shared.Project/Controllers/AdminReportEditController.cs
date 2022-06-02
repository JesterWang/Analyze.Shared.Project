using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common;
using Analyze.Shared.Common.Report;
using Analyze.Shared.DataAccess;
using Analyze.Shared.Project.Utility.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Controllers
{
    [CustomAuthorizeAttribute]
    public class AdminReportEditController : BaseController
    {
        private IParInformationSummaryService _IParInformationSummaryService = null;
        private IParFileService _IParFileService = null;
        private IParFaeService _IParFaeService = null;
        private IParMeService _IParMeService = null;
        private IParEeService _IParEeService = null;
        private IParMaterialsService _IParMaterialsService = null;
        private IParSmtService _IParSmtService = null;
        private IParBeService _IParBeService = null;
        private IParTestService _IParTestService = null;

        public AdminReportEditController(IParInformationSummaryService iParInformationSummaryService, IParFileService iParFileService, IParFaeService iParFaeService, IParMeService iParMeService,
            IParEeService iParEeService, IParMaterialsService iParMaterialsService, IParSmtService iParSmtService,
            IParBeService iParBeService, IParTestService iParTestService)
        {
            _IParInformationSummaryService = iParInformationSummaryService;
            _IParFileService = iParFileService;

            _IParFaeService = iParFaeService;
            _IParMeService = iParMeService;
            _IParEeService = iParEeService;
            _IParMaterialsService = iParMaterialsService;
            _IParSmtService = iParSmtService;
            _IParBeService = iParBeService;
            _IParTestService = iParTestService;
        }

        // GET: Home
        [CustomCrumbsActionFilterAttribute]
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

        #region 总结报告
        [HttpPost]//基础信息查询
        public ActionResult PaertViewIndexParGroup(int tracking_id, byte category_id)
        {
            ParList parlist = new ParList();
            List<ParInformationSummary> listParGroup = new List<ParInformationSummary>();
            ParInformationSummary parInformationSummary = _IParInformationSummaryService.GetQueryReport(tracking_id);
            listParGroup.Add(parInformationSummary);
            parlist.ParInformationSummary = listParGroup;

            List<ParFileUpload> listParFileUpload = _IParFileService.GetQuery(tracking_id, category_id);
            parlist.ParFileUpload = listParFileUpload;

            return base.PartialView("PaertViewIndexParGroup", parlist);
        }

        [HttpPost]//基础信息修改
        public ActionResult PaertViewIndexParGroupUpdate(int tracking_id, string tracking_number, string title, string tracking_time, string site, string model,
            string defect_rate, string isline, string group_image, string group_image_old, string problem_description, string root_cause, string analysis_conclusion, string next_steps, string log_result, string user)
        {
            if (group_image_old != group_image) 
            {
                if (System.IO.File.Exists((Server.MapPath("~") + group_image_old).Replace("/", "\\")))
                {
                    System.IO.File.Delete(Server.MapPath("~") + group_image_old.Replace("/", "\\"));
                }
            }
            if (group_image == "") { group_image = null; }
            string _log_result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " by " + user + " update;" + "\r\n" + log_result;
            ParInformationSummary parGroup = new ParInformationSummary()
            {
                tracking_id = tracking_id,
                tracking_number=tracking_number,
                title = title,
                tracking_time = Convert.ToDateTime(tracking_time),
                site = site,
                model = model,
                defect_rate = defect_rate,
                isline=isline,
                group_image=group_image,
                problem_description = problem_description,
                root_cause = root_cause,
                analysis_conclusion = analysis_conclusion,
                next_steps = next_steps,
                update_time = DateTime.Now,
                log_result = _log_result
            };
            bool b = _IParInformationSummaryService.Update(parGroup);
            return Json(_log_result);
        }

        #endregion

        #region FAE分析报告
        [HttpPost]//基础信息查询
        public ActionResult PaertViewIndexParFae(int tracking_id, byte category_id)
        {
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
        
        #region Materials分析报告
        [HttpPost]//基础信息查询
        public ActionResult PaertViewIndexParMaterials(int tracking_id, byte category_id)
        {
            ParList parlist = new ParList();
            List<ParMaterials> listParMaterials = new List<ParMaterials>();
            ParMaterials parMaterials = _IParMaterialsService.GetQueryReport(tracking_id);
            listParMaterials.Add(parMaterials);
            parlist.ParMaterials = listParMaterials;

            //这里需要传递四个category_id
            int category_id_1 = 0;
            int category_id_2 = 0;
            int category_id_3 = 0;
            int category_id_4 = 0;
            if (category_id == 4 || category_id == 5 || category_id == 6 || category_id == 7) 
            {
                category_id_1 = 4;
                category_id_2 = 5;
                category_id_3 = 6;
                category_id_4 = 7;
            }
            List<ViewParFile> listViewParFile = _IParFileService.GetQueryView(tracking_id, category_id_1, category_id_2, category_id_3, category_id_4);
            parlist.ViewParFile = listViewParFile;

            return base.PartialView("PaertViewIndexParMaterials", parlist);
        }

        [HttpPost]//基础信息修改
        public JsonResult PaertViewIndexParMaterialsUpdate(int tracking_id, string materials_steps_1, string materials_steps_2,string materials_steps_3,string materials_steps_4, string log_result, string user)
        {
            string _log_result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " by " + user + " update;" + "\r\n" + log_result;
            ParMaterials parMaterials = new ParMaterials()
            {
                tracking_id = tracking_id,
                materials_steps_1=materials_steps_1,
                materials_steps_2=materials_steps_2,
                materials_steps_3=materials_steps_3,
                materials_steps_4=materials_steps_4,
                log_result = _log_result
            };
            bool b = _IParMaterialsService.GetUpdateReport(parMaterials);
            return Json(_log_result);
        }
        #endregion

        #region Smt分析报告
        [HttpPost]//基础信息查询
        public ActionResult PaertViewIndexParSmt(int tracking_id, byte category_id)
        {
            ParList parlist = new ParList();
            List<ParSmt> listParSmt = new List<ParSmt>();
            ParSmt parSmt = _IParSmtService.GetQueryReport(tracking_id);
            listParSmt.Add(parSmt);
            parlist.ParSmt = listParSmt;

            //这里需要传递四个category_id
            int category_id_1 = 0;
            int category_id_2 = 0;
            int category_id_3 = 0;
            int category_id_4 = 0;
            if (category_id == 8 || category_id == 9 || category_id == 10 || category_id == 11)
            {
                category_id_1 = 8;
                category_id_2 = 9;
                category_id_3 = 10;
                category_id_4 = 11;
            }
            List<ViewParFile> listViewParFile = _IParFileService.GetQueryView(tracking_id, category_id_1, category_id_2, category_id_3, category_id_4);
            parlist.ViewParFile = listViewParFile;

            return base.PartialView("PaertViewIndexParSmt", parlist);
        }

        [HttpPost]//基础信息修改
        public ActionResult PaertViewIndexParSmtUpdate(int tracking_id, string man, string machine, string method, string environments, string log_result, string user)
        {
            string _log_result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " by " + user + " update;" + "\r\n" + log_result;
            ParSmt parSmt = new ParSmt()
            {
                tracking_id = tracking_id,
                man = man,
                machine = machine,
                method = method,
                environments = environments,
                log_result = _log_result
            };
            bool b = _IParSmtService.GetUpdateReport(parSmt);
            return Json(_log_result);
        }
        #endregion

        #region Be分析报告
        [HttpPost]//基础信息查询
        public ActionResult PaertViewIndexParBe(int tracking_id, byte category_id)
        {
            ParList parlist = new ParList();
            List<ParBe> listParBe = new List<ParBe>();
            ParBe parBe = _IParBeService.GetQueryReport(tracking_id);
            listParBe.Add(parBe);
            parlist.ParBe = listParBe;

            //这里需要传递四个category_id
            int category_id_1 = 0;
            int category_id_2 = 0;
            int category_id_3 = 0;
            int category_id_4 = 0;
            if (category_id == 12 || category_id == 13 || category_id == 14 || category_id == 15)
            {
                category_id_1 = 12;
                category_id_2 = 13;
                category_id_3 = 14;
                category_id_4 = 15;
            }
            List<ViewParFile> listViewParFile = _IParFileService.GetQueryView(tracking_id, category_id_1, category_id_2, category_id_3, category_id_4);
            parlist.ViewParFile = listViewParFile;

            return base.PartialView("PaertViewIndexParBe", parlist);
        }

        [HttpPost]//基础信息修改
        public ActionResult PaertViewIndexParBeUpdate(int tracking_id, string man, string machine, string method, string environments, string log_result, string user)
        {
            string _log_result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " by " + user + " update;" + "\r\n" + log_result;
            ParBe parBe = new ParBe()
            {
                tracking_id = tracking_id,
                man = man,
                machine = machine,
                method = method,
                environments = environments,
                log_result = _log_result
            };
            bool b = _IParBeService.GetUpdateReport(parBe);
            return Json(_log_result);
        }
        #endregion

        #region Test分析报告
        [HttpPost]//基础信息查询
        public ActionResult PaertViewIndexParTest(int tracking_id, byte category_id)
        {
            ParList parlist = new ParList();
            List<ParTest> listParTest = new List<ParTest>();
            ParTest parTest = _IParTestService.GetQueryReport(tracking_id);
            listParTest.Add(parTest);
            parlist.ParTest = listParTest;

            //这里需要传递四个category_id
            int category_id_1 = 0;
            int category_id_2 = 0;
            int category_id_3 = 0;
            int category_id_4 = 0;
            if (category_id == 16 || category_id == 17 || category_id == 18 || category_id == 19)
            {
                category_id_1 = 16;
                category_id_2 = 17;
                category_id_3 = 18;
                category_id_4 = 19;
            }
            List<ViewParFile> listViewParFile = _IParFileService.GetQueryView(tracking_id, category_id_1, category_id_2, category_id_3, category_id_4);
            parlist.ViewParFile = listViewParFile;

            return base.PartialView("PaertViewIndexParTest", parlist);
        }

        [HttpPost]//基础信息修改
        public ActionResult PaertViewIndexParTestUpdate(int tracking_id, string fe, string be, string cfc, string sdbu, string log_result, string user)
        {
            string _log_result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " by " + user + " update;" + "\r\n" + log_result;
            ParTest parTest = new ParTest()
            {
                tracking_id = tracking_id,
                fe = fe,
                be = be,
                cfc = cfc,
                sdbu = sdbu,
                log_result = _log_result
            };
            bool b = _IParTestService.GetUpdateReport(parTest);
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