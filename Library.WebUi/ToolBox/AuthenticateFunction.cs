using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebUi.ToolBox
{
    public class AuthenticateFunction
    {
        public static Member GetcurrentMember()
        {
            if (HttpContext.Current.Request.Cookies["UserId"] != null)
            {
                var userId = Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value);
                HttpContext.Current.Session["userId"] = userId;
            }
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
        public static void Logout ()
        {
            HttpContext.Current.Session["UserId"] = null;

            var cookie = HttpContext.Current.Request.Cookies["UserId"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Set(cookie);
            }
        }
    }
}