using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Services;
using TaminWeb.Models;

namespace TaminWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly SiteSettings _siteSetting;

        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        #region login
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModels model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = await userManager.Users.FirstOrDefaultAsync(p => p.PhoneNumber == model.Phone);
                
                if (user == null)
                {
                    ModelState.AddModelError("Phone", "کاربری با مشخصات فوق یافت نشد");
                    return View(model);
                }
                var res =  signInManager.PasswordSignInAsync(user,model.Password,model.IsRememmber,true);
                if (res.IsCompleted)
                {
                    var rolls = await userManager.GetRolesAsync(user);
                    if (!rolls.Where(p => p.Contains("Admin")).Any())
                    {
                        await signInManager.SignOutAsync();

                        ModelState.AddModelError("Phone", "شما دسترسی لازم جهت ورود به سایت را ندارید");
                        return View(model);
                    }
                    if (!user.IsActive)
                    {
                        await signInManager.SignOutAsync();

                        ModelState.AddModelError("Phone", "فعال سازی کاربر فوق انجام نشده،لطفاً مجدداً مراحل فعال سازی شماره تماس خود را انجام دهید");
                        return View(model);
                    }
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("Phone", "کاربری با مشخصات فوق یافت نشد");
            }
            return View(model);
        }
        #endregion
        #region Register
        [Route("Register")]
        [HttpGet]
        public IActionResult Register(string Mobile="")
        {
            ViewData["PortalUrl"] = _siteSetting.SiteInfo.PortalURL;
            var model = new RegisterModel();
            if (!string.IsNullOrEmpty(Mobile))
            {
                model.Mobile = Mobile;
            }
            return View(model);
        }
        [Route("Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            ViewData["PortalUrl"] = _siteSetting.SiteInfo.PortalURL;
            if (ModelState.IsValid)
            {
                //await roleManager.CreateAsync(new Role() { Name = "Admin", Description = "مدیر" });
                //await roleManager.CreateAsync(new Role() { Name = "User", Description = "کاربران" });
                //await roleManager.CreateAsync(new Role() { Name = "Partner", Description = "همکاران" });
                //var user1 = new Entities.User() { UserName = "hajilou", FullName = "علی حاجی لو", PhoneNumber = "09193005377", Email = "hajilouali@gmail.com", IsActive = true, PhoneNumberConfirmed = true };
                //await userManager.CreateAsync(user1, "02623850452");
                //await userManager.AddToRoleAsync(user1, "Admin");
                var user = new User()
                {
                    UserName= model.Mobile,
                    PhoneNumber = model.Mobile,
                    FullName = model.FullName,
                    IsActive = false,
                    LockoutEnabled=true
                };
                var dto = await userManager.Users.FirstOrDefaultAsync(p => p.PhoneNumber == model.Mobile);
                if (dto != null)
                {
                    ModelState.AddModelError("Mobile", "این شماره موبایل قبلاً ثبت شده است.لطفاً از طریق صفحه ورود به سایت وارد سامانه شوید");
                    return View(model);
                }
                else
                {
                    var res = await userManager.CreateAsync(user, model.Password);
                    if (res.Succeeded)
                    {

                        await userManager.AddToRoleAsync(user, "User");

                        var smsmanager = new SMSManager(_siteSetting);
                        var sms = await smsmanager.PhoneVerification(long.Parse(model.Mobile), string.IsNullOrEmpty(model.FullName)?model.Mobile:model.FullName, user.CodePhone, $"{_siteSetting.SiteInfo.Url}/SubM?id={user.Id}&code={user.CodePhone}");
                        if (sms)
                        {
                            return RedirectToAction("SubmitMobile", new { id = user.Id });
                        }

                    }
                }



            }
            return View(model);
        }
        [HttpGet]
        [Route("SubM")]
        public IActionResult SubmitMobile(int id, string code = "")
        {
            var model = new SubmitMobileModel()
            {
                UserID = id,
            };
            if (!string.IsNullOrEmpty(code))
            {
                model.Code = code;
                RedirectToAction("SubmitMobile", new { UserID = model.UserID, Code = model.Code });
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("SubM")]
        public async Task<IActionResult> SubmitMobile(SubmitMobileModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.Users.FirstOrDefaultAsync(p => p.CodePhone == model.Code && p.Id == model.UserID);
                if (user == null)
                {
                    ModelState.AddModelError("Code", "اطلاعات وارد شده معتبر نمیباشد");
                    return View(model);
                }
                user.IsActive = true;
                user.LockoutEnabled = false;
                user.PhoneNumberConfirmed = true;
                var generator = new Random();
                user.CodePhone = generator.Next(0, 10000).ToString("0000");
                var res = await userManager.UpdateAsync(user);
                return View("_sucessRegister", user);

            }
            return View(model);
        }
        #endregion
        #region ResetPassword
        [Route("ResetPassword")]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string Mobile)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.Users.FirstOrDefaultAsync(p => p.PhoneNumber == Mobile);
                if (user == null)
                {
                    ModelState.AddModelError("Mobile", "کاربری با شماره وارد شده یافت نشد.");
                    return View();
                }
                var smsmanager = new SMSManager(_siteSetting);
                var sms = await smsmanager.ResetPasswordSMS(long.Parse(user.PhoneNumber), user.PhoneNumber, user.CodePhone, $"{_siteSetting.SiteInfo.Url}/cpa?id={user.Id}&c={user.CodePhone}");
                if (sms)
                {
                    return RedirectToAction("ChangePassword", new { id = user.Id });
                }
            }
            return View();
        }
        [Route("cpa")]
        public IActionResult ChangePassword(int id,string c ="")
        {
            var model = new ChangePasswordModel()
            {
                UserID = id
            };
            if (!string.IsNullOrEmpty(c))
            {
                model.Code = c;
            }
            return View(model);
        }
        [Route("cpa")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel dto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.Users.FirstOrDefaultAsync(p => p.Id == dto.UserID && p.CodePhone == dto.Code);
                if (user == null || (dto.Password != dto.RePassword))
                {
                    ModelState.AddModelError("Code", "اطلاعات وارد شده معتبر نمیباشد");

                }
                else
                {
                    var generator = new Random();
                    user.CodePhone = generator.Next(0, 10000).ToString("0000");
                    var ress = await userManager.UpdateAsync(user);
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var res = await userManager.ResetPasswordAsync(user, token, dto.Password);
                    if (res.Succeeded)
                        return View("_sucessPassword");
                }
            }
            return View(dto);
        }
        #endregion



        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Index");
        }
        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "");
            }
        }

        #endregion
    }
}