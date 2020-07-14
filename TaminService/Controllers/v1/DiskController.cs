using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Common;
using Common.Exceptions;
using Data.Repositories;
using Entities;
using Entities.Tamin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Bessines;
using TaminService.Models;
using WebFramework.Api;

namespace TaminService.Controllers.v1
{
    [ApiVersion("1")]
    [Authorize]
    public class DiskController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IRepository<Employees> _Employees;
        private readonly IRepository<WorkMonth> _WorkMonth;
        private readonly IRepository<Manufacturys> _Manufacturys;
        private readonly IRepository<KarMonth> _KarMonth;
        private readonly SiteSettings _siteSetting;
        private readonly IRepository<UserPayement> _UserPayement;
        private readonly IRepository<OffersCode> _OffersCode;
        private readonly IRepository<PayementHistory> _PayementHistory;

        private readonly IHostingEnvironment _hostingEnvironment;

        public DiskController(UserManager<User> userManager, IRepository<Employees> employees, IRepository<WorkMonth> workMonth, IRepository<Manufacturys> manufacturys, IRepository<KarMonth> karMonth, IConfiguration configuration, IRepository<UserPayement> userPayement, IHostingEnvironment hostingEnvironment, IRepository<OffersCode> offersCode, IRepository<PayementHistory> payementHistory)
        {
            this.userManager = userManager;
            _Employees = employees;
            _WorkMonth = workMonth;
            _Manufacturys = manufacturys;
            _KarMonth = karMonth;
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
            _UserPayement = userPayement;
            _hostingEnvironment = hostingEnvironment;
            _OffersCode = offersCode;
            _PayementHistory = payementHistory;
        }
        [HttpGet]
        public async Task<ActionResult<List<KarMonthDto>>> Get(CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _KarMonth.TableNoTracking.Where(p => p.Manufacturys.UserID == user.Id).OrderByDescending(p => p.DateCreate).ProjectTo<KarMonthDto>().ToListAsync(cancellationToken);

            return Ok(model);

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<KarMonthDto>> Get(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _KarMonth.TableNoTracking.Where(p => p.Manufacturys.UserID == user.Id && p.Id == id).ProjectTo<KarMonthDto>().FirstOrDefaultAsync(cancellationToken);
            return model;
        }
        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<List<WorkMonthDto>>> GetWorksMonthByKarMonthId(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _WorkMonth.TableNoTracking.Where(p => p.KarMonth.Manufacturys.UserID == user.Id && p.KarMonth.Id == id).Include(p => p.Employees).ProjectTo<WorkMonthDto>().ToListAsync(cancellationToken);

            return model;
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<KarMonthDto>> AddKarMonth(KarMonthDto Dto, CancellationToken cancellationToken)
        {
            if (Dto != null)
            {


                var model = Dto.ToEntity();
                model.Manufacturys = null;
                await _KarMonth.AddAsync(model, cancellationToken);
                return Ok(model);
            }
            throw new BadRequestException("مشکل در بارگزاری اطلاعات");
        }
        [HttpPost("[action]/{KarMonthid:int}")]
        public async Task<ActionResult<bool>> WorkMonth(int KarMonthid, IEnumerable<WorkMonthDto> dto, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var KarMonth = await _KarMonth.TableNoTracking.Include(p => p.Manufacturys).Where(p => p.Id == KarMonthid && p.Manufacturys.UserID == user.Id).FirstOrDefaultAsync(cancellationToken);
            if (dto.Any())
            {
                if (KarMonth != null)
                {
                    var list = new List<WorkMonth>();
                    foreach (var item in dto)
                    {
                        var model = item.ToEntity();
                        model.KarMonth = null;
                        model.Employees = null;
                        model.KarMonthID = KarMonthid;
                        list.Add(model);
                    }
                    if (_siteSetting.SiteInfo.IsFree)
                    {
                        await _WorkMonth.AddRangeAsync(list, cancellationToken);
                        return Ok(true);
                    }
                    else
                    {
                        var UserWallet = (await _UserPayement.TableNoTracking.Where(p => p.UserID == user.Id).SumAsync(p => p.Bestankar, cancellationToken)) -
                         (await _UserPayement.TableNoTracking.Where(p => p.UserID == user.Id).SumAsync(p => p.Bedehkari, cancellationToken));
                        if (UserWallet >= (dto.Count() * _siteSetting.SiteInfo.fe))
                        {
                            var userpayment = new UserPayement()
                            {
                                UserID = user.Id,
                                Discription = $"کسر بابت ثبت لیست {KarMonth.Manufacturys.DSK_NAME} سال {KarMonth.DSK_YY} ماه {KarMonth.DSK_MM} - {DateTime.Now.ToPersianDigitalDateTimeString()}",
                                Bedehkari = dto.Count() * _siteSetting.SiteInfo.fe,
                                Bestankar = 0,
                                Status = 1
                            };
                            await _UserPayement.AddAsync(userpayment, cancellationToken);
                            await _WorkMonth.AddRangeAsync(list, cancellationToken);
                            return Ok(true);
                        }
                        return Ok(false);
                    }

                }
            }
            throw new BadRequestException("مشکل در بارگزاری اطلاعات");
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<siteInfo>> GetAppSellState(CancellationToken cancellationToken)
        {
            return Ok(_siteSetting.SiteInfo);
        }
        [HttpDelete("[action]/{id:int}")]
        public async Task<ActionResult<bool>> deletKarMonthbyId(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _KarMonth.TableNoTracking.Where(p => p.Manufacturys.UserID == user.Id && p.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (model != null)
            {
                var workdto = await _WorkMonth.Table.Where(p => p.KarMonthID == model.Id).ToListAsync(cancellationToken);
                await _WorkMonth.DeleteRangeAsync(workdto, cancellationToken);
                await _KarMonth.DeleteAsync(model, cancellationToken);
                return Ok(true);
            }
            throw new BadRequestException("مشکل در حذف اطلاعات");

        }
        [HttpGet("[action]/{code}")]
        public async Task<ActionResult<OfferCodeDto>> GetCodeOfferStatus(string code, CancellationToken cancellationToken)
        {
            var model = await _OffersCode.TableNoTracking.Where(p => p.Code.Equals(code)).ProjectTo<OfferCodeDto>().FirstOrDefaultAsync(cancellationToken);
            if (model != null)
            {

                return Ok(model);
            }
            throw new BadRequestException("مشکل در بارگزاری اطلاعات");

        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<PayementHisstoryDto>>> GetLastPaymentHisstory(CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _PayementHistory.TableNoTracking.Where(p => p.UserID == user.Id).OrderByDescending(p=>p.DateTime).Take(10).ProjectTo<PayementHisstoryDto>().ToListAsync(cancellationToken);

            return Ok(model);


        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<UserPayementDto>>> GetUserAccounting(CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _UserPayement.TableNoTracking.Where(p => p.UserID == user.Id).OrderBy(p => p.dateTime).ProjectTo<UserPayementDto>().ToListAsync(cancellationToken);

            return Ok(model);
        }


        [HttpGet("[action]/{id:int}")]
        public virtual async Task<ActionResult> CreateDBF(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var KarMonth = await _KarMonth.TableNoTracking.Include(p => p.Manufacturys).Where(p => p.Id == id && p.Manufacturys.UserID == user.Id).ProjectTo<KarMonthDto>().FirstOrDefaultAsync(cancellationToken);

            var model = await _WorkMonth.TableNoTracking.Where(p => p.KarMonth.Manufacturys.UserID == user.Id && p.KarMonth.Id == KarMonth.Id).Include(p => p.Employees).ProjectTo<WorkMonthDto>().ToListAsync(cancellationToken);

            try
            {
                var moel = new BusinessLogicLayer.tblSalInsurenceDiskFactory()
                {
                    DSK_ADRS = KarMonth.ManufactureDto.DSK_ADRS,
                    DSK_BIC = KarMonth.DSK_BIC,
                    DSK_BIMH = KarMonth.DSK_BIMH,
                    DSK_DISC = KarMonth.DSK_DISC,
                    DSK_FARM = KarMonth.ManufactureDto.DSK_FARM,
                    DSK_ID = KarMonth.ManufactureDto.DSK_ID,
                    DSK_KIND = KarMonth.DSK_KIND,
                    DSK_LISTNO = KarMonth.DSK_LISTNO,
                    DSK_MM = KarMonth.DSK_MM,
                    DSK_NAME = KarMonth.ManufactureDto.DSK_NAME,
                    DSK_NUM = KarMonth.DSK_NUM,
                    DSK_PRATE = KarMonth.DSK_PRATE,
                    DSK_RATE = KarMonth.DSK_PRATE,
                    DSK_TBIME = KarMonth.DSK_TBIME,
                    DSK_TDD = KarMonth.DSK_TDD,
                    DSK_TKOSO = KarMonth.DSK_TKOSO,
                    DSK_TMAH = KarMonth.DSK_TMAH,
                    DSK_TMASH = KarMonth.DSK_TMASH,
                    DSK_TMAZ = KarMonth.DSK_TMAZ,
                    DSK_TROOZ = KarMonth.DSK_TROOZ,
                    DSK_TTOTL = KarMonth.DSK_TTOTL,
                    DSK_YY = KarMonth.DSK_YY,
                    insAutoID = 0,
                    MON_PYM = KarMonth.ManufactureDto.MON_PYM,

                };
                var dto = new System.Collections.Generic.List<BusinessLogicLayer.tblSalInsurenceDiskPersonal>();
                foreach (var item in model)
                {
                    dto.Add(new BusinessLogicLayer.tblSalInsurenceDiskPersonal()
                    {
                        DayAddCount = 0,
                        insAutoID = 0,
                        DSW_BDATE = string.IsNullOrEmpty(item.EmployeeDto.DSW_BDATE) ? null : item.EmployeeDto.DSW_BDATE.Substring(2, item.EmployeeDto.DSW_BDATE.Length - 2),
                        DSW_BIME = item.DSW_BIME,
                        DSW_DD = item.DSW_DD,
                        DSW_DNAME = item.EmployeeDto.DSW_DNAME,
                        DSW_EDATE = string.IsNullOrEmpty(item.DSW_EDATE) ? null : item.DSW_EDATE.Substring(2, item.DSW_EDATE.Length - 2),
                        DSW_FNAME = item.EmployeeDto.DSW_FNAME,
                        DSW_ID = KarMonth.ManufactureDto.DSK_ID,
                        DSW_ID1 = item.EmployeeDto.DSW_ID1,
                        DSW_IDATE = string.IsNullOrEmpty(item.EmployeeDto.DSW_IDATE) ? null : item.EmployeeDto.DSW_IDATE.Substring(2, item.EmployeeDto.DSW_IDATE.Length - 2),
                        DSW_IDNO = item.EmployeeDto.DSW_IDNO,
                        DSW_IDPLC = item.EmployeeDto.DSW_IDPLC,
                        DSW_JOB = item.EmployeeDto.Jobs.DSW_JOB,
                        DSW_LISTNO = KarMonth.DSK_LISTNO,
                        DSW_LNAME = item.EmployeeDto.DSW_LNAME,
                        DSW_MAH = item.DSW_MAH,
                        DSW_MASH = item.DSW_MASH,
                        DSW_MAZ = item.DSW_MAZ,
                        DSW_MM = KarMonth.DSK_MM,
                        DSW_NAT = item.EmployeeDto.DSW_NAT,
                        DSW_OCP = item.EmployeeDto.Jobs.DSW_OCP,
                        DSW_PRATE = KarMonth.DSK_PRATE,
                        DSW_ROOZ = item.DSW_ROOZ,
                        DSW_SDATE = string.IsNullOrEmpty(item.DSW_SDATE) ? null : item.DSW_SDATE.Substring(2, item.DSW_SDATE.Length - 2),
                        DSW_SEX = item.EmployeeDto.DSW_SEX,
                        DSW_TOTL = item.DSW_TOTL,
                        DSW_YY = KarMonth.DSK_YY,
                        PER_NATCOD = item.EmployeeDto.PER_NATCOD,
                        piPersonalID = "",
                    });
                }

                var uploads = Path.Combine(AppContext.BaseDirectory + "BDFs\\" + user.Id);

                bool exists = System.IO.Directory.Exists(uploads);
                if (!exists)
                    System.IO.Directory.CreateDirectory(uploads);
                var CountFile = System.IO.Directory.GetFiles(uploads);
                if (CountFile.Count() > 0)
                {
                    foreach (var item in CountFile)
                    {
                        System.IO.File.Delete(item);
                    }
                }
                clsSalInsurenceDisk.CreateDBFPersonal(dto, uploads);
                clsSalInsurenceDisk.CreateDBFFactory(moel, uploads);

                return Ok();
            }
            catch
            {
                throw new BadRequestException("مشکل در حذف اطلاعات");
            }
        }
        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult> download(int id = 0)
        {
            var CountFile = "";
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var uploads = Path.Combine(AppContext.BaseDirectory + "BDFs\\" + user.Id);
            var CountFile2 = System.IO.Directory.GetFiles(uploads);
            CountFile = CountFile2.FirstOrDefault();
            if (id == 1)
            {
                if (CountFile2.Count() <= 1)
                    throw new BadRequestException("مشکل در حذف اطلاعات");
                CountFile = CountFile2.LastOrDefault();
            }
            //var resolt = new List<FileStreamResult>();

            //Stream stream = new FileStream(CountFile, FileMode.Open);
            string mimeType = "application/octet-stream";
            //var resons = new FileStreamResult(stream, mimeType)
            //{
            //    FileDownloadName = Path.GetFileName(CountFile)
            //};
            var resons = new FileContentResult(System.IO.File.ReadAllBytes(CountFile), mimeType)
            {
                FileDownloadName = Path.GetFileName(CountFile),

            };
            return resons;
        }
    }
}