using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyDemo.GameUsers
{
    public interface IGameUserAppService : IApplicationService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperateResult> UserLogin(LoginUserDto loginInput);
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperateResult> UserRegister(RegisterUserDto registerInput);
    }
}
