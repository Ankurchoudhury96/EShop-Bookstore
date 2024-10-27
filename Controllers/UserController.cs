using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EShop.Controllers
{
    public class UserController : Controller
    {
        private readonly Appdbcontext _context;
        public UserController(Appdbcontext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                var data = (from e1 in _context.Products
                            join e2 in _context.Categories
                            on e1.Cid equals e2.Cid
                            select new Product
                            {
                                Pid = e1.Pid,
                                Name = e1.Name,
                                Cid = e1.Cid,
                                Category = e2.CategoryName,
                                Description = e1.Description,
                                Price = e1.Price,
                                Ppic = e1.Ppic,
                                Pic = e1.Pic,
                            }).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                var data = (from e1 in _context.Products
                            join e2 in _context.Categories
                            on e1.Cid equals e2.Cid
                            where e1.Pid == id
                            select new Product
                            {
                                Pid = e1.Pid,
                                Name = e1.Name,
                                Cid = e1.Cid,
                                Category = e2.CategoryName,
                                Description = e1.Description,
                                Price = e1.Price,
                                Ppic = e1.Ppic,
                                Pic = e1.Pic,
                            }).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(Useraddress useraddress)
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                _context.Users.Add(useraddress);
                await _context.SaveChangesAsync();
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Success()
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                var data = await (from e1 in _context.Products
                                  join e2 in _context.Categories
                                  on e1.Cid equals e2.Cid
                                  select new Product
                                  {
                                      Pid = e1.Pid,
                                      Name = e1.Name,
                                      Cid = e1.Cid,
                                      Category = e2.CategoryName,
                                      Description = e1.Description,
                                      Price = e1.Price,
                                      Ppic = e1.Ppic,
                                      Pic = e1.Pic,
                                  }).ToListAsync();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(Registration registration)
        {
            var dataexists = await _context.Registrations.Where(x => x.Uname == registration.Uname).FirstOrDefaultAsync();
            if (dataexists == null)
            {
                _context.Registrations.Add(registration);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.msg = "User Already Found";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Registration registration, string email)
        {
            var validuser = await _context.Registrations.Where(x=>x.EmailAddress==registration.EmailAddress && x.Password==registration.Password).FirstOrDefaultAsync();
            if(validuser!=null)
            {
                HttpContext.Session.SetString("Useremail",registration.EmailAddress);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "No User Found");
                return View(registration);
            }
        }
        [HttpGet]
        public async Task<IActionResult> BiographyCat()
        {
            var data = await (from e1 in _context.Products
                              join e2 in _context.Categories
                              on e1.Cid equals e2.Cid
                              where e2.CategoryName=="Biography"
                              select new Product
                              {
                                  Pid = e1.Pid,
                                  Name = e1.Name,
                                  Cid = e1.Cid,
                                  Category = e2.CategoryName,
                                  Description = e1.Description,
                                  Price = e1.Price,
                                  Ppic = e1.Ppic,
                                  Pic = e1.Pic,
                              }).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> HistoryCat()
        {
            var data = await (from e1 in _context.Products
                              join e2 in _context.Categories
                              on e1.Cid equals e2.Cid
                              where e2.CategoryName == "History"
                              select new Product
                              {
                                  Pid = e1.Pid,
                                  Name = e1.Name,
                                  Cid = e1.Cid,
                                  Category = e2.CategoryName,
                                  Description = e1.Description,
                                  Price = e1.Price,
                                  Ppic = e1.Ppic,
                                  Pic = e1.Pic,
                              }).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> ComicsCat()
        {
            var data = await (from e1 in _context.Products
                              join e2 in _context.Categories
                              on e1.Cid equals e2.Cid
                              where e2.CategoryName == "Comics"
                              select new Product
                              {
                                  Pid = e1.Pid,
                                  Name = e1.Name,
                                  Cid = e1.Cid,
                                  Category = e2.CategoryName,
                                  Description = e1.Description,
                                  Price = e1.Price,
                                  Ppic = e1.Ppic,
                                  Pic = e1.Pic,
                              }).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Userorder(int id,Order order)
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                var productdetails = await _context.Products.Where(x=>x.Pid==id).FirstOrDefaultAsync();
                Order obj = new Order();
                obj.Useremail = email;
                obj.Productname = productdetails.Name;
                obj.Productid = productdetails.Pid;
                obj.DateofPurchase = System.DateTime.Now;

                _context.Orders.Add(obj);
                _context.SaveChanges();
                var orderlist = _context.Orders.ToList();
                return View(orderlist);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}

