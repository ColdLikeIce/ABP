
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mapster;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace MyDemo.GameUsers
{
    public class GameUserAppService : IGameUserAppService
    {
        private readonly IRepository<GameUser, int> _gameUserRepository;
        public GameUserAppService(
            IRepository<GameUser, int> repository)
        {
            _gameUserRepository = repository;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        public async Task<OperateResult> UserLogin(LoginUserDto loginInput)
        {
            var remark = "";
            switch (loginInput.loginType)
            {
                case 1:
                    remark = "1";
                    break;
                case 2:
                    remark = "2";
                    break;
                default:
                    remark = "3";
                    break;
            }
            OperateResult result = new OperateResult();
            var gameuser = loginInput.Adapt<GameUser>();
            //第三方登录 
            if (loginInput.IsThirdConfirmed)
            {
                //第三方登录直接校验第三方令牌
                var existUser = _gameUserRepository.FirstOrDefault(n =>
     n.ThirdOpenId.Equals(loginInput.ThirdOpenId) && n.ThirdToken.Equals(loginInput.ThirdToken));
                if (existUser == null)
                {
                    //注册
                    gameuser.RegisterTime = DateTime.Now;
                    await _gameUserRepository.InsertAsync(gameuser);
                }
            }
            else
            {
                var existUser = _gameUserRepository.FirstOrDefault(n => n.Email.Equals(loginInput.Email));
                if (existUser != null)
                {
                    if (existUser.IsForbidden)
                    {

                        TimeSpan timeSpan = DateTime.Now - existUser.LoginTime;
                        if (timeSpan.TotalMinutes < 30)
                        {
                            result.IsSuccess = false;
                            result.ErrorMsg = "登录错误次数超于3次，当前用户于" + (30 - Convert.ToInt32(timeSpan.TotalMinutes)) + "分钟后才能登录!";
                            return result;
                        }
                    }
                    if (existUser.PassWord.Equals(loginInput.PassWord))
                    {
                        //登录成功时 更新是否禁用为可用、最后登陆时间、错误次数为0.
                        existUser.LoginTime = DateTime.Now;
                        existUser.IsForbidden = false;
                        existUser.ErrCount = 0;
                        await _gameUserRepository.UpdateAsync(existUser);

                        result.IsSuccess = true;
                        result.SuccessMsg = "登录成功！";
                        return result;
                    }
                    else
                    {
                        //登录失败后 更新失败次数 +1
                        existUser.ErrCount = existUser.ErrCount + 1;
                        if (existUser.ErrCount == 3)
                        {
                            //更新禁用状态 记录最后登录时间
                            existUser.IsForbidden = true;
                            existUser.LoginTime = DateTime.Now;
                        }
                        await _gameUserRepository.UpdateAsync(existUser);
                        result.IsSuccess = false;
                        result.ErrorMsg = "登录失败，密码错误";
                        return result;
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorMsg = "登录失败，用户名错误";
                    return result;
                }
            }
            result.IsSuccess = true;
            result.SuccessMsg = "登录成功！";
            return result;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        public async Task<OperateResult> UserRegister(RegisterUserDto registerInput)
        {

            OperateResult result = new OperateResult();
            //转映射
            var gameuser = registerInput.Adapt<GameUser>();
            //注册时间
            gameuser.RegisterTime = DateTime.Now;
            if (gameuser.UserName != null && !Regex.Match(gameuser.UserName, "^[a-zA-Z0-9_]+$").Success)
            {
                result.IsSuccess = false;
                result.ErrorMsg = "用户名必须是英文,数字,下划线或组合!";
                return result;
            }
            //第三方授权注册
            if (registerInput.IsThirdConfirmed)
            {
                var existUser = _gameUserRepository.FirstOrDefault(n => n.Email.Equals(gameuser.Email)
                               || (n.ThirdOpenId.Equals(gameuser.ThirdOpenId) && n.ThirdToken.Equals(gameuser.ThirdToken)));
                if (existUser != null)
                {
                    result.IsSuccess = false;
                    result.ErrorMsg = "该用户已注册!";
                    return result;
                }
            }
            else
            {
                var existUser = _gameUserRepository.FirstOrDefault(n => n.Email.Equals(gameuser.Email) || n.UserName.Equals(gameuser.UserName));
                if (existUser != null)
                {
                    result.IsSuccess = false;
                    result.ErrorMsg = "该用户已注册!";
                    return result;
                }
            }
            //todo 记录端口 ip啥的

            await _gameUserRepository.InsertAsync(gameuser);

            result.IsSuccess = true;
            result.SuccessMsg = "注册成功！";
            return result;
        }
    }
}
