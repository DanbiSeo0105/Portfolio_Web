using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NMHI.Models.Repository.INTRA;
using NMHI.Models.Domain.INTRA;
using NMHI.Models.Domain.COMN;
using NMHI.Models.Repository.COMN;
using System.Data;
using NMHI.Utility;
using System.IO;

namespace NMHI.Controllers.INTRA
{
    
    public class EmpInfoController : Controller
    {
        private EmpInfoData data = new EmpInfoData();

        /// <summary>
        /// Description : Information of employees
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.20
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult Index(EmpInfoEnt ent)
        {
            ent.pWrkStatCd = string.IsNullOrEmpty(ent.pWrkStatCd) ? "01" : ent.pWrkStatCd;
            ViewBag.ent = ent;
            return View();
        }

        /// <summary>
        /// Description : List of employees
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.20
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult List(EmpInfoEnt ent)
        {
            #region params for paging
            if (ent.page == 0) { ent.page = 1; } //current page
            ent.page_sz = 17;                    //size of page
            ent.tot = data.GetListCnt(ent);
            #endregion

            ViewBag.ent = ent;
            ViewBag.dt = data.GetList(ent);

            return PartialView();
        }

        /// <summary>
        /// Description : Details of employees
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.20
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult Detail(EmpInfoEnt ent)
        {
            ViewBag.ent = ent;
			ViewBag.empList = data.GetEmpList(ent);
            ViewBag.drVct = data.GetVctInfo(ent);

            return View();
        }

        /// <summary>
        /// Description : Partial view
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.58
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult Detail_Content(EmpInfoEnt ent)
        {
            ViewBag.ent = ent;			
            ViewBag.dr = data.EmpDetail(ent);

            return PartialView();
        }

        /// <summary>
        /// Description : History of employee information
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.23
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult HstList(EmpInfoEnt ent)
        {
            ViewBag.ent = ent;
            ViewBag.dt = data.GetHstList(ent);

            return PartialView();
        }
        /// <summary>
        /// Description : Extra information
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.24
        ///  
        /// </summary>
        /// <returns></returns>
        public PartialViewResult AddInfo(EmpInfoEnt ent)
        {
            ViewBag.ent = ent;
            switch (ent.pTabDvs)
            {
                case "tot":
                    ViewBag.dtInd = data.GetIndRsltList(ent);
                    ViewBag.dtEve = data.GetEvltList(ent);
                    ViewBag.dtExam = data.GetExamList(ent);
                    break;
                case "exam" :
                    ViewBag.dt = data.GetExamList(ent);
                    break;
                case "eve":
                    ViewBag.dt = data.GetEvltList(ent);
                    break;
                case "cnsl" :
                    ViewBag.dt = data.GetCnslList(ent);
                    break;
                case "prs":
                    ViewBag.dt = data.GetPrsList(ent);
                    break;
                default :
                    break;
            }
            return PartialView();
        }

        public JsonResult AddInfoDetail(EmpInfoEnt ent)
        {
            DataRow dr = null;

            switch (ent.pTabDvs)
            {
                case "exam" :
                    dr = data.GetExamInfo(ent);
                    break;
                case "eve" :
                    dr = data.GetEvltInfo(ent);
                    break;
                case "cnsl":
                    dr = data.GetCnslInfo(ent);
                    break;
                case "prs":
                    dr = data.GetPrsInfo(ent);
                    break; 
                default:
                    break;
            }
            if (dr != null)
            {
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;

                row = new Dictionary<string, object>();
                foreach (DataColumn col in dr.Table.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);

                return Json(rows);
            }
            else
            {
                return Json("none");
            }
        }

        /// <summary>
        /// Description : Insert ot update employee information
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.20
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult UpdateBiz(EmpInfoEnt ent)
        {
            ent.userIP = Request.UserHostAddress;
            ent.pStdDt = ent.pStdDt.Replace(",", "");

            ComnData cd = new ComnData();
            RsltEnt rslt = new RsltEnt();
            string strMode = ent.hdnMode;


            #region attach file

            HttpPostedFileBase flePto = Request.Files["flePto"];

            // Uploadig photo
            if (flePto != null)
            {
                string strSavePath = Config.GetFileDir("CM_EMP_MST.PTO_NM", Server.MapPath("/")), strFullPath;
                if (flePto.FileName.Length > 0)
                {
                    strFullPath = Config.GetUniqueFileName(strSavePath, flePto.FileName);
                    flePto.SaveAs(strFullPath);

                    ent.pPtoNm = strFullPath.Substring(strFullPath.LastIndexOf("\\") + 1);
                }
            }

            #endregion

            #region 
            if (ent.hdnMode == "I")
            {
                rslt = cd.Update(ent, strMode, "EmpInfo.InsEmp");
                if (rslt.bRslt)
                {   //CM_EMP_HST procedure
                    rslt.bRslt = data.GetEmpHstBiz(ent);
                }
            }
            else if (ent.hdnMode == "U")
            {
                rslt = cd.Update(ent, strMode, "EmpInfo.UpdEmp");
            }
            else if (ent.hdnMode == "H") // adding history
            {
                if (ent.pPtoNm == "")
                {   // original image INSERT
                    ent.pPtoNm = ent.hdnPto;
                }
                rslt = cd.Update(ent, strMode, "EmpInfo.InsEmp");
            }
            #endregion
            
            return Json(rslt, "text/json");
        }

        /// <summary>
        /// Description : Delete History of employee
        /// Written By : Danbi Seo
        /// Date Written : 2016.03.22
        /// 
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult Delete(EmpInfoEnt ent)
        {
            ComnData cd = new ComnData();
            RsltEnt rslt = cd.Update(ent, "D", "EmpInfo.DelEmp");
            return Json(rslt);
        }
        /// <summary>
        /// Description : Extra information (exam info, consulting info) Input_biz
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.25
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public JsonResult AddInfoInputBiz(EmpInfoEnt ent)
        {
            ent.userIP = Request.UserHostAddress;
            ComnData cd = new ComnData();

            string strMapUrl = string.Empty;

            switch (ent.pTabDvs)
            {
                case "exam" :
                    ent.txtExamDt = ent.txtExamDt.Replace("-", "");
                    switch (ent.hdnAddInfoMode)
                    {
                        case "I":
                            ent.txtExamSeq = data.GetMaxExamSeq(ent);
                            strMapUrl = "EmpInfo.InsExam";
                            break;
                        case "U":
                            strMapUrl = "EmpInfo.UpdExam";
                            break;
                        case "D":
                            strMapUrl = "EmpInfo.DelExam";
                            break;
                        default:
                            break;
                    }
                    break;
                case "cnsl" :
                    ent.txtCnslDt = ent.txtCnslDt.Replace("-", "");
                    switch (ent.hdnAddInfoMode)
                    {
                        case "I":
                            ent.txtCnslSeq = data.GetMaxCnslSeq(ent);
                            strMapUrl = "EmpInfo.InsCnsl";
                            break;
                        case "U":
                            strMapUrl = "EmpInfo.UpdCnsl";
                            break;
                        case "D":
                            strMapUrl = "EmpInfo.DelCnsl";
                            break;
                        default:
                            break;
                    }
                    break;
                case "prs":
                    ent.txtPrsDt = ent.txtPrsDt.Replace("-", "");
                    switch (ent.hdnAddInfoMode)
                    {
                        case "I":
                            ent.txtPrsSeq = data.GetMaxPrsSeq(ent);
                            strMapUrl = "EmpInfo.InsPrs";
                            break;
                        case "U":
                            strMapUrl = "EmpInfo.UpdPrs";
                            break;
                        case "D":
                            strMapUrl = "EmpInfo.DelPrs";
                            break;
                        default:
                            break;
                    }
                    break;
            }
            RsltEnt rslt = cd.Update(ent, ent.hdnAddInfoMode, strMapUrl);
            return Json(rslt);
        }
    }
}
