using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Mihajlo_Potrcko.Components
{
    public class RequireRequestValueAttribute : ActionMethodSelectorAttribute
    {
        public RequireRequestValueAttribute(string valueName)
        {
            ValueName = valueName;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            if (controllerContext.HttpContext.Request.RequestType == "POST")
            {
                return false;
            }
            return controllerContext?.HttpContext?.Request?[ValueName] != null;
        }
        public string ValueName { get; private set; }
    }
}