using System;
using System.Collections.Generic;
using System.Text;
using MyDemo.Localization;
using Volo.Abp.Application.Services;

namespace MyDemo
{
    /* Inherit your application services from this class.
     */
    public abstract class MyDemoAppService : ApplicationService
    {
        protected MyDemoAppService()
        {
            LocalizationResource = typeof(MyDemoResource);
            var remark = "";
            switch (1)
            {
                case 1:
                             remark = "1";
                          break;
                      case 2:
                              remark = "2";
                           break;
                default   :
                               remark = "3";
                            break;
            }
        }
    }
}
