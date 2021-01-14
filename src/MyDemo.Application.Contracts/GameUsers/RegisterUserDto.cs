using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyDemo.GameUsers
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string ThirdOpenId { get; set; }
        public string ThirdToken { get; set; }
        public bool IsThirdConfirmed { get; set; }
    }
}
