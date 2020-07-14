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
    public class ListEmployesController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IRepository<Employees> _Employees;
        private readonly IRepository<ListEmployee> _ListEmployee;

        public ListEmployesController(UserManager<User> userManager, IRepository<Employees> employees, IRepository<ListEmployee> listEmployee)
        {
            this.userManager = userManager;
            _Employees = employees;
            _ListEmployee = listEmployee;
        }
        [HttpGet]
        public async Task<ActionResult<List<ListEmployeeDto>>> Get(CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _ListEmployee.TableNoTracking.Where(p => p.UserID == user.Id).ProjectTo<ListEmployeeDto>().ToListAsync(cancellationToken);
            return Ok(model);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ListEmployeeDto>> Get(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _ListEmployee.TableNoTracking.Where(p => p.UserID == user.Id && p.Id == id).ProjectTo<ListEmployeeDto>().FirstOrDefaultAsync(cancellationToken);
            return model;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> Create(ListEmployeeDto dto, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = dto.ToEntity();
            model.UserID = user.Id;
            await _ListEmployee.AddAsync(model, cancellationToken);
            return Ok(true);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> update(ListEmployeeDto dto, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _ListEmployee.Table.FirstOrDefaultAsync(p => p.UserID == user.Id && p.Id == dto.Id, cancellationToken);
            if (model != null)
            {
                model.UserID = user.Id;
                model.Title = dto.Title;
                model.Discription = dto.Discription;
                await _ListEmployee.UpdateAsync(model, cancellationToken);
                return Ok(true);
            }
            throw new BadRequestException("مشکلی در فرایند بروز رسانی ایجاد شده است.");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = await _ListEmployee.Table.FirstOrDefaultAsync(p => p.UserID == user.Id && p.Id == id, cancellationToken);
            if (model != null)
            {
                var list = new List<Employees>();
                foreach (var item in _Employees.Table.Where(p=>p.ListEmployeeID==model.Id))
                {
                    item.ListEmployeeID = 0;
                    list.Add(item);
                }
                await _Employees.UpdateRangeAsync(list, cancellationToken);
                await _ListEmployee.DeleteAsync(model, cancellationToken);
                return Ok(true);
            }
            throw new BadRequestException("مشکلی در فرایند حذف ایجاد شده است.");
        }
    }
}