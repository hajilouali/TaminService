using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminApp.Models
{
    public class UserModel 
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public IList<string> RollName { get; set; }
        public string UserPhone { get; set; }
        public int EmplyeCount { get; set; }
        public int ManufacturyCount { get; set; }
        public int ListCount { get; set; }
        public decimal UserWallet { get; set; }
        public string UserImage { get; set; }

    }
}
