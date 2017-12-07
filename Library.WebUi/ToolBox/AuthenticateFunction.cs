using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebUi.ToolBox
{
    public static class AuthenticateFunction
    {
        public static Member GetcurrentMember()
        {
            if (HttpContext.Current.Session["UserId"] != null)
            {
                var userId = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
                LibraryDBs ctx = new LibraryDBs();
                var currentUser = ctx.Members.Find(userId);
                return currentUser;
            }
            else
            {
                return null;
            }
        }
    }
}