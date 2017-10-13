using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using NMHI.Utility;
using NMHI.Models.Domain.COMN;

namespace NMHI.Models.Repository.HIMS
{
    /// <summary>
    /// [HIMS] Record of treatment > Weekly/Monthly record of doctor
    /// </summary>
    public class DlyOpRcdData
    {
        private DataTable dt = new DataTable();

        /// <summary>
        /// Description : Individual Doctor's record
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.15
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataTable GetEmpList(ComnEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("DlyOpRcd.SelEmpList", ent);
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
        /// Description : Graph for doctor's record
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.15
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataTable GetDetail(ComnEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("DlyOpRcd.SelDetail", ent);
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
        /// Description : Chart for trend of records
        /// Written By : Danbi Seo
        /// Date Written : 2016.04.29
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataTable GetIndPscdList(ComnEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("DlyOpRcd.SelIndPscdList", ent);
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
        /// Description : Record trend of the average of hopital or doctors(Except Sunday)
        /// Written By : Danbi Seo
        /// Date Written : 2016.06.05
        ///  
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public DataTable GetIndEmpWithAvgPscdList(ComnEnt ent)
        {
            try
            {
                dt = Config.QueryForTable("DlyOpRcd.SelIndEmpWithAvgPscdList", ent);
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
    }
}