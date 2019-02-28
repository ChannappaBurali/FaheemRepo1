using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAssignmentReg.Controllers
{
    public class HomeController : Controller
    {
        Model1Container md = new Model1Container();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reg()
        {           
            var ls = md.Studs.Select(s => s.State).Distinct().ToList();
            var ls1 = md.Studs.Select(s => s.City).Distinct().ToList();
           
            if (ls!=null && ls1!=null)
            {
                ViewBag.data = ls;
                ViewBag.city = ls1;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Reg([Bind(Include ="Name,Address,Gender,State,City")] Stud stud)
        {
            if (ModelState.IsValid)
            {
                md.Studs.Add(stud);
                md.SaveChanges();
            }            
            return View(stud);
        }
    }
}