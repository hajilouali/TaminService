using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Common.Exceptions;
using Data.Repositories;
using Entities;
using Entities.Tamin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Bessines;
using Services.Services.EmailService;
using TaminService.Models;
using WebFramework.Api;

namespace TaminService.Controllers.v1
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/[controller]")]// api/v1/[controller]
    public class DBFController :  ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IRepository<Employees> _Employees;
        private readonly IRepository<WorkMonth> _WorkMonth;
        private readonly IRepository<Manufacturys> _Manufacturys;
        private readonly IRepository<KarMonth> _KarMonth;

        public DBFController(UserManager<User> userManager, IRepository<Employees> employees, IRepository<WorkMonth> workMonth, IRepository<Manufacturys> manufacturys, IRepository<KarMonth> karMonth)
        {
            this.userManager = userManager;
            _Employees = employees;
            _WorkMonth = workMonth;
            _Manufacturys = manufacturys;
            _KarMonth = karMonth;
        }

        //[HttpGet("[action]/{id:int}")]
        //public virtual async Task<ActionResult> CreateDBF(int id, CancellationToken cancellationToken)
        //{
        //    var CountFile = "";
        //    var user = await userManager.FindByNameAsync("hajilou");
        //    var uploads = Path.Combine(AppContext.BaseDirectory + "BDFs\\" + user.Id);
        //    var CountFile2 = System.IO.Directory.GetFiles(uploads);
        //    CountFile = CountFile2.FirstOrDefault();
        //    if (id == 1)
        //    {
        //        if (CountFile2.Count() <= 1)
        //            throw new BadRequestException("مشکل در حذف اطلاعات");
        //        CountFile = CountFile2.LastOrDefault();
        //    }
        //    var resolt = new List<FileStreamResult>();

        //    Stream stream = new FileStream(CountFile, FileMode.Open);
        //    string mimeType = "application/octet-stream";
        //    var resons = new FileStreamResult(stream, mimeType)
        //    {
        //        FileDownloadName = Path.GetFileName(CountFile)
        //    };
        //    return resons;
        //}
    }
}