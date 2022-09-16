using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SportschoolPrototype.Data;
using SportschoolPrototype.Models;
using System.Diagnostics;

namespace SportschoolPrototype.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Course()
        {
            var data = _context.courses.ToList();

            Console.WriteLine(data);

            return View(data);
        }

        [HttpPost]
        public ActionResult course()
        {
            return View();
        }

        public ActionResult CheckIn(int id)
        {
            var data = _context.members.FirstOrDefault(x => x.Id == id);

            if (data.TimesLeft == 0 || data.TimesLeft == null)
            {
                // Functionaliteit
                var obj = _context.subscriptions.FirstOrDefault(x => x.Id == data.subscriptionId);
                data.TimesLeft = (int)obj.weeklyUses;
                _context.SaveChanges();

                return View("Index", _context.members.ToList());
            }

            data.TimesLeft--;
            _context.SaveChanges();
            return View("Index", _context.members.ToList());
        }

        public IActionResult Detail(int id)
        {
            var data = _context.members.FirstOrDefault(x => x.Id == id);
            return View(data);
        }


        public IActionResult Edit(int id)
        {
            var data = _context.members.FirstOrDefault(x => x.Id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult edit(int id, string firstname, string lastname)
        {
            var data = _context.members.FirstOrDefault(x => x.Id == id);

            data.firstname = firstname;
            data.lastname = lastname; 

            _context.members.Update(data);

            _context.SaveChanges();

            return View("Index", _context.members.ToList());
        }

        public IActionResult Index()
        {
            return View(_context.members.ToList());
        }

        // create the view for this action
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Member member)
        {
            member.subscriptionId = 1;
            _context.members.Add(member);
            _context.SaveChanges();

            string message = "Created succesfully";

            ViewBag.Message = message;

            return View("Index", _context.members.ToList());
        }

        public IActionResult Delete(int id)
        {
            var data = _context.members.FirstOrDefault(x => x.Id == id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete(int id)
        {
            var data = _context.members.FirstOrDefault(x => x.Id == id);
            if(data != null)
            {
                _context.members.Remove(data);
                _context.SaveChanges();
                return View("Index", _context.members.ToList());
            } else
            {
                return View("Index", _context.members.ToList());
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}