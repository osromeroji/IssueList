using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using IssueListKanban.Models;
using Newtonsoft.Json.Linq;

namespace IssueListKanban.Controllers
{
    public class UserController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUsers()
        {
            List<User> userList = new User().GetUsers();
            return Json(userList, JsonRequestBehavior.AllowGet);
        }
    }
}