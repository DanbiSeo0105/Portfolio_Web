﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using NMHI.Models.Domain.INTRA;
using NMHI.Utility;
using IBatisNet.DataMapper;
using NMHI.Models.Domain.COMN;

namespace NMHI.Models.Repository.INTRA
{
    /// <summary>
    /// [Intranet] Community > Employees information
    /// </summary>
    public class EmpInfoData
    {
        private DataTable dt = new DataTable();
        private ISqlMapper mapper = EMapper.Instance;

        /// <summary>
        /// Description : Counting employee list (for paging)
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.20
        ///  
        /// </summary>
        /// <returns></returns>        
        public int GetListCnt(EmpInfoEnt ent)
        {
            try
            {
                return Convert.ToInt32(mapper.QueryForObject("EmpInfo.SelListCnt", ent));
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Description : List of employees
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.20
        ///  
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.SelList", ent);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                dt.Dispose();
            }
        }

        /// <summary>
        /// Description : Details of employees
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.23
        ///  
        /// </summary>
        /// <returns></returns>
        public DataRow EmpDetail(EmpInfoEnt ent)
        {
            try
            {        
                dt = Config.QueryForTable("EmpInfo.EmpDetail", ent);
                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                dt.Dispose();
            }
        }


		/// <summary>
		/// Description : List of employees
		/// Written By : Danbi Seo
		/// Date Written : 2016.09.02
		/// 
		/// Contents : If register new employee, check the duplication.
		///  
		/// </summary>
		/// <returns></returns>
		public DataTable GetEmpList(EmpInfoEnt ent)
		{
			try
			{
				dt = Config.QueryForTable("EmpInfo.SelEmpList", ent);
				return dt;
			}
			catch
			{
				return dt;
			}
			finally
			{
				dt.Dispose();
			}
		}


        /// <summary>
        /// Description : day off
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.24
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataRow GetVctInfo(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.SelVctInfo", ent);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                dt.Dispose();
            }
        }

        /// <summary>
        /// Description : History of employee information
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.26
        ///  
        /// </summary>
        /// <returns></returns>
        public DataTable GetHstList(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.SelHstList", ent);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                dt.Dispose();
            }
        }


        /// <summary>
        /// Description : Update employee information
        /// Written By : Danbi Seo
        /// Date Written : 2016.01.20
        ///  
        /// </summary>
        /// <returns></returns>
        public DataTable UpdateBiz(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.UpdateBiz", ent);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                dt.Dispose();
            }
        }
        /// <summary>
        /// Description : List of evaluation for records
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.26
		///
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataTable GetIndRsltList(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.SelIndRslt", ent);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                dt.Dispose();
            }
        }
        /// <summary>
        /// Description : List of exam history
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.24
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataTable GetExamList(EmpInfoEnt ent)
        {
            try{
                dt = Config.QueryForTable("EmpInfo.SelExamList", ent);
                return dt;
            }catch{
                return dt;
            }finally{
                dt.Dispose();
            }
        }
        /// <summary>
        /// Description : Details of exam history
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.24
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataRow GetExamInfo(EmpInfoEnt ent)
        {
            try{
                dt = Config.QueryForTable("EmpInfo.SelExamList",ent);
                if(dt.Rows.Count > 0){
                    return dt.Rows[0];
                }else{
                    return null;
                }
            }catch{
                return null;
            }finally{
                dt.Dispose();
            }
        }
        /// <summary>
        /// Description : List of evaluation 
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.24
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataTable GetEvltList(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.SelEvltList", ent);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                dt.Dispose();
            }
        }
        /// <summary>
        /// Description : Details of evaluation 
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.24
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataRow GetEvltInfo(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.SelEvltList", ent);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                dt.Dispose();
            }
        }
        /// <summary>
        /// Description : List of consulting history
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.24
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataTable GetCnslList(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.SelCnslList", ent);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                dt.Dispose();
            }
        }
        /// <summary>
        /// Description : Details of consulting history
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.24
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataRow GetCnslInfo(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.SelCnslList", ent);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                dt.Dispose();
            }
        }


        /// <summary>
        /// Description : List of compliment history
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.29
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataTable GetPrsList(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.SelPrsList", ent);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                dt.Dispose();
            }
        }


        /// <summary>
        /// Description : Details of compliment history
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.29
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataRow GetPrsInfo(EmpInfoEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("EmpInfo.SelPrsList", ent);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                dt.Dispose();
            }
        }


        /// <summary>
        /// Description : Max seq of exam history
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.25
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public int GetMaxExamSeq(EmpInfoEnt ent)
        {
            try
            {
                return Convert.ToInt32(mapper.QueryForObject("EmpInfo.SelMaxExamSeq", ent));
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Description : Max seq of consulting history
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.25
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public int GetMaxCnslSeq(EmpInfoEnt ent)
        {
            try
            {
                return Convert.ToInt32(mapper.QueryForObject("EmpInfo.SelMaxCnslSeq", ent));
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Description : Max seq of compliment history
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.25
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public int GetMaxPrsSeq(EmpInfoEnt ent)
        {
            try
            {
                return Convert.ToInt32(mapper.QueryForObject("EmpInfo.SelMaxPrsSeq", ent));
            }
            catch
            {
                return 1;
            }
        }

        // <summary>
        /// Description : When inserting initial data to employees master table, re-execute a history procedure 
		/// Written By : Danbi Seo
        /// Date Written : 2016.09.13
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public bool GetEmpHstBiz(EmpInfoEnt ent)
        {
            try
            {
                //calculate difference between current month and standard month.
                int tYear = DateTime.Now.Year;
                int tMonth = DateTime.Now.Month;
                int pStdYear = Convert.ToInt32(ent.pStdDt.Substring(0,4));
                int pStdMonth = Convert.ToInt32(ent.pStdDt.Substring(4,2));
                int pRange;
				
				//If standard month is later than current month, execute procedure for just standard month.
                if (Convert.ToInt32(DateTime.Now.ToString("yyyyMM")) < Convert.ToInt32(ent.pStdDt.Substring(0, 6)))
                {
                    pRange = 1;
                }
                else     //If standard month is ealier than current month, execute procedure for previous month.
                {
                    if (tYear != pStdYear)
                    {
                        int year = (tYear - pStdYear) - 1;
                        pRange = (year * 12) + (12 - pStdMonth + 1) + tMonth;
                    }
                    else
                    {
                        pRange = (tMonth - pStdMonth) + 1;
                    }
                }

                DateTime pStdDt = Convert.ToDateTime(ent.pStdDt.Substring(0, 4) + "-" + ent.pStdDt.Substring(4, 2) + "-01");
                for (int i = 0; i < pRange; i++)
                {  
                    ent.pStdDt = i == 0 ? ent.pStdDt : pStdDt.AddMonths(i).ToString("yyyyMMdd");
                    mapper.QueryForObject("EmpInfo.PrcPpCmEmpHst", ent);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}