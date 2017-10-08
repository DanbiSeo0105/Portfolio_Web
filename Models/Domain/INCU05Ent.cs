using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NMHI.Models.Domain.COMN;
using System.Web.Mvc;

namespace NMHI.Models.Domain.INTRA
{
    public class INCU05Ent : ComnEnt
    {
        /*GET PARAMETER*/

        public int page { get; set; }
        public int page_sz { get; set; }
        public int tot { get; set; }

        public string pSrchHspCd { get; set; }
        public string pPstnCd { get; set; }
        public string pWrkStatCd { get; set; }

        public string pHspCd { get; set; }
        public string pRealDeptCd { get; set; }
        public string pStdDt { get; set; }    

        public string txtPw { get; set; }
        public string cboHspCd { get; set; }
        public string hdnDeptCd { get; set; }
        public string hdnRealDeptCd { get; set; }
        public string cboOctyCd { get; set; }
        public string cboOcgrCd { get; set; }
        public string cboPstnCd { get; set; }
        public string cboOcrsCd { get; set; }
        public string InPrdYmd { get; set; }
        public string OutPrdYmd { get; set; }
        public string pBrdy { get; set; }
        public string rdoBrdyDvs { get; set; } //(S : Solar calendar, L : Lunar calendar)
        public string cboWrkSt { get; set; }
        public string txtEmpNo { get; set; }
        public string txtEmpNm { get; set; }
        public string txtAddr { get; set; }
        public string txtExtsNo { get; set; }  
        public string txtTelNo { get; set; }
        public string txtCPhn { get; set; }
        public string txtZipCd { get; set; }
        public string txtssno { get; set; }
        public string txtEmail { get; set; }

        public string pPtoNm { get; set; }
        public string pSignNm { get; set; }

        public string hdnPto { get; set; }  
        public string hdnSign { get; set; }  

        public string HSP_CD { get; set; }
        public string HSP_NM { get; set; }
        public string EMP_NO { get; set; }
        public string STD_DT { get; set; }
        public string EMP_NM { get; set; }
        public string PTO_NM { get; set; }
        public string SIGN_NM { get; set; }
        public string BRDY_DT { get; set; }
        public string BRDY_DVS { get; set; }
        public string SSNO { get; set; }
        public string PW { get; set; }
        public string EMAIL { get; set; }
        public string ZIP_CD { get; set; }
        public string ADDR { get; set; }
        public string JICP_DT { get; set; }
        public string LVCP_DT { get; set; }
        public string DEPT_CD { get; set; }
        public string DEPT_NM { get; set; }
        public string OCTY_CD { get; set; }
        public string OCTY_NM { get; set; }
        public string PSTN_CD { get; set; }
        public string PSTN_NM { get; set; }
        public string OCRS_CD { get; set; }
        public string OCRS_NM { get; set; }
        public string WRK_STAT_CD { get; set; }
        public string WRK_STAT_NM { get; set; }
        public string TEL_NO { get; set; }
        public string CLPH_NO { get; set; }
        public string REAL_HSP_CD { get; set; }
        public string REAL_DEPT_CD { get; set; }

        /*RESULT */

        /*POST PARAMETER*/
        public int hdnKeyNo { get; set; }
        public string chkSmsSendYn { get; set; }
        [AllowHtml]
        public string txaCnte { get; set; }
        public string rdoRecvInfoYn { get; set; }
        public string hdnRecvInfo { get; set; }
        public string hdnMode { get; set; } 

        public string fleAtch { get; set; }// file

        /* extra information on right slide */
        public string pTabDvs { get; set; }//Tab division
        public int pSeqNo { get; set; } 

        public string hdnAddInfoMode { get; set; }

        public int txtExamSeq { get; set; }
        public string txtExamDt { get; set; }
        public string cboExamCd { get; set; }
        public string hdnIncgEmpNo { get; set; }
        public string txtExamOrgNm { get; set; }
        public string txtExamScr { get; set; }
        public string rdoPassYN { get; set; }
        public string txaMemo { get; set; }

        public int txtCnslSeq { get; set; }
        public string txtCnslDt { get; set; }
        public string hdnCnslEmpNo { get; set; }
        public string cboCnslRsn { get; set; }
        public string txaCnslCnte { get; set; }


        public int txtPrsSeq { get; set; }
        public string txtPrsDt { get; set; }
        public string hdnPrsEmpNo { get; set; }
        public string txaPrsCnte { get; set; }        

    }
}