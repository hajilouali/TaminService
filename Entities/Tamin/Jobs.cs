using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Tamin
{
    public class Jobs:BaseEntity    
    {
        /// <summary>
        /// کد شغل
        /// </summary>
        public string DSW_JOB { get; set; }
        /// <summary>
        /// شرح شغل
        /// </summary>
        public string DSW_OCP { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
