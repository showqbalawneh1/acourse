using Acourse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Acourse.Controllers
{
    public class HomeController : Controller
    {
        
        private courseContext context { get; set; }
        public HomeController(courseContext ctx)
        {
            context = ctx;
        }
        [HttpPost]
        public IActionResult signup(user u1 )
        {
            if (ModelState.IsValid)
            {
                context.uesrs.Add(u1);
                context.SaveChanges();
                var c1 = context.uesrs.FirstOrDefault(n => n.email == u1.email && n.password == u1.password);
                if (c1 != null)
                {
                    HttpContext.Session.SetString("email", c1.email);
                    HttpContext.Session.SetString("name", c1.uname);
                    return View("index");
                }
                return View("signup");
            }
            return View("signup");
        }
        [HttpGet]
        public IActionResult signup()
        {
            return View();
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return View("index");
        }
        public IActionResult blog()
        {
           
            return View();
        }
        public IActionResult login (login log )
        {
            var c1 = context.uesrs.Where(n => n.email == log.email).FirstOrDefault();
            if (c1 != null)
            {
                if (c1.password == log.password)
                {
                    HttpContext.Session.SetString("email", c1.email);
                    HttpContext.Session.SetString("name", c1.uname);
                    return View("index");
                }
                return View("signup");
            }
            else return View("signup");
       
        }
        public IActionResult courses()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                var corses = context.courses.Include(m => m.field).OrderBy(m => m.courseId).ToList();
                return View(corses);
            }
            else return View("signup");
           
          
        }
        public IActionResult fcou(int id)
        {
           
                List<course> c = context.courses.Include(m => m.field).Where(m => m.fieldId == id).OrderBy(m => m.courseId).ToList();
                return View(c);
         
           

        }
       
        public IActionResult fileds()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                var fl = context.fields.OrderBy(m => m.fieldId).ToList();
                return View(fl);
            }
            return View("signup");
        }

        public IActionResult addf()
        {
            return View();
        }
        [HttpGet]
        public IActionResult addc()
        {
            List<field>fl= context.fields.OrderBy(m => m.fieldId).ToList();
            ViewBag.f1 = fl;
            return View();
        }
        [HttpPost]
        public IActionResult addc(course c1)
        {
            field f1 = context.fields.Find(c1.fieldId);
            c1.field = f1;
            if (ModelState.IsValid)
            {
                context.courses.Add(c1);
                context.SaveChanges();
            }
            else return View();
            var corses = context.courses.Include(m => m.field).OrderBy(m => m.courseId).ToList();
            return View("courses", corses);
        }
        
        public IActionResult deletec(int id)
        {
            course c1 = context.courses.Find(id);
            context.courses.Remove(c1);
            context.SaveChanges();
            var corses = context.courses.Include(m => m.field).OrderBy(m => m.courseId).ToList();
            return View("courses", corses);
        }

        public IActionResult editc(int id)
        {
            List<field> fl = context.fields.OrderBy(m => m.fieldId).ToList();
            ViewBag.f1 = fl;
            var c1 = context.courses.Find(id);
            return View(c1);
        }
        [HttpPost]
        public IActionResult editc(course c1)
        {
            if (ModelState.IsValid)
            {
                context.courses.Update(c1);
                context.SaveChanges();
            }
            else return View();
            var corses = context.courses.Include(m => m.field).OrderBy(m => m.courseId).ToList();
            return View("courses", corses);
        }
        public IActionResult editf(int id )
        {
            var f1 = context.fields.Find(id);
            return View(f1);
        }
        [HttpPost]
        public IActionResult editf1(field f1)
        {
            if (ModelState.IsValid)
            context.fields.Update(f1);
            context.SaveChanges();
            var fl = context.fields.OrderBy(m => m.fieldId).ToList();
            return View("fileds", fl);
        }

        [HttpPost]
        public IActionResult addf1(field f1)
        {
               if (ModelState.IsValid)
                context.fields.Add(f1);
                context.SaveChanges();
                var fl = context.fields.OrderBy(m => m.fieldId).ToList();
               return View("fileds", fl);

        }
        [HttpGet]
            public IActionResult deletef(int id)
        {
            var field = context.fields.Find(id);
            context.fields.Remove(field);
            context.SaveChanges();
            var f1 = context.fields.OrderBy(m => m.fieldId).ToList();

            return View("fileds",f1);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
