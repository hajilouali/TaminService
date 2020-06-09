using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SMSManager
    {
        private string _token { get; set; }
        private SiteSettings _siteSetting { get; set; }
        public SMSManager(SiteSettings siteSetting)
        {
            _siteSetting = siteSetting;
            SmsIrRestful.Token tk = new SmsIrRestful.Token();
            string result = tk.GetToken(_siteSetting.SMSConfiguration.ApiKey, _siteSetting.SMSConfiguration.SecurityCode);
            _token = result;
        }

        public async Task<string> GetToken(string userApiKey, string secretKey)
        {
            SmsIrRestful.Token tk = new SmsIrRestful.Token();
            string result = tk.GetToken(userApiKey, secretKey);
            return result;
        }
        public async Task<bool> VerificationCodeByThemplate(SmsIrRestful.UltraFastSend dto)
        {

            var tk = new SmsIrRestful.UltraFast();
            var res = tk.Send(_token, dto);
            return res.IsSuccessful;
        }
        public async Task<bool> VerificationCode(SmsIrRestful.RestVerificationCode dto)
        {
            var tk = new SmsIrRestful.VerificationCode();
            var res = tk.Send(_token, dto);
            return res.IsSuccessful;
        }
        public async Task<bool> PhoneVerification(long Mobile,string user,string code,string Url)
        {
            var dto = new SmsIrRestful.UltraFastSend()
            {
                Mobile = Mobile,
                TemplateId = _siteSetting.SMSConfiguration.RegisterTemplateID,

                ParameterArray = new SmsIrRestful.UltraFastParameters[]
                {
                    new SmsIrRestful.UltraFastParameters()
                    {
                        Parameter="User",
                        ParameterValue=user
                    },
                    new SmsIrRestful.UltraFastParameters()
                    {
                        Parameter="Code",
                        ParameterValue=code
                    },
                    new SmsIrRestful.UltraFastParameters()
                    {
                        Parameter="Company",
                        ParameterValue=_siteSetting.SiteInfo.CompanyInfo
                    },
                    new SmsIrRestful.UltraFastParameters()
                    {
                        Parameter="UserInfo",
                        ParameterValue=Url
                    }
                }
            };
            var tk = new SmsIrRestful.UltraFast();
            var res =tk.Send(_token, dto);
            return res.IsSuccessful;
        }
        public async Task<bool> ResetPasswordSMS(long Mobile, string user, string code, string Url)
        {
            var dto = new SmsIrRestful.UltraFastSend()
            {
                Mobile = Mobile,
                TemplateId = _siteSetting.SMSConfiguration.ResetPasswordTemplateID,

                ParameterArray = new SmsIrRestful.UltraFastParameters[]
                {
                    new SmsIrRestful.UltraFastParameters()
                    {
                        Parameter="User",
                        ParameterValue=user
                    },
                    new SmsIrRestful.UltraFastParameters()
                    {
                        Parameter="Code",
                        ParameterValue=code
                    },
                    new SmsIrRestful.UltraFastParameters()
                    {
                        Parameter="Company",
                        ParameterValue=_siteSetting.SiteInfo.CompanyInfo
                    },
                    new SmsIrRestful.UltraFastParameters()
                    {
                        Parameter="UserInfo",
                        ParameterValue=Url
                    }
                }
            };
            var tk = new SmsIrRestful.UltraFast();
            var res = tk.Send(_token, dto);
            return res.IsSuccessful;
        }
    }
}