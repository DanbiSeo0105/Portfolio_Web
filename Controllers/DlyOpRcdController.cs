using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NMHI.Models.Repository.HIMS;
using NMHI.Models.Domain.COMN;
using NMHI.Models.Repository.COMN;
using System.Data;
using NMHI.Controllers.COMN;
using NMHI.Utility;

namespace NMHI.Controllers.HIMS
{
    /// <summary>
    /// [HIMS] Record of treatment > Weekly/Monthly record of doctor
    /// </summary>
    public class DlyOpRcdController : Controller
    {
        private DlyOpRcdData data = new DlyOpRcdData();

        /// <summary>
        /// Description : Individual Doctor's record
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.15
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult Index(ComnEnt ent)
        {
            ent.pPrdDvsCd = string.IsNullOrEmpty(ent.type) ? "D" : ent.type;
            ent.pCond3 = string.IsNullOrEmpty(ent.pCond3) ? "1" : ent.pCond3; 
            ent.pCond2 = ent.pCond3 == "1" ? "1" : "2";            
            ent.pPrdYm = ent.pPrdYr + ent.pPrdMm;                                    
            
            ViewBag.ent = ent;
            ViewBag.dtHeader = (new ComnData()).GetScrnIndList(ent.sesHspCd, ent.pMenuCd, ent.pCond3, "ADMIN");
            ViewBag.dt = data.GetEmpList(ent);

            return View();
        }

        /// <summary>
        /// Description : Graph for doctor's record
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.15
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public JsonResult Charts(ComnEnt ent)
        {
            DataTable dt = data.GetDetail(ent);
            UnitInfo unitInfo = (new UnitInfo()).GetUnitInfo(dt, 6);
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            if (dt.Rows.Count > 0)
            {
                List<object> arrValue = new List<object>();

                int nIndex = 0;
                int nRowCnt = dt.Rows.Count;
                var query = from dr in dt.AsEnumerable()
                            group dr by dr.Field<string>("EMP_NM") into cg
                            select new { IND_CD = cg.Max(dr => dr.Field<string>("EMP_NM")) };
                int tempCnt = query.Count();
                int nRow1 = nRowCnt / query.Count() - 1;
                int nRow2 = nRowCnt / query.Count() * 2 - 1;
                int nRow3 = nRowCnt / query.Count() * 3 - 1;
                int nRow4 = nRowCnt / query.Count() * 4 - 1;
                int nRow5 = nRowCnt / query.Count() * 5 - 1;
                int nRow6 = nRowCnt / query.Count() * 6 - 1;
                int nRow7 = nRowCnt / query.Count() * 7 - 1;
                int nRow8 = nRowCnt / query.Count() * 8 - 1;
                int nRow9 = nRowCnt / query.Count() * 9 - 1;
                int nRow10 = nRowCnt / query.Count() * 10 - 1;
                int nRow11 = nRowCnt / query.Count() * 11 - 1;
                int nRow12 = nRowCnt / query.Count() * 12 - 1;
                int nRow13 = nRowCnt;

                object[] arrObj = new object[dt.Rows.Count / query.Count()];

                string strType = "column", strColor = "#00b3f6";
                string strUnitType = "";
                foreach (DataRow dr in dt.Rows)
                {
                    arrValue.Add(Math.Round(Convert.ToDouble(dr[6]) / unitInfo.Div, 2));

                    if (nIndex < nRow1 + 1) arrObj[nIndex] = dr[1];

                    if (nIndex == nRow1)
                    {
                        strType = "column";
                    }
                    else if (nIndex == nRow2)
                    {
                        strType = "column";
                        strColor = "#00d620";
                    }
                    else if (nIndex == nRow3)
                    {
                        strType = "column";
                        strColor = "#af9301";
                    }
                    else if (nIndex == nRow4)
                    {
                        strType = "column";
                        strColor = "#fe3507";
                    }
                    else if (nIndex == nRow5)
                    {
                        strType = "column";
                        strColor = "#F29661";
                    }
                    else if (nIndex == nRow6)
                    {
                        strType = "column";
                        strColor = "#d646fe";
                    }
                    else if (nIndex == nRow7)
                    {
                        strType = "column";
                        strColor = "#D9418C";
                    }
                    else if (nIndex == nRow8)
                    {
                        strType = "column";
                        strColor = "#050099";
                    }
                    else if (nIndex == nRow9)
                    {
                        strType = "column";
                        strColor = "#826afe";
                    }
                    else if (nIndex == nRow10)
                    {
                        strType = "column";
                        strColor = "#FFE400";
                    }
                    else if (nIndex == nRow11)
                    {
                        strType = "column";
                        strColor = "#A6A6A6";
                    }
                    else if (nIndex == nRow12)
                    {
                        strType = "column";
                        strColor = "#FF5E00";
                    }
                    else if (nIndex == nRow13)
                    {
                        strType = "column";
                        strColor = "#CEF279";
                    }

                    if (nIndex == nRow1 || nIndex == nRow2 || nIndex == nRow3 || nIndex == nRow4 || nIndex == nRow5 || nIndex == nRow6 || nIndex == nRow7 || nIndex == nRow8 || nIndex == nRow9 || nIndex == nRow10 || nIndex == nRow11 || nIndex == nRow12 || nIndex == nRow13)
                    {
                        Dictionary<string, object> lst = new Dictionary<string, object>();
                        lst.Add("name", dr[3]);
                        lst.Add("data", arrValue);
                        lst.Add("type", strType);
                        lst.Add("color", strColor);
                        lst.Add("unit", (unitInfo.UnitNm == "" ? strUnitType : unitInfo.UnitNm));
                        if (nIndex == nRow1) lst.Add("categories", arrObj);
                        arrValue = new List<object>();
                        rows.Add(lst);
                    }
                    nIndex++;
                }
            }
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Description : List of ratio
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.15
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult EmpRtoList(ComnEnt ent)
        {
            ent.pPrdDvsCd = string.IsNullOrEmpty(ent.type) ? "D" : ent.type;            
            ViewBag.ent = ent;
			
            DataTable dt = (new OpRcd00000Data()).GetIndEmpRtoList(ent);
            ViewBag.dt = dt;
            TempData["dt"] = dt;

            return PartialView();
        }

        /// <summary>
        /// Description : Pie chart for doctor's record
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.15
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult EmpRtoChart(ComnEnt ent)
        {
            DataTable dt;
            ent.pPrdDvsCd = string.IsNullOrEmpty(ent.type) ? "D" : ent.type;

            dt = (new OpRcd00000Data()).GetIndEmpRtoList(ent);
            UnitInfo unitInfo = (new UnitInfo()).GetUnitInfo(dt, 5);
            List<Dictionary<string, object>> rows = Chart.GetPieData(dt, unitInfo);

            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Description : The list of index
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.15
        ///  
        /// </summary>
        /// <returns></returns>
        public ActionResult IndList(ComnEnt ent)
        {
            ent.pPrdDvsCd = string.IsNullOrEmpty(ent.type) ? "D" : ent.type;
            ent.pCond1 = ent.pCond3 == "1" ? "1" : "2";
            ViewBag.ent = ent;

            ViewBag.drEmp = (new ComnData()).GetEmpDetail(ent.sesHspCd, ent.pPrdYm, ent.pEmpNo);
            ViewBag.dt = (new OpRcd00000Data()).GetIndList(ent);
            return PartialView();
        }

        /// <summary>
        /// Description : Chart for trend of records
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.15
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ActionResult PscdChart(ComnEnt ent)
        {
            ent.pPrdDvsCd = string.IsNullOrEmpty(ent.type) ? "D" : ent.type;

            List<Dictionary<string, object>> rows;
            DataTable dt;
            UnitInfo unitInfo;
            if (ent.pEmpNo != string.Empty)
            {
                ent.pEmpNm = ent.pEmpNo == "-" ? "Etc." : (new ComnData()).GetEmpNm(ent.sesHspCd, ent.pEmpNo, ent.pPrdDvsCd == "M" ? ent.pPrdYm : "");
            }

            if (ent.pCond1 == string.Empty)
            {
                //No refresh the original value of UnitInfo
                if (ent.pEmpNo == string.Empty) //The average of department
                {
                    dt = (new OpRcd00000Data()).GetIndAvgPscdList(ent);

                    //1. When search for the average of hospital or the average of department, refresh UnitInfo 
                    unitInfo = (new UnitInfo()).GetUnitInfo(dt, 2);
                    TempData["unitInfo"] = unitInfo;

                    rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> lstHspAvg = new Dictionary<string, object>();
                    List<object> arrHspAvg = new List<object>();

                    int nIndex = 0;
                    object[] arrObj = new object[dt.Rows.Count];

                    string strUnitType = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        strUnitType = dr["UNIT_TYP"].ToString();
                        arrObj[nIndex] = dr["PRD"];
                        arrHspAvg.Add(Math.Round(Convert.ToDouble(dr["HSP_AVG"]) / unitInfo.Div, 1));
                        nIndex++;
                    }

                    lstHspAvg.Add("id", "HSP_AVG");
                    lstHspAvg.Add("name", "The average of Hospital");
                    lstHspAvg.Add("data", arrHspAvg);
                    lstHspAvg.Add("categories", arrObj);
                    lstHspAvg.Add("unit", (unitInfo.UnitNm == "" ? strUnitType : unitInfo.UnitNm));
                    rows.Add(lstHspAvg);
                }
                else
                {
                    dt = (new DlyOpRcdData()).GetIndPscdList(ent);

					//When search for the individual record, bring the value for UnitInfo from TempData
                    unitInfo = TempData["unitInfo"] != null ? (UnitInfo)TempData["unitInfo"] : (new UnitInfo()).GetUnitInfo(dt, 2);
                    TempData["unitInfo"] = unitInfo;

                    rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> lstRslt = new Dictionary<string, object>();
                    List<object> arrRslt = new List<object>();

                    int nIndex = 0;
                    object[] arrObj = new object[dt.Rows.Count];
                    string strUnitType = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        strUnitType = dr["UNIT_TYP"].ToString();
                        arrRslt.Add(Math.Round(Convert.ToDouble(dr["RSLT"]) / unitInfo.Div, 2));
                        nIndex++;
                    }

                    lstRslt.Add("id", ent.pEmpNo);
                    lstRslt.Add("name", ent.pEmpNm);
                    lstRslt.Add("data", arrRslt);
                    rows.Add(lstRslt);
                }
            }
            else
            {
				// When the value is 'EmpPop', search the average record of hospital or doctors the EmpPop at once.
                dt = (new DlyOpRcdData()).GetIndEmpWithAvgPscdList(ent); 
                unitInfo = (new UnitInfo()).GetUnitInfo(dt, 2, 3);
                rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> lstHspAvg = new Dictionary<string, object>();
                Dictionary<string, object> lstRslt = new Dictionary<string, object>();
                List<object> arrHspAvg = new List<object>();
                List<object> arrRslt = new List<object>();

                int nIndex = 0;
                object[] arrObj = new object[dt.Rows.Count];

                string strUnitType = "";
                foreach (DataRow dr in dt.Rows)
                {
                    strUnitType = dr["UNIT_TYP"].ToString();
                    arrObj[nIndex] = dr["PRD"];
                    arrHspAvg.Add(Math.Round(Convert.ToDouble(dr["HSP_AVG"]) / unitInfo.Div, 1));
                    arrRslt.Add(Math.Round(Convert.ToDouble(dr["RSLT"]) / unitInfo.Div, 1));
                    nIndex++;
                }

                lstHspAvg.Add("id", "HSP_AVG");
                lstHspAvg.Add("name", "The average of Hospital");
                lstHspAvg.Add("data", arrHspAvg);
                lstHspAvg.Add("categories", arrObj);
                lstHspAvg.Add("unit", (unitInfo.UnitNm == "" ? strUnitType : unitInfo.UnitNm));
                rows.Add(lstHspAvg);
                lstRslt.Add("id", ent.pEmpNo);
                lstRslt.Add("name", ent.pEmpNm);
                lstRslt.Add("data", arrRslt);
                rows.Add(lstRslt);
            }

            return Json(rows, JsonRequestBehavior.AllowGet);
        }
    }
}
