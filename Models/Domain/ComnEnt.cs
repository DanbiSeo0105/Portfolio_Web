using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMHI.Models.Domain.COMN
{
    public class ComnEnt : UserInfo
    {
        // type QueryString
        public string type { get; set; }
        // Period
        public string pPrdDvsCd { get; set; }
        public string pPrdDt { get; set; }
        // Day
        public string pPrdYmd { get; set; }
        public string pEndYmd { get; set; }
        // Week
        public string pPrdYw { get; set; }
        public string pEndYw { get; set; }
        // Year and Month
        public string pPrdYr { get; set; }
        public string pPrdMm { get; set; }
        public string pEndYr { get; set; }
        public string pEndMm { get; set; }
        public string pPrdYm { get; set; }
        public string pEndYm { get; set; }
        // Quarterly
        public string pPrdQt { get; set; }
        // Biannually
        public string pPrdHf { get; set; }

        // Privilage group
        public string pGrpCd { get; set; }
        // Department
        public string pMedDvs { get; set; }
        public string pDeptCd { get; set; }
        public string pDeptNm { get; set; }
        // Name
        public string pEmpNo { get; set; }
        public string pEmpNm { get; set; }
        // Unit
        public string pUnitCd { get; set; }
        public string pUnitNm { get; set; }
        // Index
        public string pIndCd { get; set; }
        public string pIndNm { get; set; }
        // CRM
        public string pClsType { get; set; }

        // Increasing rate
        public int pTopRt { get; set; }
        public int pBotmRt { get; set; }
        // date range
        public string pMaxPrd { get; set; }
        public string pMinPrd { get; set; }
        // Menu code
        public string pMenuCd { get; set; }
        // Admin privilage
        public string pMngYn { get; set; }
        // Input privilage 
        public string pInptYn { get; set; }

        // Parameters for SMS
        public string pSmsUnitCd { get; set; }
        public string pSmsDeptCd { get; set; }
        public string pSmsEmpNo { get; set; }

        // Common
        public string pCond1 { get; set; }
        public string pCond2 { get; set; }
        public string pCond3 { get; set; }
        public string pCond4 { get; set; }
        public string[] pArrCond1 { get; set; }        

		/* In the popup for employee or department, used as flag for HST or MST */
        public string pPopTbTyp { get; set; } 

    }
}