using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace MyDemo.Controllers.test
{
    public class tController : AbpController
    {
        public tController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
