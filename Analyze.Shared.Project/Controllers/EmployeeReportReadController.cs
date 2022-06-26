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
    public class EmployeeReportReadController : BaseController
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

        public EmployeeReportReadController(IParInformationSummaryService iParInformationSummaryService, IParFileService iParFileService, IParFaeService iParFaeService, IParMeService iParMeService,
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
        #endregion
        
        #region 文件操作
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

        [HttpGet]//文件预览
        public ActionResult ShowFile(string filePath)
        {
            string filename = Path.GetFileNameWithoutExtension(filePath);
            string path = Path.GetFileName(filePath);
            string path_ex = Path.GetExtension(filePath);
            string pathName = Server.MapPath(filePath);
            string type = "";

            if (path_ex == ".pdf")
            {
                type = "application/pdf";
            }
            if (path_ex == ".png")
            {
                return base.File(pathName, "image/png");
            }
            if (path_ex == ".jpg")
            {
                return base.File(pathName, "image/jpeg");
            }
            if (path_ex == ".gif")
            {
                return base.File(pathName, "image/gif");
            }
            if (path_ex != ".pdf" && path_ex != ".png" && path_ex != ".jpg" && path_ex != ".gif")
            {
                return Content("仅支持PDF,图片(PNG,JPG,GIF)格式预览");
            }
            byte[] FileBytes = System.IO.File.ReadAllBytes(pathName);
            return File(FileBytes, type);
        }
        #endregion


    }
}