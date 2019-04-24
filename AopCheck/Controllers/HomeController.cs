using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BLL.Obase;

namespace AopCheck.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            FE_VoucherEntity parm = new FE_VoucherEntity();
            IExecute exe = Server_side.GetInstance<OperBase>(parm, true);
            CallBackResult model = exe.Execute();
            return View();
         

        }
    }
}