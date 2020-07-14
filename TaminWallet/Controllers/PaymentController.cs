using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Data.Repositories;
using Entities;
using Entities.Tamin;
using Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Parbad;
using Parbad.AspNetCore;
using Services.Services;
using TaminWallet.Models;

namespace TaminWallet.Controllers
{
    public class gatwayactive
    {
        public string Name { get; set; }
        public int value { get; set; }
    }
    public class PaymentController : Controller
    {
        private readonly IOnlinePayment _onlinePayment;
        private readonly UserManager<User> userManager;
        private readonly IRepository<PayementHistory> _PayementHistory;
        private readonly IRepository<UserPayement> _UserPayement;
        private readonly IRepository<OffersCode> _OffersCode;

        private readonly SiteSettings _siteSetting;
        private readonly Common.Parbad _Parbad;
        public PaymentController(IOnlinePayment onlinePayment, UserManager<User> userManager, IRepository<PayementHistory> payementHistory, IRepository<UserPayement> userPayement, IConfiguration configuration, IRepository<OffersCode> offersCode)
        {
            _onlinePayment = onlinePayment;
            this.userManager = userManager;
            _PayementHistory = payementHistory;
            _UserPayement = userPayement;
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
            _Parbad = configuration.GetSection(nameof(Common.Parbad)).Get<Common.Parbad>();
            _OffersCode = offersCode;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ActiveGatWates()
        {
            var resolt = new List<gatwayactive>();
            if (_Parbad.Gateways.IranKish!=null)
            {
                resolt.Add(new gatwayactive()
                {
                    Name = "ایران کیش",
                    value = 4
                });
            }
            if (_Parbad.Gateways.ZarinPall != null)
            {
                resolt.Add(new gatwayactive()
                {
                    Name = "زرین پال",
                    value = 7
                });
            }
            if (_Parbad.Gateways.Mellat != null)
            {
                resolt.Add(new gatwayactive()
                {
                    Name = "ملت",
                    value = 1
                });
            }
            if (_Parbad.Gateways.Parsian != null)
            {
                resolt.Add(new gatwayactive()
                {
                    Name = "پارسیان",
                    value = 2
                });
            }
            return Json(resolt);
        }



        [HttpGet("[action]/{id:int}/{Amount:long}/{Gateways:int}/{offerCode}")]
        public async Task<IActionResult> Pay(int id, long Amount, TaminWallet.Models.Gateways Gateways,string offerCode=null)
        {
            var verifyUrl = Url.Action("Verify", "Payment", null, Request.Scheme);
            var user = await userManager.FindByIdAsync(id.ToString());
            string discription = $"شارژ حساب {user.FullName} به مبلغ {Amount} ريال ";
            var result = await _onlinePayment.RequestAsync(invoice =>
            {
                if (Gateways == TaminWallet.Models.Gateways.ZarinPal)
                {
                    invoice
                    .SetAmount(Amount)
                    .SetCallbackUrl(verifyUrl)
                    .UseZarinPal($"شارژ حساب - {user.FullName}");
                }
                else
                {
                    invoice
                    .SetAmount(Amount)
                    .SetCallbackUrl(verifyUrl)
                    .SetGateway(Gateways.ToString());
                }
                invoice.UseAutoRandomTrackingNumber();

            });

            if (!string.IsNullOrEmpty(offerCode))
                discription = $"{discription} با کد تخفیف {offerCode}";
            // Save the result.TrackingNumber in your database.

            if (result.IsSucceed)
            {
                await _PayementHistory.AddAsync(new PayementHistory()
                {
                    Gateway = Gateways.ToString(),
                    IsSucess = false,
                    Price = Amount,
                    Trackingnumber = result.TrackingNumber,
                    UserID = user.Id,
                    Discription = discription,
                    OfferCode = offerCode
                }, new CancellationToken());

                return result.GatewayTransporter.TransportToGateway();
            }

            return View("PayRequestError", result);
        }
        public async Task<IActionResult> Verify()
        {
            var invoice = await _onlinePayment.FetchAsync();

            // Check if the invoice is new or it's already processed before.
            if (invoice.Status == PaymentFetchResultStatus.AlreadyProcessed)
            {
                // You can also see if the invoice is already verified before.
                var isAlreadyVerified = invoice.IsAlreadyVerified;
                return Content("The payment is already processed before.");
            }

            // This is an example of cancelling an invoice when you think that the payment process must be stopped.
            //if (!Is_There_Still_Product_In_Shop(invoice.TrackingNumber))
            //{
            //    var cancelResult = await _onlinePayment.CancelAsync(invoice, cancellationReason: "Sorry, We have no more products to sell.");

            //    return View("CancelResult", cancelResult);
            //}

            var verifyResult = await _onlinePayment.VerifyAsync(invoice);
            if (verifyResult.IsSucceed)
            {
                var dto = await _PayementHistory.Table.Where(p => p.Trackingnumber == verifyResult.TrackingNumber).Include(p=>p.User).FirstOrDefaultAsync();
                dto.IsSucess = true;
                dto.Transactioncode = verifyResult.TransactionCode;
                var offerdto =await _OffersCode.Table.Where(p => p.Code.Equals(dto.OfferCode)).SingleOrDefaultAsync();
                var userpayement = new UserPayement()
                {
                    Bestankar = dto.Price,
                    Bedehkari = 0,
                    Discription = dto.Discription,
                    Status = 1,
                    UserID = dto.UserID

                };
                if (offerdto.DateExpire<=DateTime.Now || offerdto.CountExpire>0)
                {
                    var Bestankar = Math.Round(userpayement.Bestankar + ((userpayement.Bestankar / 100) * offerdto.OfferRate));
                    string disc = $"شارژ حساب {dto.User.FullName} به مبلغ {Bestankar.ToString("n0")} با کد تخفیف {offerdto.Code} - پرداختی {userpayement.Bestankar.ToString("n0")}";
                    userpayement.Bestankar = Bestankar;
                    userpayement.Discription = disc;
                    dto.Discription = disc;
                    if (offerdto.CountExpire > 0)
                    {
                        offerdto.CountExpire--;
                        await _OffersCode.UpdateAsync(offerdto, new CancellationToken(),false);
                    }
                }
                await _PayementHistory.UpdateAsync(dto, new CancellationToken(),false);
                await _UserPayement.AddAsync(userpayement, new CancellationToken());
            }
           
            //var smsmanager = new SMSManager(_siteSetting);
            //var sms = await smsmanager.PhoneVerification(long.Parse(model.Mobile), string.IsNullOrEmpty(model.FullName) ? model.Mobile : model.FullName, user.CodePhone, $"{_siteSetting.SiteInfo.Url}/SubM?id={user.Id}&code={user.CodePhone}");
            return View(verifyResult);
        }
    }
}