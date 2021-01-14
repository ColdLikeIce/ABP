using Microsoft.AspNetCore.Mvc;
using MyDemo.GameUsers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace MyDemo.Controllers.GameUser
{
    public class GameUserController:AbpController,IGameUserAppService
    {
        private readonly IGameUserAppService _service;
        public GameUserController(IGameUserAppService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("api/GameUser/Login")]
        public Task<OperateResult> UserLogin(LoginUserDto loginInput)
        {
            return _service.UserLogin(loginInput);
        }
        [HttpPost]
        [Route("api/GameUser/Register")]
        public Task<OperateResult> UserRegister(RegisterUserDto registerInput)
        {
            return _service.UserRegister(registerInput);
        }
    }
}
