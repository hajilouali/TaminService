using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Exceptions;
using Data.Repositories;
using ElmahCore;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaminApp.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFramework.Filters;
using Common;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Swashbuckle.AspNetCore.Filters;
using System.Linq;
using Entities.Tamin;
using Tools;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MyApi.Controllers.v1
{
    [ApiVersion("1")]
    //[AllowAnonymous]
    public class UsersController : BaseController
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UsersController> logger;
        private readonly IJwtService jwtService;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly IRepository<Employees> _Employees;
        private readonly IRepository<Manufacturys> _Manufacturys;
        private readonly IRepository<KarMonth> _KarMonth;
        private readonly IRepository<UserPayement> _UserPayement;
        private readonly IRepository<Role> _Role;
        private readonly IHostingEnvironment _hostingEnvironment;
        public UsersController(IUserRepository userRepository, ILogger<UsersController> logger, IJwtService jwtService, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IRepository<Role> role, IRepository<Employees> employees, IRepository<Manufacturys> manufacturys, IRepository<KarMonth> KarMonth, IRepository<UserPayement> userPayement, IHostingEnvironment hostingEnvironment)
        {
            this.userRepository = userRepository;
            this.logger = logger;
            this.jwtService = jwtService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            _Role = role;
            _Employees = employees;
            _Manufacturys = manufacturys;
            _KarMonth = KarMonth;
            _UserPayement = userPayement;
            _hostingEnvironment = hostingEnvironment;
        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<ActionResult<bool>> Addprofilepic(CancellationToken cancellationToken)
        {
            var file = Request.Form.Files[0];
            var user = await userManager.FindByNameAsync(User.Identity.Name);


            if (CheckContentImage.IsImage(file))
            {
                if (!string.IsNullOrEmpty(user.ProfilePIC))
                {
                    var path = Path.Combine(_hostingEnvironment.WebRootPath,  user.ProfilePIC.Replace("/","\\"));
                    bool existss = System.IO.File.Exists(path);
                    if(existss)
                        System.IO.File.Delete(path);
                }
                bool exists = System.IO.Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Users/" + user.Id));
                if (!exists)
                    System.IO.Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Users/" + user.Id));
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Users/" + user.Id);
                int CountFile = System.IO.Directory.GetFiles(Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Users/" + user.Id)).Length;
                string FName = user.Id.ToString() + CountFile.ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploads, FName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream, cancellationToken);
                    user.ProfilePIC = Path.Combine("uploads/Users/"+user.Id+"/", FName);
                    await userManager.UpdateAsync(user);                    
                    return Ok(true);
                }
            }

            throw new BadRequestException("مشکلی  ایجاد شده است");
        }
        [HttpPost("[action]")]
        [Authorize]
        public virtual async Task<ActionResult<bool>> UpdatePassword(changepassworddto dto, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    if (dto.newpassword == dto.repassword)
                    {
                        var res = await userManager.ChangePasswordAsync(user, dto.curentpassword, dto.newpassword);
                        if (res.Succeeded)
                            return Ok(true);
                    }
                    return Ok(false);
                }
                return Ok(false);
            }
            catch
            {
                return Ok(false);
            }
        }
        [HttpGet("[action]")]
        [Authorize]
        public virtual async Task<ActionResult<bool>> CheckTokenIsValid(CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    return Ok(true);
                }
                return Ok(false);
            }
            catch
            {
                return Ok(false);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public virtual async Task<ActionResult<List<UserModel>>> Get(CancellationToken cancellationToken)
        {
            //var userName = HttpContext.User.Identity.GetUserName();
            //userName = HttpContext.User.Identity.Name;
            //var userId = HttpContext.User.Identity.GetUserId();
            //var userIdInt = HttpContext.User.Identity.GetUserId<int>();
            //var phone = HttpContext.User.Identity.FindFirstValue(ClaimTypes.MobilePhone);
            //var role = HttpContext.User.Identity.FindFirstValue(ClaimTypes.Role);

            var users = await userRepository.TableNoTracking.ToListAsync(cancellationToken);
            List<UserModel> list = new List<UserModel>();
            foreach (var item in users)
            {

                list.Add(new UserModel()
                {
                    id = item.Id,
                    IsActive = item.IsActive,
                    EmplyeCount = _Employees.TableNoTracking.Where(p => p.UserID == item.Id).Count(),
                    FullName = item.FullName,
                    ManufacturyCount = _Manufacturys.TableNoTracking.Where(p => p.UserID == item.Id).Count(),
                    RollName = await userManager.GetRolesAsync(item),
                    ListCount = _KarMonth.TableNoTracking.Include(p => p.Manufacturys).Where(p => p.Manufacturys.UserID == item.Id).Count(),
                    UserPhone = item.PhoneNumber,
                    UserWallet = (await _UserPayement.TableNoTracking.Where(p => p.UserID == item.Id).SumAsync(p => p.Bestankar, cancellationToken)) -
                    (await _UserPayement.TableNoTracking.Where(p => p.UserID == item.Id).SumAsync(p => p.Bedehkari, cancellationToken)),
                    UserImage = item.ProfilePIC
                });
            }
            return Ok(list);
        }
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<ActionResult<UserDto>> CreateUser(UserDto userDto, CancellationToken cancellationToken)
        {
            logger.LogError("متد Create فراخوانی شد");
            HttpContext.RiseError(new Exception("متد Create فراخوانی شد"));

            var exists = await userRepository.TableNoTracking.AnyAsync(p => p.UserName.ToLower() == userDto.PhoneNumber.ToLower() || p.Address.ToLower() == userDto.Email.ToLower()); ;
            if (exists)
                return BadRequest("نام کاربری تکراری است");
            //Services.Bessines.UsersProcess usersProcess = new Services.Bessines.UsersProcess(signInManager, userManager, roleManager, _clientRepository, _accountingHeading, _Factor, _Expert);
            //await roleManager.CreateAsync(new Role()
            //{
            //    Name = "Admin",
            //    Description = "مدیر",
            //});
            //await roleManager.CreateAsync(new Role()
            //{
            //    Name = "User",
            //    Description = "مشتریان",
            //});
            User user = new User()
            {
                UserName = userDto.PhoneNumber,
                PasswordHash = userDto.Password,
                Email = userDto.Email,
                FullName = userDto.FullName,
                PhoneNumber = userDto.PhoneNumber,

            };
            await userManager.CreateAsync(user, user.PasswordHash);
            await userManager.AddToRolesAsync(user, new List<string> { "User" });
            //var result = await usersProcess.AddUserToApp(user, null);
            //if (result != true)
            //    throw new BadRequestException("مشکلی در فرایند ثبت کاربر ایجاد شده است");
            //var user = new User
            //{

            //    FullName = userDto.FullName,

            //    UserName = userDto.UserName,
            //    Email = userDto.Email
            //};
            //var result = await userManager.CreateAsync(user, userDto.Password);



            //var result3 = await userManager.AddToRoleAsync(user, "CellPartner");

            //await userRepository.AddAsync(user, userDto.Password, cancellationToken);
            return Ok(userDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id:int}")]
        public virtual async Task<ApiResult<User>> Get(int id, CancellationToken cancellationToken)
        {
            //var user2 = await userManager.FindByIdAsync(id.ToString());
            //var role = await roleManager.FindByNameAsync("Admin");

            var user = await userRepository.GetByIdAsync(cancellationToken, id);
            if (user == null)
                return NotFound();


            //await userRepository.UpdateSecuirtyStampAsync(user, cancellationToken);

            return user;
        }
        [Authorize]
        [HttpGet("[action]")]
        public virtual async Task<ApiResult<UserModel>> GetCorentUserBio(CancellationToken cancellationToken)
        {
            //var user2 = await userManager.FindByIdAsync(id.ToString());
            //var role = await roleManager.FindByNameAsync("Admin");

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
                return NotFound();
            var dto = new UserModel()
            {
                id = user.Id,
                IsActive = user.IsActive,
                EmplyeCount = _Employees.TableNoTracking.Where(p => p.UserID == user.Id).Count(),
                FullName = user.FullName,
                ManufacturyCount = _Manufacturys.TableNoTracking.Where(p => p.UserID == user.Id).Count(),
                RollName = await userManager.GetRolesAsync(user),
                ListCount = _KarMonth.TableNoTracking.Include(p => p.Manufacturys).Where(p => p.Manufacturys.UserID == user.Id).Count(),
                UserPhone = user.PhoneNumber,
                UserWallet = (await _UserPayement.TableNoTracking.Where(p => p.UserID == user.Id).SumAsync(p => p.Bestankar, cancellationToken)) -
                    (await _UserPayement.TableNoTracking.Where(p => p.UserID == user.Id).SumAsync(p => p.Bedehkari, cancellationToken)),
                UserImage = user.ProfilePIC
            };

            return dto;
        }
        /// <summary>
        /// This method generate JWT Token
        /// </summary>
        /// <param name="tokenRequest">The information of token request</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        public virtual async Task<ActionResult> Token([FromForm]TokenRequest tokenRequest, CancellationToken cancellationToken)
        {

            if (!tokenRequest.grant_type.Equals("password", StringComparison.OrdinalIgnoreCase))
                throw new Exception("OAuth flow is not password.");

            //var user = await userRepository.GetByUserAndPass(username, password, cancellationToken);
            var user = await userManager.Users.FirstOrDefaultAsync(p => p.PhoneNumber == tokenRequest.username);
            if (user == null)
                throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");

            var isPasswordValid = await userManager.CheckPasswordAsync(user, tokenRequest.password);
            if (!isPasswordValid)
                throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");


            //if (user == null)
            //    throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");

            var jwt = await jwtService.GenerateAsync(user);
            return new JsonResult(jwt);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("[action]/{id}")]
        public virtual async Task<ApiResult> Update(int id, UserDto UserDto, CancellationToken cancellationToken)
        {
            var updateUser = await userRepository.GetByIdAsync(cancellationToken, id);

            updateUser.UserName = UserDto.PhoneNumber;
            updateUser.FullName = UserDto.FullName;
            updateUser.Email = UserDto.Email;
            updateUser.IsActive = UserDto.IsActive;
            updateUser.PhoneNumber = UserDto.PhoneNumber;

            await userManager.UpdateAsync(updateUser);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public virtual async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            var res = await userManager.DeleteAsync(user);
            if (!res.Succeeded)
                return BadRequest("در فرایند پاک کردن کاربر مشکل پیش امده ");
            return Ok();
        }
        [HttpGet("[action]/{id}/{newpassword}")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<ApiResult> setPassword(int id, string newpassword)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            var token = await userManager.RemovePasswordAsync(user);
            var settpassword = await userManager.AddPasswordAsync(user, newpassword);
            if (!settpassword.Succeeded)
                return BadRequest("اطلاعات وارد شده معتبر نمی باشد");
            return Ok();
        }
        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<ActionResult<List<string>>> GetUserRolls(int userid)
        {
            var useer = await userManager.FindByIdAsync(userid.ToString());
            var rolss = await userManager.GetRolesAsync(useer);
            return Ok(rolss.ToList());
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<ActionResult<List<Role>>> GeAllRolls(CancellationToken cancellationToken)
        {
            var useer = await _Role.Entities.AsNoTracking().ToListAsync(cancellationToken);

            return Ok(useer);
        }
        [HttpGet("[action]/{RollName}")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<ActionResult<List<UserModel>>> GetUsersInRoll(string RollName, CancellationToken cancellationToken)
        {
            //var userName = HttpContext.User.Identity.GetUserName();
            //userName = HttpContext.User.Identity.Name;
            //var userId = HttpContext.User.Identity.GetUserId();
            //var userIdInt = HttpContext.User.Identity.GetUserId<int>();
            //var phone = HttpContext.User.Identity.FindFirstValue(ClaimTypes.MobilePhone);
            //var role = HttpContext.User.Identity.FindFirstValue(ClaimTypes.Role);

            var users = await userManager.GetUsersInRoleAsync(RollName);
            List<UserModel> list = new List<UserModel>();
            foreach (var item in users)
            {
                list.Add(new UserModel()
                {
                    id = item.Id,
                    IsActive = item.IsActive,
                    EmplyeCount = _Employees.TableNoTracking.Where(p => p.UserID == item.Id).Count(),
                    FullName = item.FullName,
                    ManufacturyCount = _Manufacturys.TableNoTracking.Where(p => p.UserID == item.Id).Count(),
                    RollName = await userManager.GetRolesAsync(item),
                    ListCount = _KarMonth.TableNoTracking.Include(p => p.Manufacturys).Where(p => p.Manufacturys.UserID == item.Id).Count(),
                    UserPhone = item.PhoneNumber,
                    UserWallet = (await _UserPayement.TableNoTracking.Where(p => p.UserID == item.Id).SumAsync(p => p.Bestankar, cancellationToken)) -
                    (await _UserPayement.TableNoTracking.Where(p => p.UserID == item.Id).SumAsync(p => p.Bedehkari, cancellationToken)),
                    UserImage = item.ProfilePIC
                });
            }
            return Ok(list);
        }
        [HttpGet("[action]/{id}/{Roll}")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<ApiResult> addUserstoRolls(int id, string Roll, CancellationToken cancellationToken)
        {
            //var userName = HttpContext.User.Identity.GetUserName();
            //userName = HttpContext.User.Identity.Name;
            //var userId = HttpContext.User.Identity.GetUserId();
            //var userIdInt = HttpContext.User.Identity.GetUserId<int>();
            //var phone = HttpContext.User.Identity.FindFirstValue(ClaimTypes.MobilePhone);
            //var role = HttpContext.User.Identity.FindFirstValue(ClaimTypes.Role);
            var user = await userManager.FindByIdAsync(id.ToString());
            var users = await userManager.AddToRoleAsync(user, Roll);
            if (users.Succeeded)
            {
                return Ok();
            }
            throw new BadRequestException("مشکلی در فرایند ایجاد شده است");
        }
        [HttpGet("[action]/{id}/{Roll}")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<ApiResult> removeUsersfromRolls(int id, string Roll, CancellationToken cancellationToken)
        {
            //var userName = HttpContext.User.Identity.GetUserName();
            //userName = HttpContext.User.Identity.Name;
            //var userId = HttpContext.User.Identity.GetUserId();
            //var userIdInt = HttpContext.User.Identity.GetUserId<int>();
            //var phone = HttpContext.User.Identity.FindFirstValue(ClaimTypes.MobilePhone);
            //var role = HttpContext.User.Identity.FindFirstValue(ClaimTypes.Role);
            var user = await userManager.FindByIdAsync(id.ToString());
            var users = await userManager.RemoveFromRoleAsync(user, Roll);
            if (users.Succeeded)
            {
                return Ok();
            }
            throw new BadRequestException("مشکلی در فرایند ایجاد شده است");
        }
    }
}
