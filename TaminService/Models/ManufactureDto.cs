using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminService.Models
{
    public class ManufactureDto:BaseDto<ManufactureDto,Manufacturys>
    {
        public int UserID { get; set; }
        /// <summary>
        /// کد کارگاه
        /// </summary>
        public string DSK_ID { get; set; }
        /// <summary>
        /// نام کارگاه
        /// </summary>
        public string DSK_NAME { get; set; }
        /// <summary>
        /// نام کارفرما 
        /// </summary>
        public string DSK_FARM { get; set; }
        /// <summary>
        /// آدرس کارگاه
        /// </summary>
        public string DSK_ADRS { get; set; }
        /// <summary>
        /// ردیف پیمان
        /// </summary>
        public string MON_PYM { get; set; }
        /// <summary>
        /// نرخ حق بیمه
        /// </summary>
        public int DSK_RATE { get; set; }
    }
}
