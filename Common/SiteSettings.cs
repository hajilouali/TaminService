using System.Collections.Generic;
using System.Security.Principal;
using System.Xml.Serialization;

namespace Common
{
    
    public class SiteSettings
    {
        public string ElmahPath { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public IdentitySettings IdentitySettings { get; set; }
        public EmailConfiguration EmailConfiguration { get; set; }
        public siteInfo SiteInfo { get; set; }
        public SMSConfiguration SMSConfiguration { get; set; }
    }

    public class IdentitySettings
    {
        public bool PasswordRequireDigit { get; set; }
        public int PasswordRequiredLength { get; set; }
        public bool PasswordRequireNonAlphanumic { get; set; }
        public bool PasswordRequireUppercase { get; set; }
        public bool PasswordRequireLowercase { get; set; }
        public bool RequireUniqueEmail { get; set; }
    }
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Encryptkey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int NotBeforeMinutes { get; set; }
        public int ExpirationMinutes { get; set; }
    }
    public class EmailConfiguration
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class siteInfo
    {
        public string CompanyInfo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        public string PortalURL { get; set; }
        public string Logo { get; set; }
        public string Logo2 { get; set; }
        public string SiteDiscription { get; set; }
        public string SiteKeys { get; set; }
        public bool IsFree { get; set; }
        public int fe { get; set; }
    }
    public class SMSConfiguration
    {
        public string SecurityCode { get; set; }
        public string ApiKey { get; set; }
        public int RegisterTemplateID { get; set; }
        public int ResetPasswordTemplateID { get; set; }
        public int SharjAccountingTemplateID { get; set; }
        public int DiskTemplateID { get; set; }
        public string URLFactorINFO { get; set; }
    }
    [XmlRoot("PagesConfig")]
    public class PagesConfig
    {
        [XmlElement("siteSlider")]
        public SiteSlider siteSlider { get; set; }
        [XmlElement("MobileSection")]
        public MobileSection MobileSection { get; set; }
        [XmlElement("InterfaceSectionProperty")]
        public List<interfaceSectionProperty> InterfaceSectionProperty { get; set; }
        [XmlElement("AndroidURL")]
        public string AndroidURL { get; set; }
        [XmlElement("IOSUrl")]
        public string IOSUrl { get; set; }
        [XmlElement("BazarUrl")]
        public string BazarUrl { get; set; }
    }
    public class SiteSlider
    {
        [XmlElement("subscriptionForm")]
        public bool subscriptionForm { get; set; }
        [XmlElement("Image")]
        public string Image { get; set; }
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("Subtitle")]
        public string Subtitle { get; set; }
        [XmlElement("Video")]
        public string Video { get; set; }
    }
    public class MobileSection
    {
        [XmlElement("MobileSectionProperties")]
        public List<MobileSectionProperty> MobileSectionProperties { get; set; }
    }
    public class MobileSectionProperty
    {
        [XmlElement("Image")]
        public string Image { get; set; }
        [XmlElement("Discription")]
        public string Discription { get; set; }
    }
    public class interfaceSectionProperty
    {
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("Discription")]
        public string Discription { get; set; }
        [XmlElement("property")]
        public List<string> property { get; set; }
        [XmlElement("Image1")]
        public string Image1 { get; set; }
        [XmlElement("Image2")]
        public string Image2 { get; set; }
    }
}
