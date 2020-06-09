using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaminWeb.Models
{
    public class LoginModels
    {
        [Required(ErrorMessage ="لطفا شماره تماس خود را وارد نمایید")]
        [MinLength(11,ErrorMessage ="لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        [MaxLength(11, ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        [RegularExpression("^0[0-9]*$", ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        public string Phone { get; set; }
        [DataType(DataType.Password)]
        [MinLength(7,ErrorMessage ="رمز عبور شما باید حداقل 7 کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد نمایید")]

        public string Password { get; set; }
        public bool IsRememmber { get; set; }

    }
    public class RegisterModel
    {        
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage = "رمز عبور شما باید حداقل 7 کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد نمایید")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا شماره تماس خود را وارد نمایید")]
        [MinLength(11, ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        [MaxLength(11, ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        [RegularExpression("^0[0-9]*$", ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        public string Mobile { get; set; }
        [MaxLength(100,ErrorMessage ="حداکثر 100 کاراکتر مورد تایید است")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "لطفا تکرار رمز عبور خود را وارد نمایید")]
        [StringLength(255, ErrorMessage = "رمز عبور شما باید حداقل 7 کاراکتر باشد", MinimumLength = 7)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار رمز عبور یکسان نمی باشند")]
        public string RePassword { get; set; }
    }
    public class SubmitMobileModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "لطفا کد ارسالی به تلفن همراه خود را وارد نمایید")]
        public string Code { get; set; }
    }
    public class ResetPassword
    {
        [Required(ErrorMessage = "لطفا شماره تماس خود را وارد نمایید")]
        [MinLength(11, ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        [MaxLength(11, ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        [RegularExpression("^0[0-9]*$", ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        public string Mobile { get; set; }
    }
    public class ChangePasswordModel
    {
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "رمز عبور شما باید حداقل 7 کاراکتر باشد", MinimumLength = 7)]
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد نمایید")]
        public string  Password { get; set; }
        [Required(ErrorMessage = "لطفا تکرار رمز عبور خود را وارد نمایید")]
        [StringLength(255, ErrorMessage = "رمز عبور شما باید حداقل 7 کاراکتر باشد", MinimumLength = 7)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="رمز عبور و تکرار رمز عبور یکسان نمی باشند")]
        public string RePassword { get; set; }
        public int UserID { get; set; }
        public string Code { get; set; }

    }
}
