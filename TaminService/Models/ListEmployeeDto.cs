using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminService.Models
{
    public class ListEmployeeDto:BaseDto<ListEmployeeDto, ListEmployee>
    {
        public string Title { get; set; }
        public string Discription { get; set; }
        public int UserID { get; set; }
    }
}
