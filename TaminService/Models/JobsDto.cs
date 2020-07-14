using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminService.Models
{
    public class JobsDto:BaseDto<JobsDto,Jobs>
    {
        /// <summary>
        /// کد شغل
        /// </summary>
        public string DSW_JOB { get; set; }
        /// <summary>
        /// شرح شغل
        /// </summary>
        public string DSW_OCP { get; set; }
    }
}
