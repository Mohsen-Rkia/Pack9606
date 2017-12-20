using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.ToolBox
{
    public class AuthorizeMemberAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticateFunction.GetcurrentMember() == null)
            {
                filterContext.Result = new HttpStatusCodeResult(401);
            }
        }
    }
}