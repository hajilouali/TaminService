using System;
using System.Collections.Generic;
using System.Linq;
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
using TaminService.Models;
using WebFramework.Api;

namespace TaminService.Controllers.v1
{
    [ApiVersion("1")]
    [Authorize]
    public class ManufactureController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IRepository<Employees> _Employees;
        private readonly IRepository<Manufacturys> _Manufacturys;
        private readonly IRepository<KarMonth> _KarMonth;
        public ManufactureController(UserManager<User> userManager, IRepository<Employees> employees, IRepository<Manufacturys> manufacturys, IRepository<KarMonth> karMonth)
        {
            this.userManager = userManager;
            _Employees = employees;
            _Manufacturys = manufacturys;
            _KarMonth = karMonth;
        }
        [HttpGet]
        public async Task<ActionResult<List<ManufactureDto>>> Get(CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Manufacturys.TableNoTracking.Where(p => p.UserID == user.Id).ProjectTo<ManufactureDto>().ToListAsync(cancellationToken);
            return Ok(model);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ManufactureDto>> Get(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Manufacturys.TableNoTracking.Where(p => p.UserID == user.Id && p.Id == id).ProjectTo<ManufactureDto>().FirstOrDefaultAsync(cancellationToken);
            return model;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> Create(ManufactureDto dto, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = dto.ToEntity();
            model.UserID = user.Id;
            await _Manufacturys.AddAsync(model, cancellationToken);
            return Ok(true);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> update(ManufactureDto dto, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Manufacturys.Table.FirstOrDefaultAsync(p => p.UserID == user.Id && p.Id == dto.Id, cancellationToken);
            if (model != null)
            {
                model.UserID = user.Id;
                model.DSK_NAME = dto.DSK_NAME;
                model.DSK_ADRS = dto.DSK_ADRS;
                model.DSK_FARM = dto.DSK_FARM;
                model.DSK_RATE = dto.DSK_RATE;
                model.MON_PYM = dto.MON_PYM;
                model.DSK_ID = dto.DSK_ID;
                
                await _Manufacturys.UpdateAsync(model, cancellationToken);
                return Ok(true);
            }
            throw new BadRequestException("مشکلی در فرایند بروز رسانی ایجاد شده است.");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _Manufacturys.Table.FirstOrDefaultAsync(p => p.UserID == user.Id && p.Id == id, cancellationToken);
            if (model != null)
            {
                var list = new List<KarMonth>();
                if (!_KarMonth.Table.Where(p => p.ManufacturyID == model.Id).Any())
                {
                    await _Manufacturys.DeleteAsync(model, cancellationToken);
                    return Ok(true);
                }
                
            }
            throw new BadRequestException("مشکلی در فرایند حذف ایجاد شده است.");
        }
    }
}