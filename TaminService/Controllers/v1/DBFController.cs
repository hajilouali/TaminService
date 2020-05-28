using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Bessines;
using WebFramework.Api;

namespace TaminService.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class DBFController : BaseController
    {
        [HttpGet("[action]")]
        public virtual async Task<ActionResult<bool>> CheckTokenIsValid(CancellationToken cancellationToken)
        {
            try
            {
                var moel = new BusinessLogicLayer.tblSalInsurenceDiskFactory()
                {
                    DSK_ADRS = "تهران",
                    DSK_BIC = 0,
                    DSK_BIMH = 0,
                    DSK_DISC = "",
                    DSK_FARM = "درمت",
                    DSK_ID = "001",
                    DSK_KIND = 0,
                    DSK_LISTNO = "1",
                    DSK_MM = 02,
                    DSK_NAME = "تولدی دُرمت",
                    DSK_NUM = 10,
                    DSK_PRATE = 30,
                    DSK_RATE = 30,
                    DSK_TBIME = 0,
                    DSK_TDD = 0,
                    DSK_TKOSO = 0,
                    DSK_TMAH = 0,
                    DSK_TMASH = 0,
                    DSK_TMAZ = 0,
                    DSK_TROOZ = 0,
                    DSK_TTOTL = 0,
                    DSK_YY = 1399,
                    insAutoID = 0,
                    MON_PYM = "009",

                };
                var dto = new System.Collections.Generic.List<BusinessLogicLayer.tblSalInsurenceDiskPersonal>()
            {
                new BusinessLogicLayer.tblSalInsurenceDiskPersonal()
                {
                    DayAddCount=0,
                    insAutoID=0,
                     DSW_BDATE="1365/12/23",
                     DSW_BIME=0,
                     DSW_DD=0,
                     DSW_DNAME="اباذر",
                     DSW_EDATE="1399/02/31",
                     DSW_FNAME="علی",
                     DSW_ID="093314511",
                     DSW_ID1="001123456",
                     DSW_IDATE="1399/03/02",
                     DSW_IDNO="3721",
                     DSW_IDPLC="تهران",
                     DSW_JOB="OA3070",
                     DSW_LISTNO="001",
                     DSW_LNAME="حاجی لو",
                     DSW_MAH=0,
                     DSW_MASH=0,
                     DSW_MAZ=0,
                     DSW_MM=2,
                     DSW_NAT="ایرانی",
                     DSW_OCP="کارگر درمت",
                     DSW_PRATE=30,
                     DSW_ROOZ=0,
                     DSW_SDATE="1399/02/01",
                     DSW_SEX="مرد",
                     DSW_TOTL=0,
                     DSW_YY=1399,
                     PER_NATCOD="0079140025",
                     piPersonalID="",
                }
            };
                clsSalInsurenceDisk.CreateDBFPersonal(dto, "D:\\");
                clsSalInsurenceDisk.CreateDBFFactory(moel, "D:\\");
                return Ok(false);
            }
            catch
            {
                return Ok(false);
            }
        }
    }
}