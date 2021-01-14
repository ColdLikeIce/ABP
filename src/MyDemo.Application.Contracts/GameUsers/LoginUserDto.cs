using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MyDemo.GameUsers
{
    public class LoginUserDto
    {
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string ThirdOpenId { get; set; }
        public string ThirdToken { get; set; }
        public bool IsThirdConfirmed { get; set; }
        public string Lang { get; set; }
    }
}
