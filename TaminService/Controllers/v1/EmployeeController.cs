using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Common;
using Common.Exceptions;
using Common.Utilities;
using Data.Repositories;
using Entities;
using Entities.Tamin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Services.DBF;
using TaminService.Models;
using Tools;
using WebFramework.Api;

namespace TaminService.Controllers.v1
{
    [ApiVersion("1")]
    [Authorize]
    public class EmployeeController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IRepository<Employees> _Employees;
        private readonly IRepository<Jobs> _Jobs;
        private readonly IRepository<Place> _Place;
        private readonly IRepository<Country> _Country;
        private readonly IRepository<WorkMonth> _WorkMonth;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IRepository<ListEmployee> _ListEmployee;
        public EmployeeController(UserManager<User> userManager, IRepository<Employees> employees, IRepository<Jobs> jobs, IRepository<Place> place, IRepository<Country> country, IRepository<WorkMonth> workMonth, IHostingEnvironment hostingEnvironment, IRepository<ListEmployee> listEmployee)
        {
            this.userManager = userManager;
            _Employees = employees;
            _Jobs = jobs;
            _Place = place;
            _Country = country;
            _WorkMonth = workMonth;
            _hostingEnvironment = hostingEnvironment;
            _ListEmployee = listEmployee;
        }
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> Get(CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Employees.TableNoTracking.Where(p => p.UserID == user.Id).ProjectTo<EmployeeDto>().ToListAsync(cancellationToken);
            //var model = await _Employees.TableNoTracking.Where(p => p.UserID == user.Id).Include(p => p.Jobs).ProjectTo<EmployeeDto>().ToListAsync(cancellationToken);

            return Ok(model);

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> Get(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Employees.TableNoTracking.Where(p => p.UserID == user.Id && p.Id == id).ProjectTo<EmployeeDto>().FirstOrDefaultAsync(cancellationToken);
            return model;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> Create(EmployeeDto dto, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);


            var insert = dto.ToEntity();
            insert.UserID = user.Id;
            insert.jobid = dto.Jobs.Id;
            insert.Jobs = null;
            if (_Employees.TableNoTracking.Where(p=>p.PER_NATCOD.Equals(insert.PER_NATCOD)).Any())
            {
                return Ok(false);

            }
            //insert.job = dto.Jobs.Id;
            _Employees.Add(insert);
            return Ok(true);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> update(EmployeeDto dto, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Employees.Table.FirstOrDefaultAsync(p => p.UserID == user.Id && p.Id == dto.Id, cancellationToken);
            if (model != null)
            {
                model.DSW_BDATE = dto.DSW_BDATE;
                model.DSW_SEX = dto.DSW_SEX;
                model.DSW_DNAME = dto.DSW_DNAME;
                model.DSW_FNAME = dto.DSW_FNAME;
                model.DSW_ID1 = dto.DSW_ID1;
                model.DSW_IDATE = dto.DSW_IDATE;
                model.DSW_IDNO = dto.DSW_IDNO;
                model.DSW_IDPLC = dto.DSW_IDPLC;
                model.DSW_LNAME = dto.DSW_LNAME;
                model.DSW_NAT = dto.DSW_NAT;
                model.ListEmployeeID = dto.ListEmployeeID;
                model.PER_NATCOD = dto.PER_NATCOD;
                model.jobid = dto.Jobs.Id;
                model.UserID = user.Id;
                model.IsKarfarma = dto.IsKarfarma;
                await _Employees.UpdateAsync(model, cancellationToken);
                return Ok(true);
            }
            throw new BadRequestException("مشکلی در فرایند بروز رسانی ایجاد شده است.");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Employees.Table.Where(p => p.UserID == user.Id && p.Id == id).Include(p => p.WorkMonths).FirstOrDefaultAsync(cancellationToken);
            if (model != null && !model.WorkMonths.Any())
            {
                await _Employees.DeleteAsync(model, cancellationToken);
                return Ok(true);
            }
            throw new BadRequestException("مشکلی در فرایند حذف ایجاد شده است.");
        }
        [HttpPost("[action]/{search}")]
        public async Task<ActionResult<List<Jobs>>> GetJobByTitle(string search, CancellationToken cancellationToken)
        {

            //var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Jobs.TableNoTracking.Where(p => p.DSW_OCP.Contains(search)).ToListAsync(cancellationToken);
            if (model != null)
            {

                return Ok(model);
            }
            throw new BadRequestException("مشکلی در فرایند  ایجاد شده است.");
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Place>>> Getplace(CancellationToken cancellationToken)
        {

            //var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Place.TableNoTracking.ToListAsync(cancellationToken);
            if (model != null)
            {

                return Ok(model);
            }
            throw new BadRequestException("مشکلی در فرایند  ایجاد شده است.");
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Country>>> Getcountry(CancellationToken cancellationToken)
        {

            //var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Country.TableNoTracking.ToListAsync(cancellationToken);
            if (model != null)
            {

                return Ok(model);
            }
            throw new BadRequestException("مشکلی در فرایند  ایجاد شده است.");
        }
        [HttpPost("[action]/{cat}")]
        public async Task<ActionResult<List<EmployeeDto>>> AddEmployeeByList(int cat, EmployeeExcel dto, CancellationToken cancellationToken)
        {
            if (dto.list.Count > 0)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var list = new List<Employees>();

                foreach (var item in dto.list)
                {

                    var job = _Jobs.TableNoTracking.Where(p => p.DSW_JOB == item.DSW_OCP).FirstOrDefault();
                    var model = item.ToEntity();
                    if (job != null)
                    {
                        model.jobid = job.Id;
                    }
                    else
                    {
                        model.jobid = _Jobs.TableNoTracking.Where(p => p.DSW_OCP.Contains("کارگر ساده")).FirstOrDefault().Id;
                    }
                    if (_ListEmployee.TableNoTracking.Where(p => p.Id == cat && p.UserID == user.Id).Any())
                    {
                        model.ListEmployeeID = cat;
                    }
                    model.UserID = user.Id;
                    model.Id = 0;
                    if (!_Employees.TableNoTracking.Where(p => p.PER_NATCOD.Equals(model.PER_NATCOD)).Any())
                    {
                        list.Add(model);
                    }

                }
                await _Employees.AddRangeAsync(list, cancellationToken);
                var ldto = await _Employees.TableNoTracking.Where(p => p.UserID == user.Id).ProjectTo<EmployeeDto>().ToListAsync(cancellationToken);
                return Ok(ldto);
            }
            throw new BadRequestException("مشکلی در فرایند  ایجاد شده است.");
        }
        [HttpPost("[action]/{cat}")]
        public async Task<ActionResult<List<EmployeeDto>>> AddEmployeeByDBF(int cat, IFormFile dto, CancellationToken cancellationToken)
        {
            var file = Request.Form.Files[0];
            if (dto != null)
            {
                file = dto;
            }
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (CheckContentdocument.isDBFFile(file))
            {
                
                bool exists = System.IO.Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "temp\\Users\\" + user.Id));
                if (!exists)
                    System.IO.Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "temp\\Users\\" + user.Id));
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "temp\\Users\\" + user.Id);
                int CountFile = System.IO.Directory.GetFiles(Path.Combine(_hostingEnvironment.WebRootPath, "temp\\Users\\" + user.Id)).Length;
                string FName = user.Id.ToString() + CountFile.ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploads, FName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream, cancellationToken);
                    
                }
                using (var fileStreambdf = new FileStream(filePath, FileMode.Open))
                {
                    var reader = new DBFReader(fileStreambdf, Encoding.GetEncoding(1256));

                    var insert = reader.ReadToObject<EmployeeExcelmodel>();
                    var list = new List<Employees>();

                    foreach (var item in insert)
                    {

                        var job = _Jobs.TableNoTracking.Where(p => p.DSW_OCP == item.DSW_OCP.CleanString()).FirstOrDefault();
                        var model = item.ToEntity();
                        model.DSW_SEX = model.DSW_SEX.CleanString();
                        if (job != null)
                        {
                            model.jobid = job.Id;
                        }
                        else
                        {
                            model.jobid = _Jobs.TableNoTracking.Where(p => p.DSW_OCP.Contains("کارگر ساده")).FirstOrDefault().Id;
                        }
                        if (_ListEmployee.TableNoTracking.Where(p => p.Id == cat && p.UserID == user.Id).Any())
                        {
                            model.ListEmployeeID = cat;
                        }
                        model.DSW_BDATE = "13" + model.DSW_BDATE;
                        if (model.DSW_BDATE.Substring(0,4).Contains("/"))
                        {
                            var dd = model.DSW_BDATE.Substring(0, 2);
                            var yy = model.DSW_BDATE.Substring(6, 4);
                            model.DSW_BDATE = model.DSW_BDATE.Remove(0, 2).Remove(4,4);
                            model.DSW_BDATE = yy + model.DSW_BDATE + dd;

                        }
                        model.DSW_NAT = model.DSW_NAT.CleanString().Equals("ایرانى") ? "ایران" : model.DSW_NAT.CleanString();
                        model.UserID = user.Id;
                        model.Id = 0;
                        if (!_Employees.TableNoTracking.Where(p => p.PER_NATCOD.Equals(model.PER_NATCOD)).Any())
                        {
                            list.Add(model);
                        }

                    }
                    await _Employees.AddRangeAsync(list, cancellationToken);
                    
                }
                System.IO.File.Delete(filePath);
                var ldto = await _Employees.TableNoTracking.Where(p => p.UserID == user.Id).ProjectTo<EmployeeDto>().ToListAsync(cancellationToken);
                return Ok(ldto);
            }
            throw new BadRequestException("مشکلی در فرایند  ایجاد شده است.");


        }
    }
}