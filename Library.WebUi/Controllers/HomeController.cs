using Library.Model;
using Library.WebUi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebUi.Controllers
{
   
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            LibraryDBs ctx = new LibraryDBs();
            var booklist = ctx.Books.ToList();
            
            return View(booklist);
        }
    }
}