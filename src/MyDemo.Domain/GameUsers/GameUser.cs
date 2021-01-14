using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyDemo.GameUsers
{
    public class GameUser: Entity<int>
    {
        [StringLength(18)]
        public string UserName { get; set; }
        [StringLength(18)]
        public string PassWord { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public bool EmailConfirmed { get; set; }
        public string ThirdOpenId { get; set; }
        public string ThirdToken { get; set; }
        public bool IsThirdConfirmed { get; set; }
        public string Port { get; set; }
        public string Lang { get; set; }
        public string Ip { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LoginTime { get; set; }
        public bool IsForbidden { get; set; }
        public int ErrCount { get; set; }
    }
}
